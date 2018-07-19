using SupportWheelFate.BusinessLogic.Interfaces;
using SupportWheelFate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportWheelFate.BusinessLogic
{
    public class EngineerPoolFactory : IEngineerPoolFactory
    {
        private readonly IEngineerRepository _engineerRepository;
        private readonly Random _random;

        public EngineerPoolFactory(IEngineerRepository engineerRepository
           )
        {
            _random = new Random();
            _engineerRepository = engineerRepository;
        }

        /// <summary>
        /// Creates a pool with the engineers names.
        /// </summary>
        /// <param name="shiftsPerEngineerPerPeriod">Number of shifts per engineer in a period</param>
        /// <returns>Engineer pool</returns>
        public IEngineerPool Generate(int shiftsPerEngineerPerPeriod)
        {
            var pool = new EngineerPool(_random);
            var engineers = _engineerRepository.All().ToList();
            for (int i = 0; i < shiftsPerEngineerPerPeriod; i++)
            {
                pool.Add(engineers);
            }
            return pool;
        }
    }
}
