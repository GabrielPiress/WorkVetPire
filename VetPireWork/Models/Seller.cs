using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VetPireWork.Models.Enums;

namespace VetPireWork.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Name size should be between 3 and 60")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Enter a valid email")]
        public string Email { get; set; }
        //para indicar casa decimal é só colocar [DisplayFormat(DataFormatString = "0:F2")]
        [Display (Name= "Phone Number")] //o mesmo pode ser feito no dropdow de data
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChangeDate{ get; set; }
        public EActive Active { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, string phoneNumber, DateTime creationDate, DateTime lastChangeDate, EActive active, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            CreationDate = creationDate;
            LastChangeDate = lastChangeDate;
            Active = active;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            SalesRecords.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            SalesRecords.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return SalesRecords.Where(ls => ls.CreationDate >= initial && ls.CreationDate <= final).Sum(ls => ls.Amount);
        }
    }


}
