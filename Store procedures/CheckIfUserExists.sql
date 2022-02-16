
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Procedure will recieve a phone number and will return a user with a matching phone number
--Procedure will be used in login (No passwords as of now, idf login api will be implemented later)
--input: PhoneNumber
--output: UserId, PhoneNumber, Active, FirstName, LastName, IsAdmin.

ALTER PROCEDURE [dbo].[CheckIfUserExists]
 @PhoneNumber VARCHAR(20)
AS
BEGIN
	SELECT * 
	FROM Users
	WHERE PhoneNumber = @PhoneNumber 
END
