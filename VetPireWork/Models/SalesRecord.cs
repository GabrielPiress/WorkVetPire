using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPireWork.Models.Enums;

namespace VetPireWork.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChangeDate { get; set; }
        public double Amount { get; set; }
        public ESaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {

        }

        public SalesRecord(int id, DateTime creationDate, DateTime lastChangeDate, double amount, ESaleStatus status, Seller seller)
        {
            Id = id;
            CreationDate = creationDate;
            LastChangeDate = lastChangeDate;
            Amount = amount;
            Status = status;
            Seller = seller;
        }


    }
}
