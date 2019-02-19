using System.Collections.Generic;
using System.Linq;
using cursoaspnet.Models;
using Microsoft.EntityFrameworkCore;
using cursoaspnet.Services.Exceptions;
using System.Threading.Tasks;

namespace cursoaspnet.Services {

    public class SellerService {

        private readonly CursoAspnetContext _context;

        public SellerService(CursoAspnetContext context) {
            _context = context;
        }

        //metodo assincrono
        public async Task<List<Seller>> findAllAsync() {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj) {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id) {
            return await _context.Seller.Include(obj => obj.Departament).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id) {

            try { 
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            } catch (DbUpdateException e) {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Seller seller) {

            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == seller.Id);
            if (!hasAny) {
                throw new NotFoundException("Id not found");
            }

            try { 
                _context.Update(seller);
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException e){
                throw new DbConcurrencyException(e.Message);
            }
        }
       
    }
}
