CREATE OR REPLACE FUNCTION get_number_of_books_by_category(category_id int)
RETURNS INT
LANGUAGE plpgsql
AS $$
DECLARE 
number_of_books INT;
BEGIN
IF NOT EXISTS (SELECT 1 FROM "BookCategory" WHERE "BookCategoryId" = category_id)
THEN RAISE EXCEPTION 'Catgory Id Not Found';
END IF;
SELECT COUNT(*) INTO number_of_books FROM "BookCategory" c
JOIN "Book" b ON c."BookCategoryId" = b."BookCategoryId"
JOIN "BookISBN" bi ON bi."BookId" = b."BookId" 
JOIN "BookCopy" bc ON bc."BookISBNId" = bi."BookISBNId"
WHERE c."BookCategoryId" = category_id;
IF number_of_books <= 0 THEN
RAISE EXCEPTION 'No Book Is Found';
END IF;

RETURN number_of_books;

END;
$$;