
CREATE PROCEDURE DeleteUser
 @PhoneNumber VARCHAR(20)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Users WHERE PhoneNumber = @PhoneNumber )
	BEGIN
		DELETE Users
		WHERE PhoneNumber = @PhoneNumber
	END

	SELECT @@ROWCOUNT 
END