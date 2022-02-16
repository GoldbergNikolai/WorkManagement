
ALTER PROCEDURE UpdateAdminState
 @UserId INT
,@IsAdmin BIT
AS

--Procedure will be used in order to update users permissions to Admin and vice versa
--Procedure will be executed only by other admins
--input: UserId, IsAdmin
--output: 1- Users Admin status was altered
-- 	  0- User wasnt found

BEGIN
	DECLARE @UserToAlter INT = NULL
	SELECT @UserToAlter = 1 FROM Users WHERE UserId = @UserId 
	
	IF @UserToAlter IS NOT NULL
	BEGIN
		UPDATE Users
		SET IsAdmin = @IsAdmin
		WHERE UserId = @UserId

		SELECT 1
	END
	ELSE
	BEGIN
		SELECT 0
	END
END
