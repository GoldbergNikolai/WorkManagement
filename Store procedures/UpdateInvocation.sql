
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--PROCEDURE NEEDS TO BE TESTED
--Procedure will update the Invocation status and Invocation Description fields on a certain chosen WorkOrderNumber(פק"ע)
--Procedure will add the new description to the the old description creating a log of all necessary data
--Procedure will be executed by Users in order to give current status on certain tool
--input: WorkOrderNumber, InvocationState, InvocationDescription
--output: 1- Update was completed successfully 
--	  0- Description update failed
--	  2- State update failed

ALTER PROCEDURE [dbo].[UpdateInvocation]
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
	   ,Updated = GETDATE(), InvocationState = @InvocationState --LAST LINE WAS ADDED IN GIT AND WASNT TESTED, TESTING TO BE DONE
	WHERE WorkOrderNumber = @WorkOrderNumber

	IF ((SELECT InvocationDescription FROM Invocations WHERE WorkOrderNumber = @WorkOrderNumber) = @InvocationDescriptionToAlter)
	BEGIN 
		IF ((SELECT InvocationState FROM Invocations WHERE WorkOrderNumber = @WorkOrderNumber) = @InvocationStateToAlter) --THIS SECTION WAS ALSO ADDED IN GIT SO THIS NEEDS TO GET TESTED ASWELL
		BEGIN
			SELECT 1
		END
		ELSE
		BEGIN
			SELECT 2
		END
	END
	ELSE
	BEGIN
		SELECT 0
	END
END
