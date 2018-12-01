using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using System.Web;


namespace WebApplication1.Pages.Admin
{
    public class AdminModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // all users
        public IList<ApplicationUser> Users { get; private set; }

        public IList<Product> ActionGenre { get; set; }
        public IList<Product> MMO { get; set; }
        public IList<Product> Adven { get; set; }
        public IList<Product> Racer { get; set; }

        public AdminModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public string Message { get; set; }

        // nodig voor create/update/delete algemeen scherm om naar toe te kunnen gaan.

        // Delete
        [TempData]
        public string StatusMessage1 { get; set; }
        // create
        [TempData]
        public string StatusMessage2 { get; set; }


        public async Task OnGetAsync(int productid)
        {
            // Check if the user is logged in and authorised
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {

                //var query = (from alluser in _context.Users
                //             select alluser).ToList();
                //_users = query;

                Users = await _context.Users.AsNoTracking().ToListAsync();

                // get products ( test )
                var AmountActionGenre = (from products in _context.Product
                    where products.GenreIsAction == true
                    select products).ToList();

                var AmountAdventureGenre = (from products in _context.Product
                    where products.GenreIsAdventure == true
                    select products).ToList();
                var AmountMMOGenre = (from products in _context.Product
                    where products.GenreIsMassivelyMultiplayer == true
                    select products).ToList();
                var AmountRacingGenre = (from products in _context.Product
                    where products.GenreIsRacing == true
                    select products).ToList();

                ActionGenre = AmountActionGenre;
                MMO = AmountMMOGenre;
                Adven = AmountAdventureGenre;
                Racer = AmountRacingGenre;



                Message = "Your application description page.";
            }
        }
    }
}