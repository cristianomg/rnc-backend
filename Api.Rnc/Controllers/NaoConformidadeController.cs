using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/v1/[controller]")]
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
        [HttpGet]
        public virtual async Task<IEnumerable<DtoNaoConformidade>> ObterNaoConformidades(int id)
        {
            return _mapper.Map<IEnumerable<DtoNaoConformidade>>(await _naoConformidadeRepository.GetByTipoNaoConformidade(id));
        }
    }
}
