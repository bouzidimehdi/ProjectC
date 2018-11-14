using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;

namespace WebApplication1.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShoppingCartModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Product> Products;

        public void OnGet()
        {
            string id = _userManager.GetUserId(User);

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
    }
}