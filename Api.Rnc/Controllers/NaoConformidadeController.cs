using AutoMapper;
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
        public NaoConformidadeController(INaoConformidadeRepository naoConformidadeRepository)
        {
            _naoConformidadeRepository = naoConformidadeRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<ActionResult>> ObterNaoConformidades(int id)
        {
            return (IEnumerable<ActionResult>)await _naoConformidadeRepository.GetByTipoNaoConformidade(id);
        }
    }
}
