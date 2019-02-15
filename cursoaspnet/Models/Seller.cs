using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace cursoaspnet.Models {

    public class Seller {

        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display (Name = "Birth Date")]
        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public int DepartamentId { get; set; }
        public ICollection<SallesRecord> Sellers { get; set; } = new List<SallesRecord>();


        public Seller() {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament) {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void AddSalles (SallesRecord sr) {
            Sellers.Add(sr);
        }

        public void RemoveSalles(SallesRecord sr) {
            Sellers.Remove(sr);
        }

        public double TotalSalles(DateTime initial, DateTime final) {
            return Sellers.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
