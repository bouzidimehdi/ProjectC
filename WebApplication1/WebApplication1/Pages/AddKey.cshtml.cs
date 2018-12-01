using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Resource;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication1.Pages
{
    public class AddKeyModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public string mehdiid { get; set; }
        int i = -1;
        public IList<Shopping_card_Product> proptabtab { get; set; }

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

        public async Task<IActionResult> OnPostAsync(string userid, string license, int productid)
        {

            var id = _userManager.GetUserId(User);
            mehdiid = id;
            if (User.Identity.IsAuthenticated)
            {
                var fullcart = (from cartprd in _context.Shopping_Card_Products
                                from cartid in _context.Shopping_card
                                where cartprd.Shopping_card_ID == cartid.ID && cartid.User_ID == id
                                select cartprd);
                proptabtab = fullcart.ToList();

                foreach (var item in proptabtab)
                {
                    while (i < item.quantity)
                    {
                        Key keyz = new Key()
                        {
                            UserID = id,
                            License = Guid.NewGuid().ToString(),
                            ProductID = item.Product_ID
                        };
                        _context.Key.Add(keyz);
                        i = i + 1;
                    }
                    i = -1;
                }

                _context.Shopping_Card_Products.RemoveRange(fullcart);

            }

            else
            {
                string cookieshoping = Request.Cookies["ShoppingCart"];
                List<shoppingCart_cookie> shoppingcartlist = Cookie.Cookiereader_shoppingcart(cookieshoping);

                foreach (shoppingCart_cookie itemm in shoppingcartlist)
                {
                    while (i < itemm.Quantity - 1)
                    {
                        Key keyz = new Key()
                        {
                            //UserID = id,
                            License = Guid.NewGuid().ToString(),
                            ProductID = itemm.ProductID
                        };
                        _context.Key.Add(keyz);
                        i = i + 1;
                    }
                    i = -1;
                }

                // Cookie instellingen.
                CookieOptions cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(14),
                    HttpOnly = true
                };

                // Split characters:
                // - between productID and quantity
                // + between Produts in shopping card.
                // Tuple<ProductID, Quantity

                Response.Cookies.Append("ShoppingCart", "", cookieOptions);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}