using Microsoft.EntityFrameworkCore;

namespace Data.Rnc.Context
{
    public sealed class RncContext: DbContext
    {
        public RncContext(DbContextOptions<RncContext> options) : base(options) { }

    }
}
