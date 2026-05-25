CREATE OR REPLACE PROCEDURE check_borrowing_rules(member_id INT,book_id INT)
LANGUAGE plpgsql
AS $$ 
DECLARE
member_active BOOLEAN;
unpaid_fines DECIMAL;
count_book_available INT;
max_books INT;
borrow_days INT;
current_borrowing INT;
already_borrowed INT;
selected_book_copy_id INT;

BEGIN

SELECT "isActive" INTO member_active FROM "Member"
WHERE "MemberId" = member_id;

IF member_active IS NULL THEN
RAISE EXCEPTION 'Member is Not Found';
END IF;

IF member_active = FALSE THEN
RAISE EXCEPTION 'Member is Not Active';
END IF;

SELECT COUNT(*) INTO count_book_available FROM "Book" b
JOIN "BookISBN" bi ON b."BookId" = bi."BookId"
JOIN "BookCopy" bc ON bi."BookISBNId" = bc."BookISBNId"
WHERE b."BookId" = book_id AND bc."BookStatusId" = 1;

IF count_book_available <= 0 THEN
RAISE EXCEPTION 'Book Not Available Currently';
END IF;

SELECT mt."NumberOfBooks",mt."LimitDays" INTO max_books,borrow_days
FROM "MemberTypes" mt JOIN "Member" m 
ON m."MemberTypeId" = mt."MemberTypeId"
WHERE m."MemberId" = member_id;

SELECT COUNT(*) INTO current_borrowing FROM "Borrowing"
WHERE "MemberId" = member_id AND "ReturnDate" IS NULL;

IF current_borrowing >= max_books THEN
RAISE EXCEPTION 'Borrowing limit reached';
END IF;

SELECT COALESCE(SUM(f."FineAmount" - COALESCE((SELECT SUM(p."AmountPaid")FROM "Payment" p WHERE p."FineId" = f."FineId"),0)),0) INTO unpaid_fines
FROM "Fine" f JOIN "Borrowing" b
ON f."BorrowingId" = b."BorrowingId"
WHERE b."MemberId" = member_id;

IF unpaid_fines > 500 THEN 
RAISE EXCEPTION 'Unpaid fine exceeds 500';
END IF;

SELECT COUNT(*) INTO already_borrowed FROM "Borrowing" b 
JOIN "BookCopy" bc ON b."BookCopyId" = bc."BookCopyId" 
JOIN "BookISBN" bi ON bc."BookISBNId" = bi."BookISBNId"
WHERE b."MemberId" = member_id AND bi."BookId" = book_id AND b."ReturnDate" IS NULL;

IF already_borrowed > 0 THEN
RAISE EXCEPTION 'Same book already borrowed and not returned';
END IF;

RAISE NOTICE 'Book Can Be Added Successfully';

SELECT bc."BookCopyId" INTO selected_book_copy_id FROM "Book" b 
JOIN "BookISBN" bi ON bi."BookId" = b."BookId" 
JOIN "BookCopy" bc ON bc."BookISBNId" = bi."BookISBNId"
WHERE b."BookId" = book_id AND bc."BookStatusId" = 1
ORDER BY bi."Edition" DESC,bi."PublishedYear" DESC
LIMIT 1
FOR UPDATE;

IF selected_book_copy_id IS NULL THEN 
RAISE EXCEPTION 'No Available Book Copy Found';
END IF;

INSERT INTO "Borrowing"("MemberId","BookCopyId","BorrowedDate","DueDate","BorrowingStatusId","createdAt")
VALUES(member_id,selected_book_copy_id,NOW(),NOW() + make_interval(days => borrow_days),1,NOW());

UPDATE "BookCopy" SET "BookStatusId" = 2 
WHERE "BookCopyId" = selected_book_copy_id;

END;
$$;