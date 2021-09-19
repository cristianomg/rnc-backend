using AutoMapper;
using _4lab.Ocurrences.Application.DTOs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GetNonComplieanceRegisterByIdService :  AbstractService, IGetNonComplieanceRegisterByIdService
    {
        private readonly IStorageService _storageService;
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        private readonly IMapper _mapper;
        public GetNonComplieanceRegisterByIdService(
            IStorageService storageService,
            INonComplianceRegisterRepository nonComplianceRegisterRepository,
            IMapper mapper
            )
        {
            _storageService = storageService;
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _mapper = mapper;
        }

        public async Task<ResponseService<DtoNonComplianceRegisterResponse>> Execute(int id)
        {
            var nonComplianceRegister = await _nonComplianceRegisterRepository.GetByIdWithInclude(id);

            var nonCompliance = _mapper.Map<DtoNonComplianceRegisterResponse>(nonComplianceRegister);


            foreach (var item in nonComplianceRegister.NonCompliances?.SelectMany(x=>x.Archives))
            {

                nonCompliance.NonCompliances
                    .First(x => x.Id == item.NonComplianceId)
                    .Archives.Add(await _storageService.GetGetPreSignedURL(item.Key));
            }

            return GenerateSuccessServiceResponse(nonCompliance);
        }
    }
}
