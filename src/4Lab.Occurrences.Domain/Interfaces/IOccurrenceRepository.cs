using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using System;

namespace _4lab.Occurrences.Domain.Interfaces
{
    public interface IOccurrenceRepository : IBaseRepository<Occurrence, Guid>
    {
    }
}
