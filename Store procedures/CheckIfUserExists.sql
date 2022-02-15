
ALTER PROCEDURE CheckIfUserExists
 @PhoneNumber VARCHAR(20)
AS
BEGIN
	DECLARE @UserPhoneNumber VARCHAR(20) = NULL,
		    @UserActive INT = 0
	SELECT @UserPhoneNumber = PhoneNumber, @UserActive = Active FROM Users WHERE PhoneNumber = @PhoneNumber
	
	IF @UserPhoneNumber IS NOT NULL
	BEGIN
		 SELECT CASE
					WHEN @UserActive = 1 THEN 1
					ELSE 0
				END
	END
	ELSE
	BEGIN
		SELECT -1
	END
END