using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using System;

namespace _4Lab.Archives.Domain.Interfaces
{
    public interface IArchiveRepository : IBaseRepository<Archive, Guid>
    {
    }
}
