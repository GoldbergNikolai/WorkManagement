
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--COMMENTING IS NOT COMPLETE ON THIS PROCEDURE
--Procedure will update a certain users details incase name/lastname was misspelled etc.
--Procedure can be executed by user
--input: PhoneNumber, FirstName, LastName
--output: 1- details changed successfully
--	  NULL- Phone number not found

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
