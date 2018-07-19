using SupportWheelFate.BusinessLogic.Interfaces;
using SupportWheelFate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportWheelFate.BusinessLogic
{
    public class EngineerPool : IEngineerPool
    {
        private List<Engineer> _engineersAvailable;
        private List<Engineer> _engineersPullable;
        private readonly Random _random;
        public int TotalAvailable => _engineersAvailable.Count;

        public int TotalPullable => _engineersPullable.Count;

        public EngineerPool(Random random)
        {
            _engineersAvailable = new List<Engineer>();
            _engineersPullable = new List<Engineer>();
            _random = random;
        }


        public void Add(List<Engineer> engineers)
        {
            _engineersAvailable.AddRange(engineers);
            _engineersPullable.AddRange(engineers);
        }

        public Engineer PullRandom()
        {
            if (_engineersPullable.Any())
            {
                var candidate = _engineersPullable.ElementAt(_random.Next(_engineersPullable.Count));
                _engineersPullable.Remove(candidate);
                return candidate;
            }
            else
            {
                return null;
            }
        }

        public void Remove(Engineer engineer)
        {
            _engineersAvailable.Remove(engineer);
        }

        public void ResetPullables()
        {
            _engineersPullable.Clear();
            _engineersPullable.AddRange(_engineersAvailable);
        }
    }
}
