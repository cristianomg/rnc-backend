using _4lab.Ocurrences.Application.DTOs;
using _4lab.Ocurrences.Domain.Interfaces;
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
    public class NonComplianceController : ControllerBase
    {
        private readonly INonComplianceRepository _nonComplianceRepository;
        private readonly IMapper _mapper;

        public NonComplianceController(INonComplianceRepository nonComplianceRepository,
                                            IMapper mapper)
        {
            _nonComplianceRepository = nonComplianceRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint reponsavel por trazer as não conformidades
        /// </summary>
        /// <param name="nonComplianceTypeId"></param>
        /// <returns></returns>
        [HttpGet("{nonComplianceTypeId}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetNonCompliances(DtoNonComplianceType nonComplianceTypeId)
        {
            var nonCompliances = _nonComplianceRepository.GetByTypeNonCompliance((int)nonComplianceTypeId);
            return await Task.FromResult(Ok(_mapper.ProjectTo<DtoNonCompliance>(nonCompliances)));
        }
    }
}
