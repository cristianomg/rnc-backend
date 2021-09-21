using _4lab.Ocurrences.Application.DTOs;
using _4lab.Ocurrences.Application.Service;
using _4lab.Ocurrences.Domain.Interfaces;
using Api.Rnc.Extensions;
using AutoMapper;
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
    public class ActionPlainController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IActionPlainRepository _actionPlainRepository;
        private readonly IOcurrenceAppService _ocurrenceAppService;

        public ActionPlainController(IActionPlainRepository actionPlainRepository, IMapper mapper, IOcurrenceAppService ocurrenceAppService)
        {
            _actionPlainRepository = actionPlainRepository;
            _mapper = mapper;
            _ocurrenceAppService = ocurrenceAppService;
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
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(DtoActionPlainDetailResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(_mapper.Map<DtoActionPlainDetailResponse>(await _actionPlainRepository.GetByIdWithIncludes(id)));
        }

        /// <summary>
        /// Endpoint responsável criar um novo plano de ação
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DtoActionPlainDetailResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] DtoCreateActionPlainInput dto)
        {
            try
            {
                dto.UserName = User.GetUserName();

                var responseService = await _ocurrenceAppService.CreateActionPlain(dto);
                if (responseService)
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
