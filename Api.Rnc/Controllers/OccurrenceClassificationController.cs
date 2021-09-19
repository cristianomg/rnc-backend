using _4lab.Ocurrences.Application.DTOs;
using _4lab.Ocurrences.Domain.Interfaces;
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
    public class OccurrenceClassificationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOccurrenceClassificationRepository _occurrenceClassificationRepository;

        public OccurrenceClassificationController(IMapper mapper, IOccurrenceClassificationRepository occurrenceClassificationRepository)
        {
            _mapper = mapper;
            _occurrenceClassificationRepository = occurrenceClassificationRepository;

        }
        /// <summary>
        /// Endpoint responsável por retornar os setores
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<DtoOccurrenceClassification>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllClassifications()
        {
            var classifications = await _occurrenceClassificationRepository.GetAllClassification();
            return Ok(_mapper.ProjectTo<DtoOccurrenceClassification>(classifications));
        }
    }
}
