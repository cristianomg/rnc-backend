using _4lab.Occurrences.Domain.Models;
using System;

namespace _4Lab.Occurrences.Domain.Strategy.CalculateOcurrenceRegisterDelayed
{
    public abstract class OccurrenceRegisterDelayed
    {
        protected int Hour = 24;
        public abstract bool Calculate(OccurrenceRegister oc);
        protected int BusinessDaysUntil(DateTime firstDay, DateTime lastDay)
        {
            firstDay = firstDay.Date;
            lastDay = lastDay.Date;
            if (firstDay > lastDay)
                throw new ArgumentException("Incorrect last day " + lastDay);

            TimeSpan span = lastDay - firstDay;
            int businessDays = span.Days + 1;
            int fullWeekCount = businessDays / 7;
            if (businessDays > fullWeekCount * 7)
            {
                int firstDayOfWeek = (int)firstDay.DayOfWeek;
                int lastDayOfWeek = (int)lastDay.DayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7)
                        businessDays -= 2;
                    else if (lastDayOfWeek >= 6)
                        businessDays -= 1;
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)
                    businessDays -= 1;
            }

            businessDays -= fullWeekCount + fullWeekCount;


            return businessDays;
        }
    }
}
