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

        [HttpPut]
        [Route("[action]")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult AddUser ( [FromQuery] string login,string password)
        {
            context.Users.Add(new User
            {
                UsrLogin = login,
                UsrPassword = password,
                UsrDate = DateTime.Now
            });

            context.SaveChanges();

            return Ok() ;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<User> GetUsers ( )
        {
            return context.Users.ToList(); ;
        }
    }
}
