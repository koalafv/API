using Microsoft.AspNetCore.Mvc;
using API.Models.DataBase.Tables;

namespace MotoTuneAPI.Controllers
{
    public class LoginController : APIController
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController ( ILogger<LoginController> logger )
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string AddUser ( [FromQuery] string login, string password )
        {
            string result = "";
            
            try
            {
                if (context.Users.Any(x => x.UsrLogin.Equals(login)))
                    return "Exist";

                context.Users.Add(new User
                {
                    UsrLogin = login,
                    UsrPassword = password,
                    UsrDate = DateTime.Now
                });

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<User> GetUsers ( )
        {
            return context.Users.ToList();
        }
    }
}
