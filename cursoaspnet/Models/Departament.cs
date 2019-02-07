using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cursoaspnet.Models {

    public class Departament {

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();


        public Departament() {

        }

        public Departament(int id, string name) {
            Id = id;
            Name = name;
        }

        public void AddSalles(Seller sr) {
            Sellers.Add(sr);
        }

        public void RemoveSalles(Seller sr) {
            Sellers.Remove(sr);
        }

        public double TotalSalles(DateTime initial, DateTime final) {

            return Sellers.Sum(seller => seller.TotalSalles(initial, final));
        }
    }
}
