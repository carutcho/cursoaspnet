using cursoaspnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cursoaspnet.Services {

    public class DepartamentService {

        private readonly CursoAspnetContext _context;

        public DepartamentService(CursoAspnetContext context) {
            _context = context;
        }

        public List<Departament> FindAll() {
            return _context.Departament.OrderBy(X => X.Name).ToList();
        }
    }
}
