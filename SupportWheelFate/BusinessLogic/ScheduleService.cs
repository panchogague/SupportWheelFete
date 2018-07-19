using SupportWheelFate.BusinessLogic.Interfaces;
using SupportWheelFate.Classes;
using SupportWheelFate.Interfaces;
using SupportWheelFate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportWheelFate.BusinessLogic
{
    public class ScheduleService : IScheduleService
    {
        private readonly IEngineerPoolFactory _engineerPoolFactory;
        private readonly IScheduleStrategy _scheduleStrategy;

        public ScheduleService(IEngineerPoolFactory engineerPoolFactory,
         IScheduleStrategy scheduleStrategy)
        {
            _engineerPoolFactory = engineerPoolFactory;
            _scheduleStrategy = scheduleStrategy;
        }


        public List<Shift> Generate(int shiftsPerPeriod, int shiftsPerEngineerPerPeriod)
        {
            var shifts = new List<Shift>();
            while (shifts.Count(x => x.Engineer != null) != shiftsPerPeriod)
            {
                // Create a pool of engineers to use for scheduling
                var engineerPool = _engineerPoolFactory.Generate(shiftsPerEngineerPerPeriod);

                // Generate the shift pattern using the provided strategy
                shifts = _scheduleStrategy.Generate(engineerPool, shiftsPerPeriod);
            }
            return shifts;
        }
    }
}
