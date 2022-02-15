ALTER PROCEDURE UpdateInvocation
	@WorkOrderNumber INT,
	@InvocationState VARCHAR(100),
	@InvocationDescription NVARCHAR(4000)
AS
BEGIN
	DECLARE @InvocationStateToAlter VARCHAR(100) = @InvocationState,
	        @InvocationDescriptionToAlter NVARCHAR(4000) = NULL
	SELECT @InvocationDescriptionToAlter = InvocationDescription FROM Invocations WHERE WorkOrderNumber = @WorkOrderNumber
	SET @InvocationDescriptionToAlter = @InvocationDescriptionToAlter + '<br>' + @InvocationDescription
	
	UPDATE Invocations 
	SET InvocationDescription = @InvocationDescriptionToAlter 
	WHERE WorkOrderNumber = @WorkOrderNumber

	IF ((SELECT InvocationDescription FROM Invocations WHERE WorkOrderNumber = @WorkOrderNumber) = @InvocationDescriptionToAlter)
	BEGIN 
		SELECT 1
	END
	ELSE
	BEGIN
		SELECT 0
	END
END