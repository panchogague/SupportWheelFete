using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupportWheelFate.Models;

    public class SupportWheelFateContext : DbContext
    {
        public SupportWheelFateContext (DbContextOptions<SupportWheelFateContext> options)
            : base(options)
        {
        }

        public DbSet<SupportWheelFate.Models.Engineer> Engineer { get; set; }
    }
