using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;
using Microsoft.AspNetCore.Identity;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static ProdCatsContext db;

        public HomeController(ILogger<HomeController> logger, ProdCatsContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            List<Product> AllProducts = db.Products.ToList();
            return View(AllProducts);
        }


        [HttpPost("/products/create")]
        public IActionResult CreateProduct(Product newProduct)
        {
            if(!ModelState.IsValid)
            {
                return View("Index");
            }

            db.Products.Add(newProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/product/{ProductID}")]
        public IActionResult ViewProduct(int productID)
        {
            ViewBag.UnrelatedCategories = db.Categories
                .Include(cat => cat.Associations)
                .Where(cat => cat.Associations
                    .Any(catProd => catProd.ProductID == productID) == false
                )
                .ToList();
            return View("ProdDetails");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

    }
}
