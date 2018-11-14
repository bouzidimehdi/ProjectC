using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/ShoppingCart")]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShoppingCartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public void Post([FromBody] int productid)
        {
            Console.WriteLine("Ping from ShoppinCardcontroller");
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

                }

            }
            else
            {

            }
        }


            }
        }
    

        

            