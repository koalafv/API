using API.Models.DataBase.Tables;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using MotoTuneAPI.Controllers;
using MotoTuneAPI;
using System.Reflection.Metadata.Ecma335;

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

        [HttpGet]
        [Route("[action]")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Messages> GetMessage()
        {
            return Ok(context.Messages.OrderByDescending(o=>o.MessId).FirstOrDefault());
        }

        [HttpPut]
        [Route("[action]")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult PutReadedMessageForUser(int userId,int messageId)
        {
            context.ReadedMessages.Add(new ReadedMessages
            {
                Rmess_messId = messageId,
                Rmess_usrId = userId
            });
            context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> GetUserReadedMessage(int userId, int messageId)
        {
            if(context.ReadedMessages.Any(x=>x.Rmess_messId == messageId && x.Rmess_usrId == userId))
                return Ok(true);
            return Ok(false);
        }
    }
}
