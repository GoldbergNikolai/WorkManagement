
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetUsers]
	@UserId INT = NULL,
	@PhoneNumber VARCHAR(20) = NULL,
	@Active BIT = NULL,
	@IsAdmin BIT = NULL,
	@Top INT = NULL,
	@BringAll BIT = 0
AS 
BEGIN
	IF @BringAll = 0
	BEGIN
		 IF (@UserId IS NOT NULL)
		 BEGIN 
		 	IF  EXISTS (SELECT 1 FROM Users WHERE UserId = @UserId)
		 	BEGIN
		 		SELECT * FROM Users 
		 		WHERE UserId = @UserId 
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
		 ELSE IF (@PhoneNumber IS NOT NULL)
		 BEGIN
		 	DECLARE @UsersCount INT
		 	SELECT @UsersCount = COUNT(1) FROM Users 
		 	WHERE PhoneNumber LIKE '%' + @PhoneNumber + '%'
		 
		 	IF @UsersCount > 0
		 	BEGIN 
		 		SET @Top = CASE 
		 					   WHEN @Top IS NOT NULL THEN @Top 
		 					   ELSE @UsersCount 
		 				   END
		 
		 		SELECT TOP (@Top) * FROM Users 
		 		WHERE PhoneNumber LIKE '%' + @PhoneNumber + '%'
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
		 	SELECT NULL
		 END
	END
	ELSE
	BEGIN
		 SELECT * FROM Users
	END
END
