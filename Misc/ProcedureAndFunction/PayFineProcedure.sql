CREATE OR REPLACE PROCEDURE pay_fine(fine_id INT,fine_amount NUMERIC,mode_of_payment int)
LANGUAGE plpgsql
AS $$

DECLARE 
actual_fine_amount NUMERIC;

BEGIN
IF NOT EXISTS (SELECT 1 FROM "Fine" WHERE "FineId" = fine_id)
THEN RAISE EXCEPTION 'Fine Id Not Found';
END IF;

IF NOT EXISTS (SELECT 1 FROM "ModeOfPayment" WHERE "ModeOfPaymentId" = mode_of_payment)
THEN RAISE EXCEPTION 'Invalid Mode Of Payemnet';
END IF;
 
SELECT f."FineAmount" - COALESCE(SUM(p."AmountPaid"), 0) INTO actual_fine_amount FROM "Fine" f
LEFT JOIN "Payment" p ON f."FineId" = p."FineId" 
WHERE f."FineId" = fine_id
GROUP BY f."FineAmount";

IF fine_amount > actual_fine_amount THEN
RAISE EXCEPTION 'Payment exceeds remaining fine amount';
END IF;

INSERT INTO "Payment"("FineId","AmountPaid","ModeOfPaymentId","PaymentDate","createdAt")
VALUES(fine_id,fine_amount,mode_of_payment,NOW(),NOW());

IF fine_amount = actual_fine_amount THEN
UPDATE "Fine" SET "IsPaidFully" = true
WHERE "FineId" = fine_id;
END IF;

END;
$$;