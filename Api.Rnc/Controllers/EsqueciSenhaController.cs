using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgetPasswordController : ControllerBase
    {
        private readonly IRecoveryPasswordService _recoveryPasswordService;

        public ForgetPasswordController(IRecoveryPasswordService recoveryPasswordService)
        {
            _recoveryPasswordService = recoveryPasswordService;
        }
        /// <summary>
        /// Endpoint responsável pelo esqueci a senha
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPut("{email}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var responseService = await _recoveryPasswordService.Execute(email);
            if (responseService.Success)
                return Ok();

            return BadRequest(responseService.Message);
        }
    }
}
