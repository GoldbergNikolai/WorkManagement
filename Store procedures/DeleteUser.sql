SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Procedure will delete a user with a matching UserId
--Procedure will be used incase a misinput happens(wrong phone number etc.) 
--input: UserId
--output: Lines affected (INT)

ALTER PROCEDURE [dbo].[DeleteUser]
 @UserId INT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Users WHERE @UserId = @UserId )
	BEGIN
		DELETE Users
		WHERE UserId = @UserId
	END

	SELECT @@ROWCOUNT 
END
