using SupportWheelFate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportWheelFate.Repository
{
    public interface IEngineerRepository
    {
        /// <summary>
        /// Reads all the engineers from the db
        /// </summary>
        /// <returns>List of engineers</returns>
        IEnumerable<Engineer> All();

        /// <summary>
        /// Adds a new engineer to the db
        /// </summary>
        /// <param name="engineer">The engineer to add</param>
        void Add(Engineer engineer);

        /// <summary>
        /// Removes a specific engineer from the db
        /// </summary>
        /// <param name="id">Id of the engineer to remove</param>
        void Remove(int id);

        /// <summary>
        /// Retrieves an engineer from the db
        /// </summary>
        /// <param name="id">Id of the engineer to retreive</param>
        /// <returns></returns>
        Engineer Find(int id);
    }
}
