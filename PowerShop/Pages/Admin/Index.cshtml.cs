using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PowerShop.Data;
using PowerShop.Models;

namespace PowerShop.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private MyPowershopContext _context;

        public IndexModel(MyPowershopContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _context.Products.Include(c=>c.Item);
        }

        public void OnPost()
        {

        }
    }
}
