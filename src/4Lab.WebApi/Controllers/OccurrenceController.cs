using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Domain.Interfaces;
using _4Lab.Core.DomainObjects.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OccurrenceController : ControllerBase
    {
        private readonly IOccurrenceRepository _occurrenceRepository;
        private readonly IMapper _mapper;

        public OccurrenceController(IOccurrenceRepository occurrenceRepository
                                   , IMapper mapper)
        {
            _occurrenceRepository = occurrenceRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint reponsavel por trazer as ocorrencias
        /// </summary>
        /// <param name="occurrenceType"></param>
        /// <returns></returns>
        [HttpGet("{occurrenceType}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetNonCompliances(OccurrenceType occurrenceType)
        {
            var occurrences = await _occurrenceRepository.GetByOccurrenceType(occurrenceType);

            return Ok(_mapper.ProjectTo<DtoOccurrence>(occurrences));
        }
    }
}
