using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Pages.Admin
{
    public class AdminDeleteProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminDeleteProductModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? productid)
        {
            if (productid == null)
            {
                return NotFound();
            }

            Product = await _context.Product.SingleOrDefaultAsync(m => m.ID == productid);

            if (Product == null)
            {
                return NotFound();
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? productid)
        {
            if (productid == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FindAsync(productid);

            if (Product != null)
            {
                _context.Product.Remove(Product);
                await _context.SaveChangesAsync();
            }

            StatusMessage = $"You permanently deleted {Product.QueryName} from the database";
            //return RedirectToPage();
            return RedirectToPage("/Admin/Admin");
            
        }
    }
}
