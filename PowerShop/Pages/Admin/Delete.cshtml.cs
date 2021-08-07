using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
////using Microsoft.EntityFrameworkCore;
using PowerShop.Data;
using PowerShop.Models;

namespace PowerShop.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private MyPowershopContext _context;

        public DeleteModel(MyPowershopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _context.Products.FirstOrDefault(p => p.ProductId == id);

        }

        public IActionResult OnPost()
        {
            var products = _context.Products.Find(Product.ProductId);
            var item = _context.Items.First(i => i.IdItem == products.IdItem);
            _context.Items.Remove(item);
            _context.Products.Remove(products);
            _context.SaveChanges();

            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",
                products.ProductId + ".jpg");
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }



            return RedirectToPage("Index");
        }
    }
}
