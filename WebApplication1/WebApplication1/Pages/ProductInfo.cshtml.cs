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
    public class ProductInfoModel : PageModel
    {
        // Context to the model of database
        private readonly ApplicationDbContext _context;
        public readonly UserManager<ApplicationUser> _userManager;

        // Product
        public Product product;

        // wishlist van de user
        public User_Wishlist Wishlistitems { get; set; }

        // Constructor
        public ProductInfoModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // OnGet inintialsise the page.
        public void OnGet(int id)
        {
            // Query the product.
            var query = from p in _context.Product
                where p.ID == id
                select p;

            if (query.Count() == 1)
            {
                foreach (Product item in query)
                {
                    this.product = item;
                }
            }

            string iduser = _userManager.GetUserId(User);


            var query1 = from wishlist1 in _context.User_wishlist
                        where wishlist1.User_ID == iduser && wishlist1.Product_ID == id
                        select wishlist1;

            Wishlistitems = query1.FirstOrDefault();


        }
    }
}