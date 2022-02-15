
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[InsertUser]
  @PhoneNumber VARCHAR(20)
 ,@FirstName NVARCHAR(100)
 ,@LastName NVARCHAR(100)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Users WHERE PhoneNumber = @PhoneNumber)
	BEGIN
		INSERT INTO Users(FirstName, LastName, PhoneNumber, Active, IsAdmin)
		VALUES(@FirstName, @LastName, @PhoneNumber, 0, 0)

		SELECT SCOPE_IDENTITY()
	END
END
