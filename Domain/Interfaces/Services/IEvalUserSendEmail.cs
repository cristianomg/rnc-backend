using Domain.Models.Helps;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IEvalUserSendEmail
    {
        Task<ResponseService> Approved(string email);
        Task<ResponseService> Disapproved(string email);
    }
}
