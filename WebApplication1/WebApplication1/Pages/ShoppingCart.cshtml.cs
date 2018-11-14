using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;

namespace WebApplication1.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ShoppingCartModel> _logger;
        public ShoppingCartModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<ShoppingCartModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public List<Product> Products;
        //public List<Shopping_card_Product> hopping_Card_Products { get; set; }
        public Shopping_card YourCart { get; set; }
        public void OnGet()
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
                                
                                select Products
                                ).ToList()
                        select shoppingProducts;
            Products = query.FirstOrDefault();
        }

        //public async Task<IActionResult> OnPostDeleteAsync(int productid)
        //{
        //    _logger.LogWarning(productid.ToString());
        //    Console.WriteLine("delete aangekomen");
        //    var cart = await _context.Shopping_card.FindAsync(productid);

        //    if (cart != null)
        //    {

        //        Console.WriteLine("er is een cart");
        //        //_context.Shopping_card.Remove(cart);
        //        //await _context.SaveChangesAsync();

        //        var product = await _context.Shopping_Card_Products.FindAsync(productid);

        //        if (product != null)
        //        {
        //            Console.WriteLine("er zijn producten");
        //            _context.Shopping_Card_Products.Remove(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        await _context.SaveChangesAsync();
        //    }


        //    return RedirectToPage();
        //}

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