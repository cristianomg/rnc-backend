using _4lab.Ocurrences.Domain.Interfaces;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;

namespace _4lab.Ocurrences.Data.Repositories
{
    public class ActionPlainQuestionRepository : BaseRepository<ActionPlainQuestion, int>, IActionPlainQuestionRepository
    {
        public ActionPlainQuestionRepository(OcurrencesContext context) : base(context)
        {

        }
    }
}
