using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Rnc.Repositories
{
    public class NonComplianceRegisterRepository : BaseRepository<NonComplianceRegister>,
                                                   INonComplianceRegisterRepository 
    {
        public NonComplianceRegisterRepository(RncContext context) : base(context)
        {
            
        }
    }
}
