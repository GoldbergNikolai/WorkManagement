SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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