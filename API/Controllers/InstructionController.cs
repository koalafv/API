using API.Models.DataBase.Tables;
using Microsoft.AspNetCore.Mvc;
using MotoTuneAPI;
using MotoTuneAPI.Controllers;

namespace API.Controllers
{
    public class InstructionController : APIController
    {
        private readonly ILogger<InstructionController> _logger;

        public InstructionController ( ILogger<InstructionController> logger )
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<Instruction> GetInstruction ( )
        {
            return context.Instruction.ToList();
        }
    }
}
