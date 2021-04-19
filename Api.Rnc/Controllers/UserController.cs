using Api.Rnc.Extensions;
using AutoMapper;
using Domain.Dtos.Helps;
using Domain.Dtos.Inputs;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserService _createUserService;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IChangePasswordService _changePasswordService;
        private readonly IChangeNameService _changeNameService;
        public UserController(ICreateUserService createUserService,
                              IMapper mapper,
                              IUserRepository userRepository,
                              IChangePasswordService changePasswordService,
                              IChangeNameService changeNameService)
        {
            _createUserService = createUserService;
            _mapper = mapper;
            _userRepository = userRepository;
            _changePasswordService = changePasswordService;
            _changeNameService = changeNameService;
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
            var createUserServiceResponse = await _createUserService.Execute(dtoCreateUser);
            if (createUserServiceResponse.Success)
                return Ok();
            else
                return BadRequest(createUserServiceResponse.Message);
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
            var users = await _userRepository.GetAllDontActive();
            return Ok(_mapper.ProjectTo<DtoUserActive>(users));
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
            var user = await _userRepository.GetByEmail(email);
            return Ok(_mapper.Map<DtoUserResponse>(user));
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
            await _userRepository.ActiveUser(email);
            return Ok();
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
            await _userRepository.DeleteUserByEmail(email);
            return Ok();
        }
        ///<summary>
        ///Endpoint responsável por torcar senha do usuário
        /// </summary>
        [HttpPut("ChancePassword")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ChangePassword([FromBody]DtoChangePassword dtoChangePassword)
        {
            var responseService = await _changePasswordService.Execute(dtoChangePassword);
            if (responseService.Success)
                return Ok();

            return BadRequest(responseService.Message);
        }
        ///<summary>
        ///Endpoint responsável por torcar nome do usuário
        /// </summary>
        [HttpPut("ChangeName")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ChangeName([FromBody] DtoChangeNameInput dtoChangeName)
        {
            var userId = User.GetUserId();
            var responseService = await _changeNameService.Execute(userId, dtoChangeName);
            if (responseService.Success)
                return Ok();

            return BadRequest(responseService.Message);
        }
    }
}
