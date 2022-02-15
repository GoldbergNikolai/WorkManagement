ALTER PROCEDURE GetUsers
	@UserId INT,
	@PhoneNumber VARCHAR(20),
	@Active BIT = NULL,
	@IsAdmin BIT = NULL
AS 
BEGIN

	IF (@UserId IS NOT NULL)
	BEGIN 

		IF NOT EXISTS (SELECT * FROM Users WHERE UserId = @UserId)
		BEGIN	
			SELECT 0
		END
		ELSE
		BEGIN
			SELECT * FROM Users WHERE UserId = @UserId 
			AND Active = CASE
							 WHEN @Active IS NOT NULL THEN @Active
							 ELSE Active
						END
			AND IsAdmin = CASE
							WHEN @IsAdmin IS NOT NULL THEN @IsAdmin
							ELSE IsAdmin
						END
		END

	END


	ELSE
	BEGIN
		IF (@PhoneNumber IS NOT NULL)
		BEGIN 
			IF NOT EXISTS (SELECT * FROM Users WHERE PhoneNumber LIKE '%' + @PhoneNumber + '%')
			BEGIN 
				SELECT 0
			END
			ELSE 
			BEGIN 
				SELECT * FROM Users WHERE PhoneNumber LIKE '%' + @PhoneNumber + '%'
				AND Active = CASE
							 WHEN @Active IS NOT NULL THEN @Active
							 ELSE Active
						END
				AND IsAdmin = CASE
							WHEN @IsAdmin IS NOT NULL THEN @IsAdmin
							ELSE IsAdmin	
						END
			END
		END

		ELSE
		BEGIN
			SELECT 0
		END

	END
	
END