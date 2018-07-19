using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportWheelFate.Models;
using SupportWheelFate.Repository;

namespace SupportWheelFate.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EngineerController : Controller
    {
        // private readonly SupportWheelFateContext _context;
        private readonly IEngineerRepository _engineerRepository;

        public EngineerController(IEngineerRepository engineerRepository)
        {
            _engineerRepository = engineerRepository;
        }

        // GET: api/Engineers
        [HttpGet]
        public IEnumerable<Engineer> GetEngineer()
        {
            return _engineerRepository.All();
        }

        // GET: api/Engineers/5
        [HttpGet("{id}")]
        public IActionResult GetEngineer([FromRoute] int id)
        {
            var engineer = _engineerRepository.Find(id);
            if (engineer == null)
            {
                return NotFound();
            }

            return new ObjectResult(engineer);
        }


        // POST: api/Engineers
        [HttpPost]
        public IActionResult Post([FromBody]Engineer engineer)
        {
           
            _engineerRepository.Add(engineer);
            return new ObjectResult(engineer.Id) { StatusCode = StatusCodes.Status201Created };
        }

        // DELETE: api/Engineers/5
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _engineerRepository.Remove(id);
            return Ok();
        }
    }
}