using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Interfaces.Repositories;
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
    public class SetorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISetorRepository _setorRepository;
        public SetorController(IMapper mapper, ISetorRepository setorRepository)
        {
            _mapper = mapper;
            _setorRepository = setorRepository;
        }
        /// <summary>
        /// Endpoint responsável por retornar os setores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<DtoSetor>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllDontActive()
        {
            var users = await _setorRepository.GetAllSetor();
            return Ok(_mapper.ProjectTo<DtoSetor>(users));
        }
    }
}
