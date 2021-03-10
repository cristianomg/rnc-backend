using AutoMapper;
using Domain.Dtos.Inputs;
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
        private readonly IEsqueciSenha _esqueciSenha;
        private readonly IMapper _mapper;
        public EsqueciSenhaController(IEsqueciSenha esqueciSenha, IMapper mapper)
        {
            _esqueciSenha = esqueciSenha;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EsqueciSenha(string email)
        {
            await _esqueciSenha.SendEmail(email);
            return Ok();
        }
    }
}
