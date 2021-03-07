using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public virtual async Task<IEnumerable<DtoNaoConformidade>> ObterNaoConformidades(int id)
        {
            return _mapper.Map<IEnumerable<DtoNaoConformidade>>(await _naoConformidadeRepository.GetByTipoNaoConformidade(id));
        }
    }
}
