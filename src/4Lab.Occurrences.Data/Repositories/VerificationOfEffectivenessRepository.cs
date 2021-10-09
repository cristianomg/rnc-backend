using _4lab.Occurrences.Data;
using _4Lab.Core.Data;
using _4Lab.Occurrences.Domain.Interfaces;
using _4Lab.Occurrences.Domain.Models;
using System;

namespace _4Lab.Occurrences.Data.Repositories
{
    public class VerificationOfEffectivenessRepository : BaseRepository<VerificationOfEffectiveness, Guid>, IVerificationOfEffectivenessRepository
    {
        public VerificationOfEffectivenessRepository(OccurrencesContext context) : base(context)
        {

        }
    }
}
