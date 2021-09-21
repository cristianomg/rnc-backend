using _4lab.Occurrences.Domain.Models;
using _4Lab.Archives.Domain.Interfaces;
using _4Lab.Core.Data;
using System;

namespace _4Lab.Archives.Data.Repositories
{
    public class ArchiveRepository : BaseRepository<Archive, Guid>, IArchiveRepository
    {
        public ArchiveRepository(ArchiveContext context) : base(context)
        {
        }
    }
}
