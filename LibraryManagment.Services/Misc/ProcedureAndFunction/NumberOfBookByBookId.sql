CREATE OR REPLACE FUNCTION get_number_of_books_by_book(book_id int)
RETURNS INT
LANGUAGE plpgsql
AS $$
DECLARE 
number_of_books INT;
BEGIN
IF NOT EXISTS (SELECT 1 FROM "Book" WHERE "BookId" = book_id)
THEN RAISE EXCEPTION 'Book ID Not Found';
END IF;
SELECT COUNT(*) INTO number_of_books FROM "Book" b
JOIN "BookISBN" bi ON bi."BookId" = b."BookId" 
JOIN "BookCopy" bc ON bc."BookISBNId" = bi."BookISBNId"
WHERE b."BookId" = book_id;
IF number_of_books <= 0 THEN
RAISE EXCEPTION 'No Book Is Found';
END IF;

RETURN number_of_books;

END;
$$;