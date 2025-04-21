Use master

Go

--drops db for changes to db
Drop Database OrchidDB

Go

Create Database OrchidDB

Go

Use OrchidDB

Go


-- Table
-- Every users of the app

Create Table AppUsers

(

Id int Primary Key Identity,

UserName nvarchar(20) Not Null,

UserEmail nvarchar(50) Unique Not Null,

UserPassword nvarchar(12) Not Null,

IsPremium bit Not Null Default 0,

IsAdmin bit Not Null Default 0

)


-- Table
-- Every character a player created

Create Table Characters

(

Id int Primary Key Identity,

UserId int Foreign Key References AppUsers(Id),

Character_Name nvarchar(50) Not Null,

Level_Value int not null Default 1,

img_id nvarchar(100)


)



-- Table
-- Every Filter a character can use in the app


Create Table Filters
(

Id int Primary Key Identity,

FName nvarchar(20) Not Null,

)

-- Table
-- Every link between a character and a filter can use in the app


Create Table FiltersToCharacter
(

Id int Primary Key Identity,

CharacterId int Foreign Key References Characters(Id),

FilterId int Foreign Key References Filters(Id),

)

-- Table
-- Every Forum in the app


Create Table Forums
(

Id int Primary Key Identity,

FName nvarchar(20) Not Null,

)

-- Table
-- Every Post in the app


Create Table Posts
(

Id int Primary Key Identity,

UserId int Foreign Key References AppUsers(Id),

Title nvarchar(20) Not Null,

Forum int Foreign Key References Forums(Id),

PostBody nvarchar(1000) Not Null,

Likes int Default 0,

PViews int Default 0,

)

-- Table
-- Every Comment for Post in the app


Create Table Comments
(

Id int Primary Key Identity,

UserId int Foreign Key References AppUsers(Id),

PostId int Foreign Key References Posts(Id),

CommentBody nvarchar(1000) Not Null,

Likes int Default 0

)

-- Table
-- Every Appeal for getting unbanned from the forums


Create Table Appeals
(

Id int Primary Key Identity,

UserId int Foreign Key References AppUsers(Id),

Reason nvarchar(100) Not Null,

Explanation nvarchar(100) Not Null,

)

-- Create a login for the admin user
CREATE LOGIN [OrchidAdminLogin] WITH PASSWORD = 'theOrchid';
Go

-- Create a user in the YourProjectNameDB database for the login
CREATE USER [OrchidAdminUser] FOR LOGIN [OrchidAdminLogin];
Go

-- Add the user to the db_owner role to grant admin privileges
ALTER ROLE db_owner ADD MEMBER [OrchidAdminUser];
Go

Insert Into AppUsers Values('test1', 'test1@gmail.com', 'test1111', 1, 1)
Go

Insert Into Filters Values('Support')
Insert Into Filters Values('DPS')
Insert Into Filters Values('Tank')
Insert Into Filters Values('Low_Level')
Insert Into Filters Values('High_Level')
Go

SELECT * FROM AppUsers;
GO

SELECT * FROM Characters;
GO

-- scaffold-DbContext "Server = (localdb)\MSSQLLocalDB;Initial Catalog=OrchidDB;User ID=OrchidAdminLogin;Password=theOrchid;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models -Context OrchidDbContext -DataAnnotations –force