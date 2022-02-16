
ALTER PROCEDURE UpdateUserActivationState
 @UserId INT
,@Active BIT
AS

--Procedure will update a certain users active state from active to inactive and vice versa
--Procedure can only be executed by admins
--input: UserId, Active
--output: 1- Active state altered successfully
-- 	  0- UserId was no found

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
