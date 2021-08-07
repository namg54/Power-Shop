using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PowerShop.Data;
using PowerShop.Models;

namespace PowerShop.Pages.Admin
{
    public class EditModel : PageModel
    {
        private MyPowershopContext _context;

        public EditModel(MyPowershopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddEditProductViewModel Product { get; set; }
        [BindProperty]
        public List<int> selectedGroups { get; set; }

        public List<int> GroupsProducts { get; set; }
        public void OnGet(int id)
        {
            var Products = _context.Products
                .Include(p => p.Item)
                .Where(p => p.ProductId == id)
                .Select(s => new AddEditProductViewModel()
                {
                    Id = s.ProductId,
                    Name = s.ProductName,
                    Description = s.ProductDescription,
                    QuantityStock = s.Item.QuantityInStock,
                    Price = s.Item.PriceItem
                }).FirstOrDefault();
            Product = Products;
            Products.Categories = _context.Categories.ToList();
            GroupsProducts = _context.CategoryrelProducts.Where(c => c.ProductId == id)
                .Select(s => s.CategoryId).ToList();


        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(i => i.IdItem == product.IdItem);
            product.ProductName = Product.Name;
            product.ProductDescription = Product.Description;
            item.PriceItem = Product.Price;
            item.QuantityInStock = Product.QuantityStock;

            _context.SaveChanges();
            if (Product.Picture?.Length > 0)
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",
                    product.ProductId + Path.GetExtension(Product.Picture.FileName));
                using (var stram = new FileStream(filepath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stram);
                }
            }

            _context.CategoryrelProducts.Where(c => c.ProductId == product.ProductId).ToList()
                .ForEach(f=>_context.CategoryrelProducts.Remove(f));
            if (selectedGroups.Any() && selectedGroups.Count > 0)
            {
                foreach (int gr in selectedGroups)
                {
                    _context.CategoryrelProducts.Add((new CategoryrelProduct()
                    {
                        CategoryId = gr,
                        ProductId = product.ProductId
                    }));
                }

                _context.SaveChanges();
            }


            return RedirectToPage("Index");
        }
    }
}
