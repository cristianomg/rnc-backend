using _4lab.Administration.Application.Service;
using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Application.Service;
using _4Lab.Core.DomainObjects.Enums;
using Api.Rnc.Extensions;
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
        private readonly ISetorAppService _setorAppService;
        private readonly IUserAppService _userAppService;

        public SetorController(ISetorAppService setorAppService, IUserAppService userAppService)
        {
            _setorAppService = setorAppService;
            _userAppService = userAppService;
        }

        /// <summary>
        /// Endpoint responsável por retornar os setores
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<DtoSetor>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllSetors()
        {
            var setors = await _setorAppService.GetAllSetor();
            return Ok(setors);
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetSupervisorOnSetor(DtoSetSupervisor setSupervisor)
        {
            setSupervisor.UserName = User.GetUserName();

            var setor = await _setorAppService.GetById(setSupervisor.SetorId);

            if (setor == null)
                return BadRequest("Setor não encontrado.");

            var user = await _userAppService.GetByEmail(setSupervisor.UserEmail);

            if (user == null)
                return BadRequest("Usuário não encontrado.");

            if (user.UserPermissionId != UserPermissionType.ResponsibleFS &&
                user.UserPermissionId != UserPermissionType.ResponsibleT)
                return BadRequest("Usuário não é um supervisor.");

            setor.SupervisorId = user.Id;
            setor.UpdatedBy = setSupervisor.UserName;

            await _setorAppService.Update(setor);

            return Ok();
        }
    }
}
