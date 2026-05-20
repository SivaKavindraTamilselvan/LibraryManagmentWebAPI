CREATE OR REPLACE FUNCTION get_number_of_books_by_isbn(ISBN varchar(100))
RETURNS INT
LANGUAGE plpgsql
AS $$
DECLARE 
number_of_books INT;
BEGIN

SELECT COUNT(*) INTO number_of_books FROM "BookISBN" bi
JOIN "BookCopy" bc ON bc."BookISBNId" = bi."BookISBNId"
WHERE bi."ISBN" = ISBN;
IF number_of_books <= 0 THEN
RAISE EXCEPTION 'No Book Is Found';
END IF;

RETURN number_of_books;

END;
$$;