using AutoMapper;
using Domain.Dtos.Responses;
using Domain.Interfaces.Repositories;
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
    public class ActionPlainController : ControllerBase
    {
        private readonly IActionPlainRepository _actionPlainRepository;
        private readonly IMapper _mapper;
        public ActionPlainController(IActionPlainRepository actionPlainRepository, IMapper mapper)
        {
            _actionPlainRepository = actionPlainRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Endpoint responsável por listar os planos de ação existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<DtoActionPlainListResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.ProjectTo<DtoActionPlainListResponse>(await _actionPlainRepository.GetAll()));
        }
        /// <summary>
        /// Endpoint responsável por detalhar um plano de ação pelo id do mesmo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(DtoActionPlainDetailResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<DtoActionPlainDetailResponse>(await _actionPlainRepository.GetByIdWithIncludes(id)));
        }
    }
}
