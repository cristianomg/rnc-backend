using _4lab.Occurrences.Domain.Interfaces;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using System;

namespace _4lab.Occurrences.Data.Repositories
{
    public class ActionPlainQuestionRepository : BaseRepository<ActionPlainQuestion, Guid>, IActionPlainQuestionRepository
    {
        public ActionPlainQuestionRepository(OccurrencesContext context) : base(context)
        {

        }
    }
}
