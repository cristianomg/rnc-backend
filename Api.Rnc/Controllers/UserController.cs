using AutoMapper;
using Domain.Dtos.Helps;
using Domain.Dtos.Requests;
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
        public UserController(ICreateUserService createUserService, IMapper mapper, IUserRepository userRepository)
        {
            _createUserService = createUserService;
            _mapper = mapper;
            _userRepository = userRepository;
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
        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<DtoUserActive>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllDontActive()
        {
            var users =  await _userRepository.GetAllDontActive();
            return Ok(_mapper.ProjectTo<DtoUserActive>(users));
        }
        /// <summary>
        /// Endpoint responsável por aprovar cadastros
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ApproveUser(string email)
        {
            await _userRepository.ActiveUser(email);
            return Ok();
        }
    }
}
