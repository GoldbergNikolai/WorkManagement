
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Procedure will be used in order to register an invocation into the Database
--Procedure will be activated once a user decides to sign tool(צ') into the Database
--input: WorkOrderNumber, InvocationState, ToolId, UserId, Category, Reason, ToolName, InvocationDescription, Created, Updated
--output: 1- Invocation inserted into Database
--	  0- WorkOrderNumber(פק"ע) is already in the Database


ALTER PROCEDURE [dbo].[InsertInvocation]
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
		INSERT INTO Invocations(WorkOrderNumber, InvocationState, ToolId, UserId, Category, Reason, ToolName, InvocationDescription, Created, Updated)
		VALUES(@WorkOrderNumber, @InvocationState, @ToolId, @UserId, @Category, @Reason, @ToolName, @InvocationDescription, GETDATE(), GETDATE())
		SELECT 1
	END
	ELSE
	BEGIN
		SELECT 0
	END
END
