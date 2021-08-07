using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PowerShop.Data;
using PowerShop.Models;


namespace PowerShop.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private readonly PowerShop.Data.MyPowershopContext _context;

        public IndexModel(PowerShop.Data.MyPowershopContext context)
        {
            _context = context;
        }

        public IList<Models.Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
