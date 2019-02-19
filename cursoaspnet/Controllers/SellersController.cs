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

        public async Task<IActionResult> Index(){
            var list = await _sellerServices.findAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create() {
            var departaments = await _departamentServices.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departaments = departaments };
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Seller seller) {
            if (!ModelState.IsValid) {
                var departaments = await _departamentServices.FindAllAsync();
                SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departaments = departaments };
                return View(viewModel);
            }
            await _sellerServices.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id) {

            if (id == null) {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }

            var obj = await _sellerServices.FindByIdAsync(id.Value);

            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) {

            try {
                await _sellerServices.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            } catch (ApplicationException e) {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id) {

            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _sellerServices.FindByIdAsync(id.Value);

            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id) {

            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _sellerServices.FindByIdAsync(id.Value);
            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Departament> departaments = await _departamentServices.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departaments = departaments };
            return View(viewModel);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller) {

            //Forcar validacao de backend com anotation, para evitar cadastro sem javascript validando.
            if (!ModelState.IsValid) {
                var departaments = await _departamentServices.FindAllAsync();
                SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departaments = departaments };
                return View(viewModel);
            }

            if (id != seller.Id) {
                return RedirectToAction(nameof(Error), new { message = "Id miss match" });
            }

            try {
                await _sellerServices.UpdateAsync(seller);
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