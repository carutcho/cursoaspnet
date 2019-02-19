using cursoaspnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; //Permitir criar tasks asyncronas
using Microsoft.EntityFrameworkCore; //Adicionado pois o ListAsync eh do entity framework

namespace cursoaspnet.Services {

    public class DepartamentService {

        private readonly CursoAspnetContext _context;

        public DepartamentService(CursoAspnetContext context) {
            _context = context;
        }

        //Criar uma chamada assincrona usando task e listasync
        public async Task<List<Departament>> FindAllAsync() {
            return await _context.Departament.OrderBy(X => X.Name).ToListAsync();
        }
    }
}
