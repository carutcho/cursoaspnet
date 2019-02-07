using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cursoaspnet.Models;
using cursoaspnet.Models.Enums;

namespace cursoaspnet.Data {

    public class SeedingService {

        private cursoaspnetContext _context;

        public SeedingService(cursoaspnetContext context) {
            _context = context;
        }

        public void Seed() {

            if (_context.Departament.Any() || _context.Seller.Any() || _context.SellesRecord.Any()) {
                return;
            }

            Departament d1 = new Departament(1, "Computeres");
            Departament d2 = new Departament(2, "Eletronics");
            Departament d3 = new Departament(3, "Fashion");
            Departament d4 = new Departament(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Bob Brown2", "bob2@gmail.com", new DateTime(1998, 4, 21), 2000.0, d2);
            Seller s3 = new Seller(3, "Bob Brown3", "bob3@gmail.com", new DateTime(1998, 4, 21), 3000.0, d2);
            Seller s4 = new Seller(4, "Bob Brown4", "bob4@gmail.com", new DateTime(1998, 4, 21), 4000.0, d3);

            SallesRecord r1 = new SallesRecord(1, new DateTime(2018, 12, 1), 11000.00, SalleStatusEnum.Billed, s1);
            SallesRecord r2 = new SallesRecord(2, new DateTime(2018, 12, 1), 11000.00, SalleStatusEnum.Billed, s2);
            SallesRecord r3 = new SallesRecord(3, new DateTime(2018, 12, 1), 11000.00, SalleStatusEnum.Billed, s3);
            SallesRecord r4 = new SallesRecord(4, new DateTime(2018, 12, 1), 11000.00, SalleStatusEnum.Billed, s4);

            _context.Departament.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4);

            _context.SellesRecord.AddRange(r1, r2, r3, r4);

            _context.SaveChanges();
        }
    }
}
