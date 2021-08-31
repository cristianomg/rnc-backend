﻿using AutoMapper;
using Domain.Dtos.Responses;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
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


            foreach (var item in nonComplianceRegister.Archives)
            {
                nonCompliance.Archives.Add(await _storageService.GetGetPreSignedURL(item.Key));
            }

            return GenerateSuccessServiceResponse(nonCompliance);
        }
    }
}
