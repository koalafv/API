using API.Models.DataBase.Tables;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using MotoTuneAPI.Controllers;
using MotoTuneAPI;

namespace API.Controllers
{
    public class MessagesController : APIController
    {
        private readonly ILogger<MessagesController> _logger;

        public MessagesController ( ILogger<MessagesController> logger )
        {
            _logger = logger;
        }

        [HttpPut]
        [Route("[action]")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult PutMessage (string text, int usrId )
        {
            context.Messages.Add(new Messages
            {
                DateCreated = DateTime.Now,
                Text = text,
                UserId = usrId
            });
            context.SaveChanges();
            
            return Ok();
        }
    }
}
