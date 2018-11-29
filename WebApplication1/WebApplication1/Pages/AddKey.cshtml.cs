using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication1.Pages
{
    public class AddKeyModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public AddKeyModel(WebApplication1.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public IActionResult OnGet()
        {
        ViewData["ProductID"] = new SelectList(_context.Product, "ID", "ID");
            return Page();


            }

        [BindProperty]
        public Key Key { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            var id = _userManager.GetUserId(User);
            var fullcart = from cartprd in _context.Shopping_Card_Products
                           from cartid in _context.Shopping_card
                           where cartprd.Shopping_card_ID == cartid.ID && cartid.User_ID == id
                           select cartprd;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (var item in fullcart)
            {
                _context.Key.Add(Key);
                await _context.SaveChangesAsync();

            }

            return RedirectToPage("./Index");
        }
    }
}