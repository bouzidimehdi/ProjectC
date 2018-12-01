using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Pages.Admin
{
    public class 
        AdminEditProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;


        public AdminEditProductModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public Product Product { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? productid)
        {
            // Check if the user is logged in and authorised
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return Page();
            }

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

        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the user is logged in and authorised
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Product.QueryName = Product.ResponseName.ToLower();
            _context.Product.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            StatusMessage = $"You have updated this product: {Product.QueryName} !";
            return Page();
            //return RedirectToPage("Account/Manage/AdminEditProduct");
            //return RedirectToPage("/Admin/Admin");
        }

        private bool ProductExists(int productid)
        {
            return _context.Product.Any(e => e.ID == productid);
        }
    }
}
