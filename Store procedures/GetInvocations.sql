ALTER PROCEDURE GetInvocations
	@UserId INT = NULL,
	@InvocationState VARCHAR(100) = NULL,
	@ToolId INT = NULL
AS 
BEGIN
	IF (@UserId IS NOT NULL)
	BEGIN
		
			SELECT * FROM Invocations WHERE UserId = @UserId 
			AND InvocationState = CASE
							 WHEN @InvocationState IS NOT NULL THEN @InvocationState
							 ELSE InvocationState
						END
			AND ToolId = CASE
							WHEN @ToolId IS NOT NULL THEN @ToolId
							ELSE ToolId
						END
	END

	ELSE IF (@ToolId IS NOT NULL)
	BEGIN
		SELECT * 
		FROM Invocations 
		WHERE ToolId = @ToolId
			  AND InvocationState = CASE
					  WHEN @InvocationState IS NOT NULL THEN @InvocationState
					  ELSE InvocationState
				  END
	END
	
	ELSE
	BEGIN
			SELECT * FROM Invocations WHERE InvocationState = @InvocationState
	END
	
END