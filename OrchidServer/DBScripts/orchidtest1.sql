Drop Database OrchidDB

Go

Create Database OrchidDB

Go

Use OrchidDB

Go

Create Table AppUsers

(

Id int Primary Key Identity,

UserName nvarchar(20) Not Null,

UserEmail nvarchar(50) Unique Not Null,

UserPassword nvarchar(12) Not Null,

IsPremium bit Not Null Default 0,

IsAdmin bit Not Null Default 0

)
/* creating components for cheracter first to avoid error */
Create Table Races

(

Id int Primary Key Identity,

R_Name nvarchar(50) Unique Not Null,

R_Description nvarchar(4000) Not Null,

IsOfficial bit Not Null Default 0
)

Create Table Classes

(

Id int Primary Key Identity,

C_Name nvarchar(50) Unique Not Null,

C_Description nvarchar(4000) Not Null,
)

Create Table Sub_Classes

(

Id int Primary Key Identity,

Class_Id int Foreign Key References Classes(Id),

Sub_C_Name nvarchar(50) Unique Not Null,

Sub_C_Description nvarchar(4000) Not Null,

IsOfficial bit Not Null Default 0
)

Create Table Feats

(

Id int Primary Key Identity,

F_Name nvarchar(50) Unique Not Null,

F_Description nvarchar(4000) Not Null,

IsOfficial bit Not Null Default 0
)

Create Table Spells
(

Id int Primary Key Identity,

S_Name nvarchar(50) Unique Not Null,

S_Level int not null Default 0,

S_Description nvarchar(4000) Not Null,

IsOfficial bit Not Null Default 0
)

Create Table Skill_Stats

(

Id int Primary Key Identity,

SName varchar(10) Unique Not Null,
)

Create Table Skills

(

Id int Primary Key Identity,

SName varchar(10) Unique Not Null,

Stat int Foreign Key References Skill_Stats(Id),
)

Create Table Equip_Type

(

Id int Primary Key Identity,

TName varchar(10) Unique Not Null
)

Create Table Equip_Rarity

(

Id int Primary Key Identity,

RName varchar(10) Unique Not Null
)

Create Table Equipments

(

Id int Primary Key Identity,

TypeId int Foreign Key References Equip_Type(Id),

RarityId int Foreign Key References Equip_Rarity(Id),

E_Description nvarchar(2000) Not Null,

IsOfficial bit Not Null Default 0
)

Create Table Ch_List

(

Id int Primary Key,

UserId int Foreign Key References AppUsers(Id),

Main_Class int Foreign Key References Classes(Id),

Race int Foreign Key References Races(Id),

Subclass int Foreign Key References Races(Id),

Level_Value int not null Default 1,

IsMultiClass bit Not Null Default 0,

imgID int

)


Create Table Parties
(

Id int Primary Key Identity,

DmId int Foreign Key References AppUsers(Id),

PName nvarchar(20) Not Null,

Current_Campain nvarchar(30)
)

Create Table Partie_Users
(

UserId int Foreign Key References AppUsers(Id),

PartyId int Foreign Key References Parties(Id),

)

Create Table Forums
(

Id int Primary Key Identity,

FName nvarchar(20) Not Null,

)

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

Create Table Comments
(

Id int Primary Key Identity,

UserId int Foreign Key References AppUsers(Id),

PostId int Foreign Key References Posts(Id),

CommentBody nvarchar(1000) Not Null,

Likes int Default 0

)

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

-- scaffold-DbContext "Server = (localdb)\MSSQLLocalDB;Initial Catalog=OrchidDB;User ID=OrchidAdminLogin;Password=theOrchid;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models -Context OrchidDbContext -DataAnnotations –force