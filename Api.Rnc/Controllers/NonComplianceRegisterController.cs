using Api.Rnc.Extensions;
using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ValueObjects;
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
    public class NonComplianceRegisterController : ControllerBase
    {
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        private readonly IMapper _mapper;
        private readonly ICreateNonComplianceRegisterService _createNonComplianceRegisterService;
        public NonComplianceRegisterController(INonComplianceRegisterRepository nonComplianceRegisterRepository,
                                               IMapper mapper,
                                               ICreateNonComplianceRegisterService createNonComplianceRegisterService)
        {
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _mapper = mapper;
            _createNonComplianceRegisterService = createNonComplianceRegisterService;
        }
        /// <summary>
        /// Endpoint responsável por inserir um registro de não conformidade.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DtoNonComplianceRegisterResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody] DtoNonComplianceRegisterInput dto)
        {
            var responseService = await _createNonComplianceRegisterService.Execute(User.GetUserId(), dto);
            if (responseService.Success)
                return Created("{id}", _mapper.Map<DtoNonComplianceRegisterResponse>(responseService.Value));
            return BadRequest(responseService.Message);
        }
        /// <summary>
        /// Endpoint responsável por trazer as não conformidades registradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<DtoNonComplianceRegisterResponse>), StatusCodes.Status200OK)]
        [Authorize(Roles = nameof(UserPermissionType.Supervisor) + "," + nameof(UserPermissionType.QualityBiomedical))]
        public async Task<IActionResult> GetAll()
        {
            var nonComplianceRegisters = await _nonComplianceRegisterRepository.GetAllWithIncludes(nameof(NonComplianceRegister.User), nameof(NonComplianceRegister.Setor));
            nonComplianceRegisters.OrderBy(x=>x.Id);
            return Ok(_mapper.ProjectTo<DtoNonComplianceRegisterResponse>(nonComplianceRegisters));
        }
        /// <summary>
        /// Endpoint responsável por trazer as não conformidades registradas por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DtoNonComplianceRegisterResponse), StatusCodes.Status200OK)]
        [Authorize(Roles = nameof(UserPermissionType.Supervisor) + "," + nameof(UserPermissionType.QualityBiomedical))]
        public async Task<IActionResult> GetById(int id)
        {
            var nonComplianceRegister = await _nonComplianceRegisterRepository.GetByIdWithInclude(id);

            return Ok(_mapper.Map<DtoNonComplianceRegisterResponse>(nonComplianceRegister));
        }
    }
}
