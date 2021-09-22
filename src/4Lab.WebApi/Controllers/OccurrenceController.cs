using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Domain.Interfaces;
using _4Lab.Core.DomainObjects.Enums;
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
            try
            {
                var occurrences = await _occurrenceRepository.GetByOccurrenceType(occurrenceType);
                var teste2 = _mapper.Map<DtoOccurrence>(occurrences.ToList().ElementAt(0));
                var teste = _mapper.ProjectTo<DtoOccurrence>(occurrences);
                return Ok(teste);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default;
            }

        }
    }
}
