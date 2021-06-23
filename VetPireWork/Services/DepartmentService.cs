using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPireWork.Data;
using VetPireWork.Models;

namespace VetPireWork.Services
{
    public class DepartmentService
    {
        private readonly VetPireWorkContext _context;
        
        public DepartmentService(VetPireWorkContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

        public string GetByIdName(int departmentId)
        {
            var department = _context.Department.Where(x => x.Id == departmentId).Select(x => x.Name).FirstOrDefault();
            return department;
        }

    }
}
