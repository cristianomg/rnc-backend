using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Domain.Interfaces;
using AutoMapper;
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
    public class OccurrenceRiskController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOccurrenceRiskRepository _occurrenceRiskRepository;

        public OccurrenceRiskController(IMapper mapper
                                        , IOccurrenceRiskRepository occurrenceRiskRepository)
        {
            _mapper = mapper;
            _occurrenceRiskRepository = occurrenceRiskRepository;

        }
        /// <summary>
        /// Endpoint responsável por retornar os setores
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<DtoOccurrenceRisk>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllRisks()
        {
            var risks = await _occurrenceRiskRepository.GetAllRisks();
            return Ok(_mapper.ProjectTo<DtoOccurrenceRisk>(risks));
        }
    }
}
