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

Id int Primary Key,

UserId int Foreign Key References AppUsers(Id),

Level_Value int not null Default 1,

img_id nvarchar(100)


)

-- Table
-- Every statistic a character has

Create Table Character_Stats
(
Id int Primary Key Foreign Key References Characters(Id) ,

Strength int not null,

Dexterity int not null,

Constitution int not null,

Intelligence int not null,

Wisdom int not null,

Charisma int not null,


)

-- Table
-- Every race a character has and the selected subrace

Create Table Race

(

Id int Primary Key Foreign Key References Characters(Id) ,

Race_Name nvarchar(50) Not Null,

Subrace_name nvarchar(50) Not Null,
)

-- Table
-- Every class/classes a character has and the selected subclass

Create Table Class

(

Id int Primary Key Foreign Key References Characters(Id),

Class_Name nvarchar(50) Not Null,

Subclass_Name nvarchar(4000) Not Null,

Level_Value int not null Default 1,

)


-- Table
-- Every feat a character has and the level it was taken

Create Table Feats

(

Id int Primary Key Foreign Key References Characters(Id),

Feat_Name nvarchar(50) Not Null,

Level_taken int not null Default 1,

)

-- Table
-- Every proficiency a character has in a saving throw

Create Table Proficiencies_saves

(

Id int Primary Key Foreign Key References Characters(Id),

Strength bit not null Default 0,

Dexterity bit not null Default 0,

Constitution bit not null Default 0,

Intelligence bit not null Default 0,

Wisdom bit not null Default 0,

Charisma bit not null Default 0,

)

-- Table
-- Every proficiency a character has in a skill

Create Table Proficiencies_skills

(

Id int Primary Key Foreign Key References Characters(Id),

Acrobatics bit Not Null Default 0,

Animal_Handling bit Not Null Default 0,

Arcana bit Not Null Default 0,

Athletics bit Not Null Default 0,

Deception bit Not Null Default 0,

History bit Not Null Default 0,

Insight bit Not Null Default 0,

Intimidation bit Not Null Default 0,

Investigation bit Not Null Default 0,

Medicine bit Not Null Default 0,

Nature bit Not Null Default 0,

Perception bit Not Null Default 0,

Performance bit Not Null Default 0,

Persuasion bit Not Null Default 0,

Religion bit Not Null Default 0,

Sleight_of_Hand bit Not Null Default 0,

Stealth bit Not Null Default 0,

Survival bit Not Null Default 0,

)

-- Table
-- Every proficiency a character has in a language

Create Table Proficiencies_languages

(

Id int Primary Key Foreign Key References Characters(Id),

Common bit Not Null Default 0,

Dwarvish bit Not Null Default 0,

Elvish bit Not Null Default 0,

Giant bit Not Null Default 0,

Gnomish bit Not Null Default 0,

Goblin bit Not Null Default 0,

Halfling bit Not Null Default 0,

Orc_language bit Not Null Default 0,

Abyssal bit Not Null Default 0,

Celestial bit Not Null Default 0,

Draconic bit Not Null Default 0,

Deep_Speech bit Not Null Default 0,

Infernal bit Not Null Default 0,

Primodial bit Not Null Default 0,

Sylvan bit Not Null Default 0,

Undercommon bit Not Null Default 0,

Druidic bit Not Null Default 0,

Thieves_Cant bit Not Null Default 0,

)

-- Table
-- Every proficiency a character has in a tool


Create Table Proficiencies_Tools

(

Id int Primary Key Foreign Key References Characters(Id),

Alchemists_supplies bit Not Null Default 0,
Brewers_supplies bit Not Null Default 0,
Calligraphers_supplies bit Not Null Default 0,
Carpenters_tools bit Not Null Default 0,
Cartographers_tools bit Not Null Default 0,
Cobblers_tools bit Not Null Default 0,
Cooks_utensils bit Not Null Default 0,
Glassblowers_tools bit Not Null Default 0,
Jewelers_tools bit Not Null Default 0,
Leatherworkers_tools bit Not Null Default 0,
Masons_tools bit Not Null Default 0,
Painters_supplies bit Not Null Default 0,
Potters_tools bit Not Null Default 0,
Smiths_tools bit Not Null Default 0,
Tinkers_tools bit Not Null Default 0,
Weavers_tools bit Not Null Default 0,
Woodcarvers_tools bit Not Null Default 0,
Gaming_sets  bit Not Null Default 0,
Dice_set  bit Not Null Default 0,
Playing_card_set bit Not Null Default 0,
Musical_instruments  bit Not Null Default 0,
Bagpipes bit Not Null Default 0,
Drum bit Not Null Default 0,
Dulcimer bit Not Null Default 0,
Flute bit Not Null Default 0,
Lute bit Not Null Default 0,
Lyre bit Not Null Default 0,
Horn bit Not Null Default 0,
Pan_flute bit Not Null Default 0,
Shawm bit Not Null Default 0,
Viol bit Not Null Default 0,
Navigators_tools bit Not Null Default 0,
Thieves_tools bit Not Null Default 0,

)

-- Table
-- Every proficiency a character has in a Weapon


Create Table Proficiencies_Weapons

(

Id int Primary Key Foreign Key References Characters(Id),

Simple_Weapons bit Not Null Default 0,

Martial_Weapons bit Not Null Default 0,

Club bit Not Null Default 0,
Dagger bit Not Null Default 0,
Greatclub bit Not Null Default 0,
Handaxe bit Not Null Default 0,
Javelin bit Not Null Default 0,
Light_hammer bit Not Null Default 0,
Mace bit Not Null Default 0,
Quarterstaff bit Not Null Default 0,
Sickle bit Not Null Default 0,
Spear bit Not Null Default 0,
Light_Crossbow bit Not Null Default 0,
Dart bit Not Null Default 0,
Shortbow bit Not Null Default 0,
Sling bit Not Null Default 0,
Battleaxe bit Not Null Default 0,
Flail bit Not Null Default 0,
Glaive bit Not Null Default 0,
Greataxe bit Not Null Default 0,
Greatsword bit Not Null Default 0,
Halberd bit Not Null Default 0,
Lance bit Not Null Default 0,
Longsword bit Not Null Default 0,
Maul bit Not Null Default 0,
Morningstar bit Not Null Default 0,
Pike bit Not Null Default 0,
Rapier bit Not Null Default 0,
Scimitar bit Not Null Default 0,
Shortsword bit Not Null Default 0,
Trident bit Not Null Default 0,
War_pick bit Not Null Default 0,
Warhammer bit Not Null Default 0,
Whip bit Not Null Default 0,
Blowgun bit Not Null Default 0,
Hand_Crossbow bit Not Null Default 0,
Heavy_Crossbow bit Not Null Default 0,
Longbow bit Not Null Default 0,
Net bit Not Null Default 0,
)

-- Table
-- Every proficiency a character has in a armor


Create Table Proficiencies_Armors

(

Id int Primary Key Foreign Key References Characters(Id),

All_Armor bit Not Null Default 0,

Heavy_Armor bit Not Null Default 0,

Medium_Armor bit Not Null Default 0,

Light_Armor bit Not Null Default 0,

Shield bit Not Null Default 0,

)

-- Table
-- Every spell a Character has learned


Create Table Spells
(

Id int Primary Key Foreign Key References Characters(Id),

Spell_Name nvarchar(50) Not Null,

Spell_Level int not null Default 0,
)



-- Table
-- Every equipment a Character has


Create Table Equipments

(

Id int Primary Key Foreign Key References Characters(Id),

Is_Weapon bit Not Null Default 0, 

Is_Armor bit Not Null Default 0, 

Is_Shield bit Not Null Default 0,

Is_Attunment bit Not Null Default 0,

)

-- Table
-- Every D&D Group in the app with its game master


Create Table Parties
(

Id int Primary Key Identity,

DmId int Foreign Key References AppUsers(Id),

PName nvarchar(20) Not Null,

Current_Campain nvarchar(30)
)

-- Table
-- Every User in a D&D Party


Create Table Partie_Users
(

UserId int Foreign Key References AppUsers(Id),

PartyId int Foreign Key References Parties(Id),

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

SELECT * FROM AppUsers;
GO

-- scaffold-DbContext "Server = (localdb)\MSSQLLocalDB;Initial Catalog=OrchidDB;User ID=OrchidAdminLogin;Password=theOrchid;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models -Context OrchidDbContext -DataAnnotations –force