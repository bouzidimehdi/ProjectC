using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using System.Web;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Pages.Admin
{
    public class AdminModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // all users
        public IList<ApplicationUser> Users { get; private set; }
        public IList<IdentityRole> Admins { get; set; }

        // Grafiek voor genres
        public IList<Product> ActionGenre { get; set; }
        public IList<Product> MMO { get; set; }
        public IList<Product> Adven { get; set; }
        public IList<Product> Racer { get; set; }

        // Grafiek voor Top 5 duurste producten
        public IList<Product> Top5HighestPrice { get; set; }

        // aantal Users - admins
        public int UserMinusAdmin { get; set; }
        // Alle orders die ooit zijn gemaakt in de database ( alle keys)
        public IList<Key> AllOrders { get; set; }

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

                // Haalt alle users op
                Users = await _context.Users.AsNoTracking().ToListAsync();
                // Haalt alle admins op
                Admins = await _context.Roles.ToListAsync();
                // Haal op de totale hoeveelheid gebruikers vs admins
                UserMinusAdmin = Users.Count() - Admins.Count();

                // Haalt alle genres op uit de database om te gebruiken in grafiek
                ActionGenre = await (from products in _context.Product
                    where products.GenreIsAction == true
                    select products).ToListAsync();
                Adven = await (from products in _context.Product
                    where products.GenreIsAdventure == true
                    select products).ToListAsync();
                 MMO = await (from products in _context.Product
                    where products.GenreIsMassivelyMultiplayer == true
                    select products).ToListAsync();
                 Racer = await (from products in _context.Product
                    where products.GenreIsRacing == true
                    select products).ToListAsync();

               // Top 5 hoogste prijzen van producten in de shop
                     Top5HighestPrice =  await _context.Product
                                        .OrderByDescending(t => t.PriceFinal)
                                        .Take(5)
                                        .ToListAsync();
               
                // Haal de totale ordered producten op uit de database
                 AllOrders = await _context.Key
                                            .ToListAsync();
                


                //



                Message = "Your application description page.";
            }
        }
    }
}