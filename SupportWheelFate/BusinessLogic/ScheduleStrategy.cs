using SupportWheelFate.BusinessLogic.Interfaces;
using SupportWheelFate.Classes;
using SupportWheelFate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportWheelFate.BusinessLogic
{
    public class ScheduleStrategy : IScheduleStrategy
    {
        private IRuleEvaluator _ruleEvaluator;

        public ScheduleStrategy(IRuleEvaluator ruleEvaluator)
        {
            _ruleEvaluator = ruleEvaluator;
        }

        public List<Shift> Generate(IEngineerPool engineerPool, int shiftsPerPeriod)
        {
            // Populate the shift schedule without engineers
            var shifts = new List<Shift>(shiftsPerPeriod);
            for (int i = 0; i < shiftsPerPeriod; i++)
            {
                shifts.Add(new Shift(i));
            }

            // Find an engineer and then walk through the shifts to 
            // find the next valid one
            Engineer candidate;
            while ((candidate = engineerPool.PullRandom()) != null)
            {
                for (int i = 0; i < shiftsPerPeriod; i++)
                {
                    if (shifts[i].Engineer == null)
                    {
                        var foundSuitableSlot = _ruleEvaluator.IsValid(i, candidate.Id, shifts);
                        if (foundSuitableSlot)
                        {
                            shifts[i].Engineer = candidate;
                            engineerPool.Remove(candidate);
                            break;
                        }
                    }
                }
            }

            return shifts;
        }
    }
}
