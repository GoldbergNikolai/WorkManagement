
ALTER PROCEDURE UpdateUserActivationState
 @UserId INT
,@Active BIT
AS
BEGIN
	DECLARE @UserToAlter INT = NULL
	SELECT @UserToAlter = 1 FROM Users WHERE UserId = @UserId 
	
	IF @UserToAlter IS NOT NULL
	BEGIN
		UPDATE Users
		SET Active = @Active
		WHERE UserId = @UserId

		SELECT 1
	END
	ELSE
	BEGIN
		SELECT 0
	END
END