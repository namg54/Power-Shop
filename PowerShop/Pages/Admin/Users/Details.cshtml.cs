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
    public class DetailsModel : PageModel
    {
        private readonly PowerShop.Data.MyPowershopContext _context;

        public DetailsModel(PowerShop.Data.MyPowershopContext context)
        {
            _context = context;
        }

        public PowerShop.Models.Users Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);

            if (Users == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
