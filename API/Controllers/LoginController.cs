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
        public IEnumerable<User> GetUsers ( )
        {
            return context.Users.ToList();
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<User> Login (string pin,string workerNumber)
        {
            var user = context.Users.FirstOrDefault(x=>x.UsrWorkerPin == pin && x.UsrWorkerNumber == workerNumber);
           
            if(user != null) 
                return Ok(user);
            return NotFound(User);
        }
    }
}
