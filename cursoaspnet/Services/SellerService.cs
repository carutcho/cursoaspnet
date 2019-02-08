using System.Collections.Generic;
using System.Linq;
using cursoaspnet.Models;

namespace cursoaspnet.Services {

    public class SellerService {

        private readonly CursoAspnetContext _context;

        public SellerService(CursoAspnetContext context) {
            _context = context;
        }

        public List<Seller> findAll() {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj) {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
