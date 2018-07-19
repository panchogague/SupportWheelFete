﻿using SupportWheelFate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportWheelFate.BusinessLogic.Interfaces
{
    public interface IEngineerPool
    {
        /// <summary>
        /// Adds a list of engineers to the pool
        /// </summary>
        /// <param name="engineers"></param>
        void Add(List<Engineer> engineers);

        /// <summary>
        /// Retrieves an engineer from pool at random
        /// </summary>
        /// <returns></returns>
        Engineer PullRandom();

        /// <summary>
        /// Removes the specified engineer from the pool
        /// </summary>
        /// <param name="engineer">The engineer to be removed from the pool</param>
        void Remove(Engineer engineer);

        /// <summary>
        /// Resets the list of engineers that can be pulled to the available list of engineers
        /// </summary>
        void ResetPullables();

        /// <summary>
        /// Gets the number of engineers available
        /// </summary>
        int TotalAvailable { get; }

        /// <summary>
        /// Gets the number of engineers that have not yet been pulled
        /// </summary>
        int TotalPullable { get; }
    }
}
