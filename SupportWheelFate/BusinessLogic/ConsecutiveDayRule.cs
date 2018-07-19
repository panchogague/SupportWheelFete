
using SupportWheelFate.BusinessLogic.Interfaces;
using SupportWheelFate.Classes;
using System.Collections.Generic;

namespace SupportWheelFate.BusinessLogic
{
    public class ConsecutiveDayRule : IRule
    {
        public bool IsValid(int shiftId, int candidateId, List<Shift> shifts)
        {
            // If shiftId is the first day, allocation must be valid
            if (shiftId < 2)
            {
                return true;
            }
            else
            {   
                bool isMorning = shiftId == 0 || shiftId % 2 == 0;
                if (isMorning)
                {
                    //Proposed shift is for first period, check the last 2 shifts are not for the same enginner
                    if (shifts[shiftId - 1].Engineer?.Id == candidateId ||
                       shifts[shiftId - 2].Engineer?.Id == candidateId)
                    {
                        return false;
                    }
                }
                else
                {
                    //Proposd shift is for second period, check the previous days shifts
                    if (shifts[shiftId - 2].Engineer?.Id == candidateId ||
                        shifts[shiftId - 3].Engineer?.Id == candidateId)
                    {
                        return false;
                    }
                }

                
                return true;
            }
        }
    }
}
