using _4lab.Administration.Application.DTOs;
using _4lab.Administration.Application.Service;
using Api.Rnc.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        /// <summary>
        /// Endpoint responsável pela criação do usuário
        /// </summary>
        /// <param name="dtoCreateUser"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] DtoCreateUserInput dtoCreateUser)
        {
            try
            {
                var createUserServiceResponse = await _userAppService.CreateUser(dtoCreateUser);

                if (createUserServiceResponse)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint responsável por retornar os usuários com cadastro não aprovado ainda
        /// </summary>
        /// <returns></returns>
        [HttpGet("ToApprove")]
        [ProducesResponseType(typeof(IQueryable<DtoUserActive>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllDontActive()
        {
            var users = await _userAppService.GetAllDontActive();
            return Ok(users);
        }

        /// <summary>
        /// Endpoint responsável por retornar o usuário via email
        /// </summary>
        /// <returns></returns>
        [HttpGet("{email}")]
        [ProducesResponseType(typeof(DtoUser), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUser(string email)
        {
            var user = await _userAppService.GetByEmail(email);
            return Ok(user);
        }

        /// <summary>
        /// Endpoint responsável por aprovar cadastros
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPut("ApproveUser/{email}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ApproveUser(string email)
        {
            try
            {
                await _userAppService.ActiveUser(email);
                var approved = await _userAppService.Approved(email);

                if (approved)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint responsável por reprovar cadastros
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpDelete("Disapprove/{email}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Disapprove(string email)
        {
            try
            {
                await _userAppService.DeleteUserByEmail(email);
                var disapproved = await _userAppService.Disapproved(email);

                if (disapproved)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        ///<summary>
        ///Endpoint responsável por torcar senha do usuário
        /// </summary>
        [HttpPut("ChancePassword")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ChangePassword([FromBody] DtoChangePassword dtoChangePassword)
        {
            try
            {
                var responseService = await _userAppService.ChangePassword(dtoChangePassword);
                if (responseService)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        ///<summary>
        ///Endpoint responsável por torcar nome do usuário
        /// </summary>
        [HttpPut("ChangeName")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ChangeName([FromBody] DtoChangeNameInput dtoChangeName)
        {
            try
            {
                var userId = User.GetUserId();
                var changed = await _userAppService.ChangeName(userId, dtoChangeName);

                if (changed)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
