using API.Models.DataBase.Tables;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using MotoTuneAPI;

namespace API.Controllers
{
    public class UserController : APIController
    {
        private readonly ILogger<UserController> _logger;
        public UserController ( ILogger<UserController> logger )
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<User> GetUserById ( int userId)
        {
            return Ok(context.Users.FirstOrDefault(x=>x.UsrId == userId));
        }

    }
}
