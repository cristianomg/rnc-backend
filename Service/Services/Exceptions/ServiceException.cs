using System;

namespace Service.Services.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string msg) : base(msg)
        {
        
        }
    }
}
