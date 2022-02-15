
ALTER PROCEDURE UpdateUser
  @PhoneNumber VARCHAR(20)
 ,@FirstName NVARCHAR(100)
 ,@LastName NVARCHAR(100)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Users WHERE PhoneNumber = @PhoneNumber)
	BEGIN
		UPDATE Users
		SET FirstName = @FirstName
		   ,LastName = @LastName

		SELECT 1
	END
	ELSE
	BEGIN
		SELECT 0
	END
END