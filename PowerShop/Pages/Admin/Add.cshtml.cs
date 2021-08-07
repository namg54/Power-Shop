using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PowerShop.Data;
using PowerShop.Models;

namespace PowerShop.Pages.Admin
{
    public class AddModel : PageModel
    {
        private MyPowershopContext _context;

        public AddModel(MyPowershopContext contex)
        {
            _context = contex;
        }

        [BindProperty]
        public AddEditProductViewModel Product { get; set; }
        [BindProperty]
        public List<int> selectedGroups { get; set; }
        public void OnGet()
        {
            Product = new AddEditProductViewModel()
            {
                Categories = _context.Categories.ToList()
            };
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();


            var item = new Item()
            {
                PriceItem = Product.Price,
                QuantityInStock = Product.QuantityStock
            };
            _context.Add(item);
            _context.SaveChanges();

            var pro = new Product()
            {
                ProductName = Product.Name,
                Item = item,
                ProductDescription = Product.Description,

            };
            _context.Add(pro);
            _context.SaveChanges();
            pro.IdItem = pro.ProductId;
            _context.SaveChanges();

            if (Product.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    pro.ProductId + Path.GetExtension(Product.Picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }

            if (selectedGroups.Any() && selectedGroups.Count > 0)
            {
                foreach (int gr in selectedGroups)
                {
                    _context.CategoryrelProducts.Add((new CategoryrelProduct()
                    {
                        CategoryId = gr,
                        ProductId = pro.ProductId
                    }));
                }

                _context.SaveChanges();
            }


            return RedirectToPage("Index");
        }
    }
}