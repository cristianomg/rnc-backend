using _4lab.Administration.Application.DTOs;
using _4lab.Administration.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public AuthController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        /// <summary>
        /// Endpoint responsável por realizar login
        /// </summary>
        /// <param name="authInput"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DtoCreateAuthResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] DtoCreateAuthInput authInput)
        {
            try
            {
                var createAuthResponse = await _userAppService.CreateAuth(authInput);

                if (createAuthResponse != null)
                    return Ok(createAuthResponse);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
