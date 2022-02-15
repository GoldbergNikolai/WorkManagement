
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[CheckIfUserExists]
 @PhoneNumber VARCHAR(20)
AS
BEGIN
	SELECT * 
	FROM Users
	WHERE PhoneNumber = @PhoneNumber 
END
