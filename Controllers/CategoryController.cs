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
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static ProdCatsContext db;

        public CategoryController(ILogger<HomeController> logger, ProdCatsContext context)
        {
            _logger = logger;
            db = context;
        }

        [HttpGet("/categories")]
        public IActionResult Categories()
        {
            List<Category> Categories = db.Categories.ToList();
            return View("Categories", Categories);
        }

        [HttpPost("/category/create")]
        public IActionResult CreateCategory(Category newCategory)
        {
            if(!ModelState.IsValid)
            {
                return View("Index");
            }

            db.Categories.Add(newCategory);
            db.SaveChanges();
            return RedirectToAction("Categories");
        }

        [HttpGet("/category/{CategoryID}")]
        public IActionResult ViewCategory(int categoryID)
        {
            ViewBag.CatName = db.Categories.FirstOrDefault(c => c.CategoryID == categoryID);
            // List<Category> relatedProducts = db.Categories.Where(c => c.CategoryID == catID).Include(c => c.Associations).ThenInclude(c => c.Product).ToList();
            var relatedProducts = db.Categories.Include(cat => cat.Associations).ThenInclude(prod => prod.Product).FirstOrDefault(cat => cat.CategoryID == categoryID);
            ViewBag.UnrelatedProducts = db.Products
                .Include(prod => prod.Associations)
                .Where(prod => prod.Associations
                    .Any(catProd => catProd.CategoryID == categoryID) == false
                )
                .ToList();
            ViewBag.Products = db.Products.ToList();
            return View("CatDetails", relatedProducts);
        }

        [HttpPost("/addproduct/{categoryID}")]
        public IActionResult AddProduct(int productID, int categoryID)
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine(productID);
            Console.WriteLine(categoryID);
            Association newAssociation = new Association()
            {
                // CategoryID = CategoryID,
                ProductID = productID
            };
            
            // db.Associations.Add(newAssociation);
            // db.SaveChanges();
            return RedirectToAction("ViewCategory");

        }
    }
}