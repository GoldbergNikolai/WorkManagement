--create table PhoneNumbers
--(
--	 PhoneNumber VARCHAR(20)--(Login)
--	,Active bit
--	 primary key (PhoneNumber)
--)

create table Users
(
	 UserId INT IDENTITY
	,PhoneNumber VARCHAR(20)--(Login)
	,Active BIT
	,FirstName NVARCHAR(100)
	,LastName NVARCHAR(100)
	primary key (UserId),
  --foreign key (PhoneNumber) REFERENCES PhoneNumbers(PhoneNumber)
)

create table ToolCategories
(
	ToolCategoryId INT IDENTITY,
	Category VARCHAR(100),
	primary key (ToolCategoryId)
)

create table Tools
(
	ToolId INT IDENTITY,
	CategoryId INT, 
	ToolName NVARCHAR(1000),
	primary key (ToolId),
	foreign key (CategoryId) REFERENCES ToolCategories(ToolCategoryId)
)

create table Invocations
(
	WorkOrderNumber INT,
	InvocationState VARCHAR(100),
	ToolId INT,
	UserId INT, 
	Reason NVARCHAR(1000),
	InvocationDescription NVARCHAR(4000),
	primary key (WorkOrderNumber),
	foreign key (UserId) REFERENCES [dbo].Users(UserId),
	foreign key (ToolId) REFERENCES [dbo].Tools(ToolId)
)