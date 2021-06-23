using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPireWork.Models;

namespace VetPireWork.Data
{
    public class SeedingService
    {
        private VetPireWorkContext _context;

        public SeedingService(VetPireWorkContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() || 
                        _context.Seller.Any() ||
                        _context.SalesRecord.Any())
            {
                return; //DB JÁ FOI POPULADO
            }

            Department d1 = new Department(1, "Computer");

            Department d2 = new Department(2, "Compras");

            _context.Department.AddRange(d1, d2);
            _context.SaveChanges();

        }
    }
}
