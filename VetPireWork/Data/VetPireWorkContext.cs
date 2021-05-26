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

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }

    }
}
