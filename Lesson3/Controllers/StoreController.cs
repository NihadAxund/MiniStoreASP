
using Lesson3.Entities;
using Lesson3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;


namespace Lesson3.Controllers
{

    public class StoreController : Controller
    {
        private readonly StoreDbContext _context;
        ProductViewModel ViewModel { get; set; } = new ProductViewModel();
        static int ID = 0;

        public StoreController( StoreDbContext context)
        {
            _context = context;
        }
        [HttpPost]

        public  async Task<IActionResult>Index (Product product)
        {
            product.Id = ID;
            var z = product.Name;
            var product2 = _context.Products.FirstOrDefault(p => p.Id == ID);
            product2.Changing(product);
            _context.SaveChanges();

            ViewBag.Products = await _context.Products.ToListAsync();
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _context.Products.ToListAsync();
            ViewBag.Products = list;
            ViewModel.Products = list;
            return View(ViewModel);
        }
      
        public Product GetSectionContent(string sectionId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == Convert.ToInt32(sectionId));
            ID = product.Id;
            return product;
        }

        public  void Delete_Product()
        {
            var val = _context.Products.FirstOrDefault(p => p.Id == Convert.ToInt32(ID));
            _context.Products.Remove(val);
             _context.SaveChanges();
            var list =  _context.Products.ToList();
            ViewBag.Products = list;
            ViewModel.Products = list;


        }
        [HttpPost]
        public ActionResult Add_Product()
        {
            return Redirect("/Store/AddProduct");
        }
        public IActionResult AddProduct()
        {
            var product = new Product();
            return View(product);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Redirect("/Store/Index");
        }
    }
}
