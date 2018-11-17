using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Pages
{
    public class deleteproductModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public deleteproductModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shopping_card_Product Shopping_card_Product { get; set; }
        public Shopping_card Shopping_card { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shopping_card_Product = await _context.Shopping_Card_Products
                .Include(s => s.ShoppingCard).SingleOrDefaultAsync(m => m.Shopping_card_ID == id);

             if (Shopping_card_Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int cartid)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shopping_card_Product = await _context.Shopping_Card_Products.FindAsync(cartid,id);
            if (Shopping_card_Product.quantity != -1)
            {
                Shopping_card_Product.quantity -= 1;
                await _context.SaveChangesAsync();

                if (Shopping_card_Product.quantity <= -1)
                {
                    _context.Shopping_Card_Products.Remove(Shopping_card_Product);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToPage("./ShoppingCart");
        }

        public async Task<IActionResult> OnPostDeleteitemAsync(int? id1, int cartid1)
        {
            if (id1 == null)
            {
                return NotFound();
            }

            Shopping_card_Product = await _context.Shopping_Card_Products.FindAsync(cartid1, id1);
           _context.Shopping_Card_Products.Remove(Shopping_card_Product);
           await _context.SaveChangesAsync();
           return RedirectToPage("./ShoppingCart");
        }
    }
}
