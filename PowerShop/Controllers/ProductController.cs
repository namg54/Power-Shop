using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PowerShop.Data;

namespace PowerShop.Controllers
{
    public class ProductController : Controller
    {
        private MyPowershopContext _context;

        public ProductController(MyPowershopContext context)
        {
            _context = context;
        }
        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id, string name)
        {
            ViewData["GroupName"] = name;
            var products = _context.CategoryrelProducts
                .Where(c => c.CategoryId == id)
                .Include(c => c.Product)
                .Select(p => p.Product)
                .ToList();
            return View(products);
        }
    }
}
