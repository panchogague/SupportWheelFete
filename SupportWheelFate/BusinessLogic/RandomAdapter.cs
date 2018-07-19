using SupportWheelFate.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportWheelFate.BusinessLogic
{
    public class RandomAdapter : IRandomAdapter
    {
        private readonly Random _random;

        public RandomAdapter(Random random)
        {
            _random = random;
        }

        public int Next(int max)
        {
            return _random.Next(max);
        }
    }
}
