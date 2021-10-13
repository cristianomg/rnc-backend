using _4lab.Occurrences.Domain.Models;
using _4Lab.Occurrences.Domain.Strategy.CalculateOcurrenceRegisterDelayed;
using System;
namespace _4Lab.Occurrences.Domain.Strategy.CalculateOccurrenceRegisterDelayed
{
    public class OccurrenceRegisterDelayedByVerificatoinOfEffectiveness : OccurrenceRegisterDelayed
    {
        public override bool Calculate(OccurrenceRegister oc)
        {
            return false;  
        }
     }
}
