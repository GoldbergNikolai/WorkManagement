ALTER PROCEDURE GetInvocations
	@UserId INT = NULL,
	@InvocationState VARCHAR(100) = NULL,
	@ToolId INT = NULL
AS 

--Procedure will recieve UserId, InvocationState and ToolId(all of which can be NULL, incase user doesnt know what to fill) and will return all Tools with matching fields
--Procedure will be used to display certain Tools (צ') that the user is interested in
--input: UserId, InvocationState, ToolId (all can be null)
--output: WorkOrderNumber, InvocationState, ToolId, UserId, Category, Reason, ToolName, InvocationDescription, Created, Updated

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
