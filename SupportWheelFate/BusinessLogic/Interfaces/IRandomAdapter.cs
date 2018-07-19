using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportWheelFate.BusinessLogic.Interfaces
{
    public interface IRandomAdapter
    {
        int Next(int max);
    }
}
