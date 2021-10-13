using _4lab.Occurrences.Domain.Models;
using _4Lab.Occurrences.Domain.Strategy.CalculateOcurrenceRegisterDelayed;
using System;

namespace _4Lab.Occurrences.Domain.Strategy.CalculateOccurrenceRegisterDelayed
{
    public class OccurrenceRegisterDelayedByRootCause : OccurrenceRegisterDelayed
    {
        public override bool Calculate(OccurrenceRegister oc)
        {
            var timeToCalc = oc.CreatedAt;

            var businessDaysUntil = BusinessDaysUntil(timeToCalc, DateTime.Now);

            timeToCalc = timeToCalc.AddDays(businessDaysUntil);

            return timeToCalc.Subtract(oc.CreatedAt).TotalHours > (2 * Hour);
        }
    }
}
