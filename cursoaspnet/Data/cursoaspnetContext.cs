using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cursoaspnet.Models
{
    public class CursoAspnetContext : DbContext
    {
        public CursoAspnetContext(DbContextOptions<CursoAspnetContext> options)
            : base(options)
        {
        }

        public DbSet<Departament> Departament { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SallesRecord> SellesRecord { get; set; }

    }
}
