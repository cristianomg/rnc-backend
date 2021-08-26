using Api.Rnc.Extensions;
using AutoMapper;
using Domain.Dtos.Inputs;
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
    public class SetorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISetorRepository _setorRepository;
        private readonly ISetSupervisorOnSetorService _setSupervisorOnSetorService;
        public SetorController(IMapper mapper,
                               ISetorRepository setorRepository,
                               ISetSupervisorOnSetorService setSupervisorOnSetorService)
        {
            _mapper = mapper;
            _setorRepository = setorRepository;
            _setSupervisorOnSetorService = setSupervisorOnSetorService;

        }
        /// <summary>
        /// Endpoint responsável por retornar os setores
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<DtoSetor>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllSetors()
        {
            var users = await _setorRepository.GetAllSetor();
            return Ok(_mapper.ProjectTo<DtoSetor>(users));
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetSupervisorOnSetor(DtoSetSupervisor setSupervisor)
        {
            setSupervisor.UserName = User.GetUserName();

            var responseService = await _setSupervisorOnSetorService.Execute(setSupervisor);
            if (responseService.Success)
                return Ok();

            return BadRequest(responseService.Message);
        }
    }
}
