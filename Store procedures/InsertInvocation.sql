ALTER PROCEDURE InsertInvocation
	@WorkOrderNumber INT,
	@InvocationState VARCHAR(100),
	@ToolId INT,
	@UserId INT,
	@Category VARCHAR(100),
	@Reason NVARCHAR(1000),
	@ToolName NVARCHAR(1000),
	@InvocationDescription NVARCHAR(4000)
AS
BEGIN

	IF NOT EXISTS (SELECT 1 FROM Invocations WHERE WorkOrderNumber = @WorkOrderNumber)
	BEGIN
		INSERT INTO Invocations(WorkOrderNumber, InvocationState, ToolId, UserId, Category, Reason, ToolName, InvocationDescription)
		VALUES(@WorkOrderNumber, @InvocationState, @ToolId, @UserId, @Category, @Reason, @ToolName, @InvocationDescription)
		SELECT 1
	END
	ELSE
	BEGIN
		SELECT 0
	END
END
