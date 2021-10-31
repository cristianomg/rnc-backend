using _4Lab.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Domain.Entities
{
    public class PersonalInformations : Entity<Guid>
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
