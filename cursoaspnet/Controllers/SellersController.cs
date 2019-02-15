using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cursoaspnet.Models;
using cursoaspnet.Models.ViewModels;
using cursoaspnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace cursoaspnet.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerServices;
        private readonly DepartamentService _departamentServices;

        public SellersController(SellerService sellerServices, DepartamentService departamentService) {
            _sellerServices = sellerServices;
            _departamentServices = departamentService;
        }

        public IActionResult Index(){
            var list = _sellerServices.findAll();
            return View(list);
        }

        public IActionResult Create() {
            var departaments = _departamentServices.FindAll();
            var viewModel = new SellerFormViewModel { Departaments = departaments };
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Seller seller) {
            _sellerServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id) {

            if (id == null) {
                return NotFound();
            }

            var obj = _sellerServices.FindById(id.Value);

            if (obj == null) {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {

            _sellerServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) {

            if (id == null) {
                return NotFound();
            }

            var obj = _sellerServices.FindById(id.Value);

            if (obj == null) {
                return NotFound();
            }

            return View(obj);
        }
    }
}