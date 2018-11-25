using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using WebApplication1.Resource;

namespace WebApplication1.Pages
{ // nu kan je ook checkout zin met cookies
    public class CheckoutModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ShoppingCartModel> _logger;
        public CheckoutModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<ShoppingCartModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        public List<ResponseShopingCart> _Products;
        //public List<Shopping_card_Product> hopping_Card_Products { get; set; }

        public Shopping_card YourCart { get; set; }
        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                string id = _userManager.GetUserId(User);
                var query2 = from shop in _context.Shopping_card
                             where shop.User_ID == id
                             select shop;
                YourCart = query2.FirstOrDefault();

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
                _Products = query.FirstOrDefault();
            }
            else
            {
                string cookieshoping = Request.Cookies["ShoppingCart"];
                List<shoppingCart_cookie> shoppingcartlist = Cookie.Cookiereader_shoppingcart(cookieshoping);
                _Products = new List<ResponseShopingCart>();

                foreach (shoppingCart_cookie item in shoppingcartlist)
                {
                    var query = from product in _context.Product
                                where product.ID == item.ProductID
                                select product;

                    _Products.Add(new ResponseShopingCart() { product = query.FirstOrDefault(), quantity = item.Quantity });
                }
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int Id)
        {
            var products = await _context.Shopping_Card_Products.FindAsync(Id);

            if (products != null)
            {

                _context.Shopping_Card_Products.Remove(products);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

    }


}