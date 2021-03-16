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
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IQueryable<DtoUserAtivo> ObterTodos()
        {
            return _mapper.ProjectTo<DtoUserAtivo>(_userRepository.ObterTodos());
        }
        [AllowAnonymous]
        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AtivarCadastro(DtoUserAtivo userAut)
        {
            await _userRepository.AtivarCadastro(_mapper.Map<User>(userAut));
            return Ok(); ;
        }
    }
}
