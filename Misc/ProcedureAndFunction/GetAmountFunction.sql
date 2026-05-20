CREATE OR REPLACE FUNCTION get_fine_amount(borrow_id INT)
RETURNS NUMERIC
LANGUAGE plpgsql
AS $$
DECLARE
fine_days INT;
BEGIN
SELECT ("ReturnDate"::date - "DueDate"::date) INTO fine_days
FROM "Borrowing" WHERE "BorrowingId" = borrow_id;

IF fine_days IS NULL OR fine_days < 0 THEN
RETURN 0;
END IF;

RETURN fine_days * 10;

END;
$$;
