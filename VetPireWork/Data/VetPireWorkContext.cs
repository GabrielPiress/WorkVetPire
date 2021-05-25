using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VetPireWork.Models;

namespace VetPireWork.Data
{
    public class VetPireWorkContext : DbContext
    {
        public VetPireWorkContext (DbContextOptions<VetPireWorkContext> options)
            : base(options)
        {
        }

        public DbSet<VetPireWork.Models.Department> Department { get; set; }
    }
}
