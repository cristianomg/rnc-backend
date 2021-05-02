using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Models.Helps;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SetSupervisorIdService : AbstractService
    {
        private readonly ISetorRepository _setorRepository;
        private readonly IUserRepository _userRepository;

        public SetSupervisorIdService(ISetorRepository setorRepository, IUserRepository userRepository) 
        {
            _setorRepository = setorRepository;
            _userRepository = userRepository;
        }

        public async Task<ResponseService> Execute(DtoSetSupervisor createSetor) 
        {

            var setSetor = await _setorRepository.Update(new Setor
            {

                SupervisorId = createSetor.UserId,
                Supervisor = createSetor.User,
            });

            await _setorRepository.SaveChanges();

            return GenerateSuccessServiceResponse(HttpStatusCode.Created);
        }
    }
}
