using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EsqueciSenhaController : ControllerBase
    {
        private readonly IRecoveryPasswordService _recoveryPasswordService;

        public EsqueciSenhaController(IRecoveryPasswordService recoveryPasswordService)
        {
            _recoveryPasswordService = recoveryPasswordService;
        }
        [HttpPost("{email}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EsqueciSenha(string email)
        {
            var responseService = await _recoveryPasswordService.Execute(email);
            if (responseService.Success)
                return Ok();

            return BadRequest(responseService.Message);
        }
    }
}
