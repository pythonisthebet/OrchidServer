using Microsoft.AspNetCore.Mvc;
using OrchidServer.Models;
using Microsoft.AspNetCore.Http;
using OrchidServer.DTO;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Dynamic;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using System;

namespace OrchidServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrchidAPIController : ControllerBase
    {
        //a variable to hold a reference to the db context!
        private OrchidDbContext context;
        //a variable that hold a reference to web hosting interface (that provide information like the folder on which the server runs etc...)
        private IWebHostEnvironment webHostEnvironment;
        //Use dependency injection to get the db context and web host into the constructor
        public OrchidAPIController(OrchidDbContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.webHostEnvironment = env;
        }

        [HttpGet]
        [Route("TestServer")]
        public ActionResult<string> TestServer()
        {
            return Ok("Server Responded Successfully");
        }

        //Helper functions
        #region Backup / Restore
        [HttpGet("Backup")]
        public async Task<IActionResult> Backup()
        {
            string path = $"{this.webHostEnvironment.WebRootPath}\\..\\DBScripts\\backup.bak";

            bool success = await BackupDatabaseAsync(path);
            if (success)
            {
                return Ok("Backup was successful");
            }
            else
            {
                return BadRequest("Backup failed");
            }
        }

        [HttpGet("Restore")]
        public async Task<IActionResult> Restore()
        {
            string path = $"{this.webHostEnvironment.WebRootPath}\\..\\DBScripts\\backup.bak";

            bool success = await RestoreDatabaseAsync(path);
            if (success)
            {
                return Ok("Restore was successful");
            }
            else
            {
                return BadRequest("Restore failed");
            }
        }
        //this function backup the database to a specified path
        private async Task<bool> BackupDatabaseAsync(string path)
        {
            try
            {

                //Get the connection string
                string? connectionString = context.Database.GetConnectionString();
                //Get the database name
                string databaseName = context.Database.GetDbConnection().Database;
                //Build the backup command
                string command = $"BACKUP DATABASE {databaseName} TO DISK = '{path}'";
                //Create a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //Open the connection
                    await connection.OpenAsync();
                    //Create a command
                    using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                    {
                        //Execute the command
                        await sqlCommand.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //THis function restore the database from a backup in a certain path
        private async Task<bool> RestoreDatabaseAsync(string path)
        {
            try
            {
                //Get the connection string
                string? connectionString = context.Database.GetConnectionString();
                //Get the database name
                string databaseName = context.Database.GetDbConnection().Database;
                //Build the restore command
                string command = $@"
                USE master;
                ALTER DATABASE {databaseName} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                RESTORE DATABASE {databaseName} FROM DISK = '{path}' WITH REPLACE;
                ALTER DATABASE {databaseName} SET MULTI_USER;";

                //Create a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //Open the connection
                    await connection.OpenAsync();
                    //Create a command
                    using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                    {
                        //Execute the command
                        await sqlCommand.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion


        [HttpPost("login")]
        public IActionResult Login([FromBody] DTO.LoginInfo loginDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Get model user class from DB with matching email. 
                Models.AppUser? modelsUser = context.GetUser(loginDto.Email);

                //Check if user exist for this email and if password match, if not return Access Denied (Error 403) 
                if (modelsUser == null || modelsUser.UserPassword != loginDto.Password)
                {
                    return Unauthorized();
                }

                //Login suceed! now mark login in session memory!
                HttpContext.Session.SetString("loggedInUser", modelsUser.UserEmail);

                DTO.AppUser dtoUser = new DTO.AppUser(modelsUser);
                return Ok(dtoUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] OrchidServer.DTO.AppUser userDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Create model user class
                Models.AppUser modelsUser = userDto.GetModel();

                context.AppUsers.Add(modelsUser);
                context.SaveChanges();

                //User was added!
                DTO.AppUser dtoUser = new DTO.AppUser(modelsUser);
                return Ok(dtoUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("updateUser")]
        public IActionResult UpdateUser([FromBody] OrchidServer.DTO.AppUser userDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Create model user class
                Models.AppUser modelsUser = userDto.GetModel();

                context.AppUsers.Update(modelsUser);
                context.SaveChanges();

                //User was added!
                return Ok(modelsUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //this function check which profile image exist and return the virtual path of it.
        //if it does not exist it returns the default profile image virtual path
        private string GetProfileImageVirtualPath(int userId)
        {
            string virtualPath = $"/profileImages/{userId}";
            string path = $"{this.webHostEnvironment.WebRootPath}\\profileImages\\{userId}.png";
            if (System.IO.File.Exists(path))
            {
                virtualPath += ".png";
            }
            else
            {
                path = $"{this.webHostEnvironment.WebRootPath}\\profileImages\\{userId}.jpg";
                if (System.IO.File.Exists(path))
                {
                    virtualPath += ".jpg";
                }
                else
                {
                    virtualPath = $"/profileImages/default.png";
                }
            }

            return virtualPath;
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                HttpContext.Session.Clear();


                List<Models.AppUser>? Modelusers = context.GetAllUsersC();
                List<DTO.AppUser> Dtousers = new List<DTO.AppUser>();


                foreach (Models.AppUser user in Modelusers)
                {
                    DTO.AppUser placeholderuser = new(user);
                    Dtousers.Add(placeholderuser);
                }
                return Ok(Dtousers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("getAllCharacters")]
        public IActionResult GetAllCharacters([FromBody] OrchidServer.DTO.AppUser userDto)
        {
            try
            {
                HttpContext.Session.Clear();

                Models.AppUser appUser = userDto.GetModel();
                List<Models.Character>? ModelCharacters = context.GetAllCharacters(appUser);
                List<DTO.Character> DtoCharacters = new List<DTO.Character>();


                foreach (Models.Character character in ModelCharacters)
                {
                    DTO.Character placeholderuser = new(character);
                    DtoCharacters.Add(placeholderuser);
                }
                return Ok(DtoCharacters);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("createCharacter")]
        public IActionResult CreateCharacter([FromBody] OrchidServer.DTO.Character character)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Create model user class
                Models.Character modelsCharacter = character.GetModel();

                context.Characters.Add(modelsCharacter);
                context.SaveChanges();

                //User was added!
                DTO.Character dtoCharacter = new DTO.Character(modelsCharacter);
                return Ok(dtoCharacter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("getCharactersFORFilters")]
        public IActionResult GetCharactersFORFilters([FromBody] List<OrchidServer.DTO.Filter> filterList)
        {
            try
            {
                HttpContext.Session.Clear();

                List<Models.Filter> list = new List<Models.Filter>();

                foreach (var filter in filterList) 
                {
                    list.Add(filter.GetModel());

                }
                List<Models.Character>? ModelCharacters = context.GetCharactersFORFilters(list);
                List<DTO.Character> DtoCharacters = new List<DTO.Character>();


                foreach (Models.Character character in ModelCharacters)
                {
                    DTO.Character placeholderuser = new(character);
                    DtoCharacters.Add(placeholderuser);
                }
                return Ok(DtoCharacters);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("getAllFilters")]
        public IActionResult GetAllFilters()
        {
            try
            {
                HttpContext.Session.Clear();

                List<Models.Filter> ModelFilters = context.GetAllFilters(); ;
                List<DTO.Filter> DtoFilters = new List<DTO.Filter>();


                foreach (Models.Filter filter in ModelFilters)
                {
                    DTO.Filter placeholderFilters = new(filter);
                    DtoFilters.Add(placeholderFilters);
                }
                return Ok(DtoFilters);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //[HttpPost("getAllClasses")]
        //public IActionResult GetAllClasses([FromBody] OrchidServer.DTO.Character character)
        //{
        //    try
        //    {
        //        HttpContext.Session.Clear();

        //        Models.Character modelCharacter = character.GetModel();
        //        List<Models.Class>? ModelClasses = context.GetAllClasses(modelCharacter);
        //        List<DTO.Class> DtoClasses = new List<DTO.Class>();


        //        foreach (Models.Class item in ModelClasses)
        //        {
        //            DTO.Class placeholderClass = new(item);
        //            DtoClasses.Add(placeholderClass);
        //        }
        //        return Ok(DtoClasses);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}


        //[HttpPost("getSkills")]
        //public IActionResult GetSkills([FromBody] OrchidServer.DTO.Character character)
        //{
        //    try
        //    {

        //        HttpContext.Session.Clear();

        //        Models.Character modelCharacter = character.GetModel();
        //        Models.ProficienciesSkill? ModelSkills = context.GetSkills(modelCharacter);
        //        DTO.ProficienciesSkill skills = new();
        //        List<string> listskills = new();    
        //        if (ModelSkills != null)
        //        {
        //            DTO.ProficienciesSkill DtoSkills = new DTO.ProficienciesSkill();

        //            skills = new(ModelSkills);
        //        }

        //        foreach (PropertyInfo propertyInfo in skills.GetType().GetProperties())
        //        {
        //            if (propertyInfo.PropertyType is bool)
        //            {
        //                if (propertyInfo.Attributes.Equals(true))
        //                {
        //                    listskills.Add(propertyInfo.Name);
        //                }
        //            }
        //        }

        //        return Ok(skills);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

        //[HttpPost("getRace")]
        //public IActionResult GetRace([FromBody] OrchidServer.DTO.Character character)
        //{
        //    try
        //    {

        //        HttpContext.Session.Clear();

        //        Models.Character modelCharacter = character.GetModel();
        //        Models.Race? ModelRace = context.GetRace(modelCharacter);
        //        DTO.Race race = new();
        //        if (ModelRace != null)
        //        {
        //            DTO.Race DtoRace = new DTO.Race();

        //            race = new(ModelRace);
        //        }
        //        return Ok(race);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}


        //[HttpPost("addClass")]
        //public IActionResult AddClass([FromBody] OrchidServer.DTO.Class item)
        //{
        //    try
        //    {
        //        HttpContext.Session.Clear(); //Logout any previous login attempt

        //        //Create model user class
        //        Models.Class modelsClass = item.GetModel();

        //        context.Classes.Add(modelsClass);
        //        context.SaveChanges();

        //        //User was added!
        //        DTO.Class dtoClass = new DTO.Class(modelsClass);
        //        return Ok(dtoClass);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}


        ////function
        ////add a race entry and link it to the given user
        //[HttpPost("addRace")]
        //public IActionResult AddRace([FromBody] OrchidServer.DTO.Race item)
        //{
        //    try
        //    {
        //        HttpContext.Session.Clear(); //Logout any previous login attempt

        //        //Create model user Race
        //        Models.Race modelsRace = item.GetModel();

        //        context.Races.Add(modelsRace);
        //        context.SaveChanges();

        //        //User was added!
        //        DTO.Race dtoRace = new DTO.Race(modelsRace);
        //        return Ok(dtoRace);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

        ////function
        ////add a race entry and link it to the given user
        //[HttpPost("addSkills")]
        //public IActionResult AddSkills([FromBody] (OrchidServer.DTO.Character character, OrchidServer.DTO.ProficienciesSkill skills) tuple)
        //{
        //    try
        //    {
        //        HttpContext.Session.Clear(); //Logout any previous login attempt

        //        //Create model user Race
        //        Models.Character modelsCharacter = tuple.character.GetModel();
        //        Models.ProficienciesSkill modelSkills = tuple.skills.GetModel();



        //        context.ProficienciesSkills.Add(modelSkills);
        //        context.SaveChanges();

        //        //User was added!
        //        DTO.ProficienciesSkill dtoskills = new DTO.ProficienciesSkill(modelSkills);
        //        return Ok(dtoskills);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

        //function
        //remove skills table on the given character
        //[HttpPost("removeSkills")]
        //public IActionResult RemoveSkills([FromBody] DTO.Character character)
        //{
        //    try
        //    {
        //        HttpContext.Session.Clear(); //Logout any previous login attempt
        //        //Create model user class
        //        Models.Character modelsCharacter = character.GetModel();
        //        context.RemoveSkills(modelsCharacter);
        //        //context.SaveChanges(); //is redundent with delete it does that anyway

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

        ////function
        ////remove every class table on the given character
        //[HttpPost("removeClasses")]
        //public IActionResult RemoveClasses([FromBody] OrchidServer.DTO.Character character)
        //{
        //    try
        //    {
        //        HttpContext.Session.Clear(); //Logout any previous login attempt

        //        Models.Character modelsCharacter = character.GetModel();
        //        context.RemoveAllClasses(modelsCharacter);

        //        //context.SaveChanges(); //is redundent with delete it does that anyway

        //        //User was added!
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}


        ////function
        ////remove race table on the given character
        //[HttpPost("removeRace")]
        //public IActionResult RemoveRace([FromBody] OrchidServer.DTO.Character character)
        //{
        //    try
        //    {
        //        HttpContext.Session.Clear(); //Logout any previous login attempt

        //        Models.Character modelsCharacter = character.GetModel();
        //        context.RemoveRace(modelsCharacter);

        //        //context.SaveChanges(); //is redundent with delete it does that anyway

        //        //User was added!
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

        //function
        //store a Character as jason ind index it with the same index as the cheracter in the db

        [HttpPost("storeCharacter")]
        public IActionResult StoreCharacter([FromBody] ExpandoObject ch)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt
                dynamic temp = ch;
                dynamic Character = temp.character;
                var Cid = temp.Cid;
                var Uid = temp.Uid;


                string json = JsonSerializer.Serialize(ch);

                //write string to file
                System.IO.File.WriteAllText($"{this.webHostEnvironment.WebRootPath}\\Characters\\u{Uid}c{Cid}.json", json);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //function
        //get all Character that belong to a given User ID as expandobjects
        [HttpPost("getAllDynamicCharacters")]
        public IActionResult getAllDynamicCharacters([FromBody] DTO.AppUser user)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt
                Models.AppUser appUser = user.GetModel();
                List<Models.Character>? ModelCharacters = context.GetAllCharacters(appUser);
                int Uid = user.Id;
                List<dynamic> characters = [];


                foreach (Models.Character item in ModelCharacters)
                {
                    characters.Add(System.IO.File.ReadAllText($"{this.webHostEnvironment.WebRootPath}\\Characters\\u{Uid}c{item.Id}.json"));
                }

                return Ok(characters);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //function
        //store a Character as jason ind index it with the same index as the cheracter in the db
        [HttpPost("getDynamicCharacter")]
        public IActionResult GetDynamicCharacter([FromBody] ExpandoObject ch)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt
                dynamic temp = ch;
                var Cid = temp.Cid;
                var Uid = temp.Uid;


                string json = JsonSerializer.Serialize(ch);

                //read string from file
                return Ok(System.IO.File.ReadAllText($"{this.webHostEnvironment.WebRootPath}\\Characters\\u{Uid}c{Cid}.json"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //function
        //store a Character as jason ind index it with the same index as the cheracter in the db
        [HttpPost("getJsonCharacter")]
        public IActionResult GetJsonCharacter([FromBody] ExpandoObject ch)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt
                dynamic temp = ch;
                var Cid = temp.Cid;
                var Uid = temp.Uid;


                string json = JsonSerializer.Serialize(ch);

                //read string from file
                return Ok(System.IO.File.ReadAllText($"{this.webHostEnvironment.WebRootPath}\\Characters\\u{Uid}c{Cid}.json"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //function
        //Get the Id of a user that has a given character
        [HttpPost("getUserId")]
        public IActionResult GetUserId([FromBody] OrchidServer.DTO.Character character)
        {
            try
            {
                HttpContext.Session.Clear();

                Models.Character appUser = character.GetModel();
                int Uid = context.GetUserId(appUser);
                return Ok(Uid);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("updateCharFilters")]
        public IActionResult UpdateCharFilters([FromBody] OrchidServer.DTO.ChPlusFilters chFDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Create model user class
                DTO.Character chDto = chFDto.Character;
                List<DTO.Filter> filters = chFDto.Filters;
                List<int> FiltersIds = new();
                foreach (var item in filters)
                {
                    FiltersIds.Add(item.Id);
                }


                foreach (int filterId in FiltersIds)
                {
                    var existingRelation = context.FiltersToCharacters
                        .FirstOrDefault(ftc => ftc.CharacterId == chDto.Id && ftc.FilterId == filterId);

                    if (existingRelation == null)
                    {
                        var dto = new DTO.FiltersToCharacter
                        {
                            CharacterId = chDto.Id,
                            FilterId = filterId
                        };

                        // Convert DTO to model and add to context
                        var model = dto.GetModel();
                        context.FiltersToCharacters.Add(model);
                    }
                }
                    context.SaveChanges();

                    //context.Characters.Where(x => x.Id == chDto.Id).FirstOrDefault().FiltersToCharacters.Add(context.Filters);

                    //context.AppUsers.Update(modelsUser);
                    //context.SaveChanges();

                    //User was added!
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("unbanUser")]
        public IActionResult UnbanUser([FromBody] OrchidServer.DTO.AppUser userDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Create model user class
                userDto.IsBanned = false;
                Models.AppUser modelsUser = userDto.GetModel();

                context.AppUsers.Update(modelsUser);
                context.SaveChanges();

                //User was added!
                return Ok(modelsUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("banUser")]
        public IActionResult BanUser([FromBody] OrchidServer.DTO.AppUser userDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Create model user class
                userDto.IsBanned = true;
                Models.AppUser modelsUser = userDto.GetModel();

                context.AppUsers.Update(modelsUser);
                context.SaveChanges();

                //User was added!
                return Ok(modelsUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("getBanReason")]
        public IActionResult GetBanReason([FromBody] OrchidServer.DTO.AppUser userDto)
        {
            try
            {
                HttpContext.Session.Clear();
                Models.AppUser modelsUser = userDto.GetModel();

                return Ok(context.GetBanReason(modelsUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("getAppeal")]
        public IActionResult GetAppeal([FromBody] OrchidServer.DTO.AppUser userDto)
        {
            try
            {
                HttpContext.Session.Clear();
                Models.AppUser modelsUser = userDto.GetModel();
                return Ok(context.GetAppeal(modelsUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("setAppeal")]
        public IActionResult SetAppeal([FromBody] OrchidServer.DTO.Appeal appealDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Create model user class
                Models.Appeal modelsAppeal = appealDto.GetModel();

                context.Appeals.Where(x => x.UserId == appealDto.UserId).ExecuteDelete();
                context.Appeals.Add(modelsAppeal);
                context.SaveChanges();

                //User was added!
                DTO.Appeal dtoAppealDto = new DTO.Appeal(modelsAppeal);
                return Ok(dtoAppealDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("setBanReason")]
        public IActionResult SetBanReason([FromBody] OrchidServer.DTO.BanReason banReasonDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Create model user class
                Models.BanReason modelsbanReason = banReasonDto.GetModel();

                context.BanReasons.Where(x => x.UserId == banReasonDto.UserId).ExecuteDelete();
                context.BanReasons.Add(modelsbanReason);
                context.SaveChanges();

                //User was added!
                DTO.BanReason dtobanReason = new DTO.BanReason(modelsbanReason);
                return Ok(dtobanReason);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("getBannedUsers")]
        public IActionResult GetBannedUsers()
        {
            try
            {
                HttpContext.Session.Clear();


                List<Models.AppUser>? Modelusers = context.GetAllUsersC().Where(x => x.IsBanned == true).ToList();
                List<DTO.AppUser> Dtousers = new List<DTO.AppUser>();
                List<Models.Appeal> appeals = context.GetAllAppeals();
                List<Models.AppUser> usersWithAppeals = Modelusers
                .Where(user => appeals.Any(appeal => appeal.UserId == user.Id))
                .ToList();


                foreach (Models.AppUser user in usersWithAppeals)
                {
                    DTO.AppUser placeholderuser = new(user);
                    Dtousers.Add(placeholderuser);
                }
                return Ok(Dtousers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("deleteCharacter")]
        public IActionResult DeleteCharacter([FromBody] OrchidServer.DTO.Character charDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Create model user class
                Models.Character modelsCharacter = charDto.GetModel();
                System.IO.File.Delete($"{this.webHostEnvironment.WebRootPath}\\Characters\\u{charDto.UserId}c{charDto}.json");


                context.Characters.Remove(modelsCharacter);
                context.SaveChanges();

                //User was added!
                return Ok(modelsCharacter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("getAllCharacters")]
        public IActionResult GetAllCharacters()
        {
            try
            {
                HttpContext.Session.Clear();


                List<Models.Character>? Modelcharacters = context.GetAllCharactersA();
                List<DTO.Character> Dtocharacters = new List<DTO.Character>();


                foreach (Models.Character character in Modelcharacters)
                {
                    DTO.Character placeholderuser = new(character);
                    Dtocharacters.Add(placeholderuser);
                }
                return Ok(Dtocharacters);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

