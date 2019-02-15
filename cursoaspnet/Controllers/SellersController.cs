using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cursoaspnet.Models;
using cursoaspnet.Models.ViewModels;
using cursoaspnet.Services;
using Microsoft.AspNetCore.Mvc;
using cursoaspnet.Services.Exceptions;
using System.Diagnostics;

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
            if (!ModelState.IsValid) {
                var departaments = _departamentServices.FindAll();
                SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departaments = departaments };
                return View(viewModel);
            }
            _sellerServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id) {

            if (id == null) {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }

            var obj = _sellerServices.FindById(id.Value);

            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
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
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _sellerServices.FindById(id.Value);

            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id) {

            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _sellerServices.FindById(id.Value);
            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Departament> departaments = _departamentServices.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departaments = departaments };
            return View(viewModel);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller) {

            //Forcar validacao de backend com anotation, para evitar cadastro sem javascript validando.
            if (!ModelState.IsValid) {
                var departaments = _departamentServices.FindAll();
                SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departaments = departaments };
                return View(viewModel);
            }

            if (id != seller.Id) {
                return RedirectToAction(nameof(Error), new { message = "Id miss match" });
            }

            try {
                _sellerServices.Update(seller);
                return RedirectToAction(nameof(Index));
            }catch (ApplicationException e) {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

       public IActionResult Error (string message) {

            var viewModel = new ErrorViewModel {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
       }
    }
}