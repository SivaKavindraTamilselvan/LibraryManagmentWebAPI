CREATE OR REPLACE PROCEDURE return_book(borrow_id INT,lost bool,damaged_id INT DEFAULT NULL)
LANGUAGE plpgsql
AS $$
DECLARE
book_copy_id INT;
fine_amount DECIMAL;
member_id INT;
new_damaged_book_id INT;
BEGIN

IF NOT EXISTS (SELECT 1 FROM "Borrowing" WHERE "BorrowingId" = borrow_id) THEN
RAISE EXCEPTION 'Borrowing ID is not found';
END IF;

IF damaged_id IS NOT NULL THEN
IF NOT EXISTS (SELECT 1 FROM "DamagedLevel" WHERE "DamagedLevelId" = damaged_id) THEN
RAISE EXCEPTION 'Damaged ID is not found';
END IF;
END IF;

SELECT "BookCopyId","MemberId" INTO book_copy_id,member_id
FROM "Borrowing" WHERE "BorrowingId" = borrow_id;

UPDATE "Borrowing" SET "ReturnDate" = NOW(),"BorrowingStatusId" = 2
WHERE "BorrowingId" = borrow_id;

fine_amount := get_fine_amount(borrow_id);

IF fine_amount IS NULL THEN
fine_amount := 0;
END IF;
	
IF fine_amount > 0 THEN
INSERT INTO "Fine"("BorrowingId","FineCategoryId","FineAmount","createdAt") 
VALUES(borrow_id,3,fine_amount,NOW());
END IF;

IF damaged_id IS NOT NULL THEN
SELECT "FineAmount" INTO fine_amount FROM "DamagedLevel"
WHERE "DamagedLevelId" = damaged_id;
INSERT INTO "DamagedBook"("MemberId","BookCopyId","DamagedLevelId","createdAt")
VALUES(member_id,book_copy_id,damaged_id,NOW())
RETURNING "DamagedBookId" INTO new_damaged_book_id;
INSERT INTO "Fine"("BorrowingId","FineCategoryId","DamagedBookId","FineAmount","createdAt") 
VALUES(borrow_id,2,new_damaged_book_id,fine_amount,NOW());

END IF;

IF lost THEN
INSERT INTO "Fine"("BorrowingId","FineCategoryId","FineAmount","createdAt") 
VALUES(borrow_id,1,1500,NOW());
END IF;

UPDATE "BookCopy" SET "BookStatusId" =
CASE
WHEN lost THEN 3    
WHEN damaged_id IS NOT NULL THEN 4  
ELSE 1                
END
WHERE "BookCopyId" = book_copy_id;

END;
$$;
