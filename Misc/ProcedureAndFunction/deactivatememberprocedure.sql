CREATE OR REPLACE PROCEDURE deactivate_member(member_id INT)
LANGUAGE plpgsql
AS $$

DECLARE 
pending_borrowing_count INT;
already_active_status BOOLEAN;

BEGIN

IF NOT EXISTS (SELECT 1 FROM "Member" WHERE "MemberId" = member_id)
THEN RAISE EXCEPTION 'Member Id Not Found';
END IF;

SELECT "isActive" INTO already_active_status FROM "Member"
WHERE "MemberId" = member_id;

IF already_active_status = false THEN
RAISE EXCEPTION 'Member Already Deactivated';
END IF;

SELECT COUNT(*) INTO pending_borrowing_count FROM "Borrowing"
WHERE "MemberId" = member_id AND "BorrowingStatusId"!=2;

IF pending_borrowing_count > 0 THEN
RAISE EXCEPTION 'There Is Book That Need To Be Returned';
END IF;

UPDATE "Member" SET "isActive" = false
WHERE "MemberId" = member_id;

END;
$$;