using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPireWork.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace VetPireWork.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime LastChangeDate { get; set; }
        [DisplayFormat(DataFormatString ="{0:F2}")]
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
