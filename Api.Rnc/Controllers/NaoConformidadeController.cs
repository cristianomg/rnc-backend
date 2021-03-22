using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos.Helps;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NaoConformidadeController : ControllerBase
    {
        private readonly INaoConformidadeRepository _naoConformidadeRepository;
        private readonly IMapper _mapper;
        public NaoConformidadeController(INaoConformidadeRepository naoConformidadeRepository,
                                            IMapper mapper)
        {
            _naoConformidadeRepository = naoConformidadeRepository;
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
        public async Task<IActionResult> ObterNaoConformidades(DtoNonComplianceType nonComplianceTypeId)
        {
            var naoConformidades = _naoConformidadeRepository.GetByTipoNaoConformidade((int)nonComplianceTypeId);
            return await Task.FromResult(Ok(_mapper.ProjectTo<DtoNaoConformidade>(naoConformidades)));
        }
    }
}
