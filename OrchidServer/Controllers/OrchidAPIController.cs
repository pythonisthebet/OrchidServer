using Microsoft.AspNetCore.Mvc;
using OrchidServer.Models;
using Microsoft.AspNetCore.Http;
using OrchidServer.DTO;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        [HttpPost("getAllClasses")]
        public IActionResult GetAllClasses([FromBody] OrchidServer.DTO.Character character)
        {
            try
            {
                HttpContext.Session.Clear();

                Models.Character modelCharacter = character.GetModel();
                List<Models.Class>? ModelClasses = context.GetAllClasses(modelCharacter);
                List<DTO.Class> DtoClasses = new List<DTO.Class>();


                foreach (Models.Class item in ModelClasses)
                {
                    DTO.Class placeholderClass = new(item);
                    DtoClasses.Add(placeholderClass);
                }
                return Ok(DtoClasses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("getRace")]
        public IActionResult GetRace([FromBody] OrchidServer.DTO.Character character)
        {
            try
            {
                HttpContext.Session.Clear();

                Models.Character modelCharacter = character.GetModel();
                Models.Race? ModelRace = context.GetRace(modelCharacter);
                DTO.Race DtoRace = new DTO.Race();

                DTO.Race race = new(ModelRace);

                return Ok(race);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #region Add

        [HttpPost("addClass")]
        public IActionResult AddClass([FromBody] OrchidServer.DTO.Class item)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Create model user class
                Models.Class modelsClass = item.GetModel();

                context.Classes.Add(modelsClass);
                context.SaveChanges();

                //User was added!
                DTO.Class dtoClass = new DTO.Class(modelsClass);
                return Ok(dtoClass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("addRace")]
        public IActionResult AddRace([FromBody] OrchidServer.DTO.Race item)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Create model user Race
                Models.Race modelsRace = item.GetModel();

                context.Races.Add(modelsRace);
                context.SaveChanges();

                //User was added!
                DTO.Race dtoRace = new DTO.Race(modelsRace);
                return Ok(dtoRace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

        #region delete

        [HttpPost("removeClasses")]
        public IActionResult RemoveClasses([FromBody] OrchidServer.DTO.Character character)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                Models.Character modelsCharacter = character.GetModel();
                context.RemoveAllClasses(modelsCharacter);

                //context.SaveChanges(); //is redundent with delete it does that anyway

                //User was added!
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("removeRace")]
        public IActionResult RemoveRace([FromBody] OrchidServer.DTO.Character character)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                Models.Character modelsCharacter = character.GetModel();
                context.RemoveRace(modelsCharacter);

                //context.SaveChanges(); //is redundent with delete it does that anyway

                //User was added!
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

    }
}

