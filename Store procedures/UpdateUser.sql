
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[UpdateUser]
  @PhoneNumber VARCHAR(20)
 ,@FirstName NVARCHAR(100)
 ,@LastName NVARCHAR(100)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Users WHERE PhoneNumber = @PhoneNumber)
	BEGIN
		UPDATE Users
		SET FirstName = CASE
							WHEN FirstName <> @FirstName THEN @FirstName
							ELSE FirstName
						END
		   ,LastName = CASE
						   WHEN LastName <> @LastName THEN @LastName
						   ELSE LastName
					   END
		 WHERE PhoneNumber = @PhoneNumber

		SELECT SCOPE_IDENTITY()
	END
END
