
ALTER PROCEDURE UpdateAdminState
 @UserId INT
,@IsAdmin BIT
AS
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