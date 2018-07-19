using SupportWheelFate.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportWheelFate.Interfaces
{
    public interface IScheduleService
    {
        /// <summary>
        /// Generates a new schedule
        /// </summary>
        /// <param name="shiftsPerPeriod"></param>
        /// <param name="shiftsPerEngineerPerPeriod"></param>
        /// <returns>List of shift</returns>
        List<Shift> Generate(int shiftsPerPeriod, int shiftsPerEngineerPerPeriod);
    }
}
