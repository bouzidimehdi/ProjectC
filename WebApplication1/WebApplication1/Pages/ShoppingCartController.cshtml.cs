using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Remotion.Linq.Clauses;
using WebApplication1.Data;

namespace WebApplication1.Pages
{
    public class ShoppingCartControllerModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public string test;
        public int testid;

        public ShoppingCartControllerModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public void OnGet()
        {
            test = "Post";
        }

        public void OnPost(/*[FromBody]*/ int productid)
        {
            test = "Post";
            testid = productid;
            if (User.Identity.IsAuthenticated)
            {
                string id = _userManager.GetUserId(User);

                var query = from shop in _context.Shopping_card
                    where shop.User_ID == id
                    select shop;

                Shopping_card shoping_check = query.FirstOrDefault();
                if (shoping_check == null)
                {
                    Console.WriteLine("");
                    Shopping_card shoppingCard = new Shopping_card()
                    {
                        User_ID = id.ToString(),
                        ShoppingCardProducts = new List<Shopping_card_Product>()
                        {
                            new Shopping_card_Product()
                            {
                                Product_ID = productid
                            }
                        }

                    };
                    _context.Shopping_card.Add(shoppingCard);
                    _context.SaveChanges();
                }
                else
                {
                    var query2 = from shopingCard in _context.Shopping_card
                        where shopingCard.User_ID == id
                        select shopingCard;
                    Shopping_card shoppingCard = query2.FirstOrDefault();

                    Shopping_card_Product shoppingCardProduct = new Shopping_card_Product()
                    {
                        Shopping_card_ID = shoppingCard.ID,
                        Product_ID = productid
                    };
                    _context.Shopping_Card_Products.Add(shoppingCardProduct);
                    _context.SaveChanges();
                }

            }
            else
            {

            }
        }
    }
}