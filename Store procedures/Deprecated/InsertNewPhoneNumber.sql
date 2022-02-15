
ALTER PROCEDURE InsertNewPhoneNumber
 @PhoneNumber VARCHAR(20)
,@Active BIT = 1
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM PhoneNumbers WHERE PhoneNumber = @PhoneNumber )
	BEGIN
		INSERT INTO PhoneNumbers (PhoneNumber, Active)
		VALUES (@PhoneNumber, 0)
	END

	SELECT @@ROWCOUNT 
END