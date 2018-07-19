using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportWheelFate.Models;

namespace SupportWheelFate.Repository
{
    public class EngineerRepository : IEngineerRepository
    {
        private readonly SupportWheelFateContext _context;
        public EngineerRepository(SupportWheelFateContext context)
        {
            _context = context;
            
        }

        public void Add(Engineer engineer)
        {
            _context.Engineer.Add(engineer);
            _context.SaveChanges();
        }

        public IEnumerable<Engineer> All()
        {
            return _context.Engineer.ToList();
        }

        public Engineer Find(int id)
        {
            var engineer = _context.Engineer.Find(id);
            return engineer;
        }

        public void Remove(int id)
        {
            var engineer = _context.Engineer.Find(id);
            _context.Engineer.Remove(engineer);
            _context.SaveChanges();
        }
    }
}
