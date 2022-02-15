
ALTER PROCEDURE UpdatePhoneNumberActivationState
 @PhoneNumber VARCHAR(20)
,@Active BIT
AS
BEGIN
	DECLARE @UserPhoneNumber VARCHAR(20) = NULL
	SELECT @UserPhoneNumber = 1 FROM PhoneNumbers WHERE PhoneNumber = @PhoneNumber 
	
	IF @UserPhoneNumber IS NOT NULL
	BEGIN
		UPDATE PhoneNumbers
		SET Active = @Active
		WHERE PhoneNumber = @PhoneNumber

		SELECT 1
	END
	ELSE
	BEGIN
		SELECT 0
	END
END