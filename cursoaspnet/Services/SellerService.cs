﻿using System.Collections.Generic;
using System.Linq;
using cursoaspnet.Models;
using Microsoft.EntityFrameworkCore;
using cursoaspnet.Services.Exceptions;

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

        public Seller FindById(int id) {
            return _context.Seller.Include(obj => obj.Departament).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id) {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller seller) {

            if (! _context.Seller.Any(x => x.Id == seller.Id)) {
                throw new NotFoundException("Id not found");
            }

            try { 
                _context.Update(seller);
                _context.SaveChanges();
            } catch (DbUpdateConcurrencyException e){
                throw new DbConcurrencyException(e.Message);
            }
        }
       
    }
}
