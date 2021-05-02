using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Rnc.Repositories
{
    public class ActionPlainQuestionRepository : BaseRepository<ActionPlainQuestion, int>, IActionPlainQuestionRepository
    {
        public ActionPlainQuestionRepository(RncContext context) : base(context)
        {

        }
    }
}
