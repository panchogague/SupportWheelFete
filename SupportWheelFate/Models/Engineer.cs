using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportWheelFate.Models
{
    public class Engineer
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
