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
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class AddKeyModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        public string mehdiid { get; set; }
        int i = 0;
        //public IList<Shopping_card_Product> proptabtab { get; set; }
        public List<ResponseShopingCart> proptabtab { get; set; }

        public AddKeyModel(WebApplication1.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;

        }

        public IActionResult OnGet()
        {
                ViewData["ProductID"] = new SelectList(_context.Product, "ID", "ID");
            return Page();


            }

        [BindProperty]
        public Key Key { get; set; }

        public async Task<IActionResult> OnPostAsync(string email, string firstname, string lastname)
        {

            var id = _userManager.GetUserId(User);
            mehdiid = id;
            if (User.Identity.IsAuthenticated)
            {
                var fullcart = (from cartprd in _context.Shopping_Card_Products
                                from cartid in _context.Shopping_card
                                where cartprd.Shopping_card_ID == cartid.ID && cartid.User_ID == id
                                select cartprd);
                //proptabtab = fullcart.ToList();

                var query = from shopping in _context.Shopping_card
                            where shopping.User_ID == id
                            let shoppingProducts = (
                                from shoppingProdutstable in _context.Shopping_Card_Products
                                from Products in _context.Product
                                where shoppingProdutstable.Shopping_card_ID == shopping.ID &&
                                      shoppingProdutstable.Product_ID == Products.ID
                                select new ResponseShopingCart() { product = Products, quantity = shoppingProdutstable.quantity + 1 }
                            ).ToList()
                            select shoppingProducts;
                proptabtab = query.FirstOrDefault();

                List<Key> keys = new List<Key>();

                foreach (var item in proptabtab)
                {
                    while (i < item.quantity)
                    {
                        Key keyz = new Key()
                        {
                            UserID = id,
                            License = Guid.NewGuid().ToString(),
                            ProductID = item.product.ID,
                            Price = item.product.PriceFinal,
                            OrderDate = DateTime.Now
                        };
                        _context.Key.Add(keyz);
                        keys.Add(keyz);
                        i = i + 1;
                    }
                    i = 0;
                }

                // From List keys to only key array
                EmailKeyArray[] EmailKey = new EmailKeyArray[keys.Count];

                for (int j = 0; j < keys.Count; j++)
                {
                    EmailKey[j] = new EmailKeyArray();
                    EmailKey[j].Key = keys[j].License;
                    EmailKey[j].ProductName = (from p in _context.Product
                        where p.ID == keys[j].ProductID
                        select p.ResponseName).FirstOrDefault();
                }

                // Send the E-mail
                _emailSender.SendKeysToEmailAsync(email, EmailKey, firstname, lastname);

                _context.Shopping_Card_Products.RemoveRange(fullcart);

            }
            else
            {
                string cookieshoping = Request.Cookies["ShoppingCart"];
                List<shoppingCart_cookie> shoppingcartlist = Cookie.Cookiereader_shoppingcart(cookieshoping);
                List<Key> keys = new List<Key>();

                foreach (shoppingCart_cookie item in shoppingcartlist)
                {
                    while (i < item.Quantity)
                    {
                        Key keyz = new Key()
                        {
                            //UserID = id,
                            License = Guid.NewGuid().ToString(),
                            ProductID = item.ProductID,
                            Price = 0,
                            OrderDate = DateTime.Now
                        };
                        _context.Key.Add(keyz);
                        keys.Add(keyz);
                        i = i + 1;
                    }
                    i = -1;
                }

                // From List keys to only key array
                EmailKeyArray[] EmailKey = new EmailKeyArray[keys.Count];

                for (int j = 0; j < keys.Count; j++)
                {
                    EmailKey[j] = new EmailKeyArray();
                    EmailKey[j].Key = keys[j].License;
                    EmailKey[j].ProductName = (from p in _context.Product
                                                where p.ID == keys[j].ProductID
                                                select p.ResponseName).FirstOrDefault();
                }

                // Send the E-mail
                _emailSender.SendKeysToEmailAsync(email, EmailKey, firstname, lastname);

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
            return RedirectToPage("FinishCheckout");
        }
    }

    public class EmailKeyArray
    {
        public string Key { get; set; }
        public string ProductName { get; set; }
    }
}