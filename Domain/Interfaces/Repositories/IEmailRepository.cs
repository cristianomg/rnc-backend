using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IEmail
    {
        IQueryable<NaoConformidade> GetByIdEmail(int IdEmail);
    }
}
