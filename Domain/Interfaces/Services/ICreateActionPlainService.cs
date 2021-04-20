﻿using Domain.Dtos.Inputs;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICreateActionPlainService : IService
    {
        Task<ResponseService> Execute(DtoCreateActionPlainInput dto);
    }
}