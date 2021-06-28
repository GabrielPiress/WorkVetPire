using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPireWork.Data;
using VetPireWork.Models;

namespace VetPireWork.Services
{
    public class SalesRecordService
    {
        private readonly VetPireWorkContext _context;

        public SalesRecordService(VetPireWorkContext context)
        {
            _context = context;
        }

        public List<SalesRecord> FindByDate (DateTime? minDate, DateTime? maxDate)
        {
            var result = _context.SalesRecord.AsQueryable();
            if (minDate.HasValue)
            {
                result = result.Where(x => x.LastChangeDate >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.LastChangeDate <= maxDate.Value);
            }

            return result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.LastChangeDate)
                .ToList();
        }

        public List<IGrouping<Department,SalesRecord>> FindByDateGrouping(DateTime? minDate, DateTime? maxDate)
        {
            var result = _context.SalesRecord.AsQueryable();
            if (minDate.HasValue)
            {
                result = result.Where(x => x.LastChangeDate >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.LastChangeDate <= maxDate.Value);
            }

            return result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.LastChangeDate)
                .GroupBy(x => x.Seller.Department)
                .ToList();
        }
    }
}
