using _4lab.Occurrences.Domain.Interfaces;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace _4lab.Occurrences.Data.Repositories
{
    public class OccurrenceRepository : BaseRepository<Occurrence, Guid>, IOccurrenceRepository
    {
        private readonly DbSet<Occurrence> _dbSet;
        public OccurrenceRepository(OccurrencesContext context) : base(context)
        {
            _dbSet = context.Occurrences;
        }
    }
}
