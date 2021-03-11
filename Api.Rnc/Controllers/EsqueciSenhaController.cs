using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
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
        [HttpGet]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EsqueciSenha(string email)
        {
            await _recoveryPasswordService.Execute(email);
            return Ok();
        }
    }
}
