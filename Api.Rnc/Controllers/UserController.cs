using Domain.Dtos.Requests;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserService _createUserService;
        public UserController(ICreateUserService createUserService)
        {
            _createUserService = createUserService;
        }
        /// <summary>
        /// Endpoint responsável pela criação do usuário
        /// </summary>
        /// <param name="dtoCreateUser"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] DtoCreateUserInput dtoCreateUser)
        {
            var createUserServiceResponse = await _createUserService.Execute(dtoCreateUser);
            if (createUserServiceResponse.Success)
                return Ok();
            else
                return BadRequest(createUserServiceResponse.Message);
        }
    }
}
