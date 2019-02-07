using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cursoaspnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace cursoaspnet.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerServices;

        public SellersController(SellerService sellerServices) {
            _sellerServices = sellerServices;
        }

        public IActionResult Index(){

            var list = _sellerServices.findAll();
            return View(list);
        }


    }
}