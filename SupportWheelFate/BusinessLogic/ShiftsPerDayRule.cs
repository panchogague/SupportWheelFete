
using SupportWheelFate.BusinessLogic.Interfaces;
using SupportWheelFate.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportWheelFate.BusinessLogic
{
    public class ShiftsPerDayRule : IRule
    {
        public bool IsValid(int shiftId, int candidateId, List<Shift> shifts)
        {
            // If there are currently no shifts then this proposal is valid
            if (shifts.Count(x => x.Engineer != null) == 0)
            {
                return true;
            }
            else if (shiftId % 2 == 1)
            {
                //Its an afternoon shift, so check the first period is not the same enginner
                if (shifts[shiftId - 1].Engineer?.Id == candidateId)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                //Proposed shift is for the first period, we only check when populating the second shift
                return true;
            }
        }
    }
}
