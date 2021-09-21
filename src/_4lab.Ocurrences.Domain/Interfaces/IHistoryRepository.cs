using _4Lab.Core.Audit;
using _4Lab.Core.Data;
using System;

namespace _4lab.Ocurrences.Domain.Interfaces
{
    public interface IHistoryRepository : IBaseRepository<Historic, Guid> { }
}
