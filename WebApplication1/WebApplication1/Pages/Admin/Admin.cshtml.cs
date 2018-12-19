using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        // all registered users
        public IList<ApplicationUser> RegisteredUsers { get; private set; }
        // all unregistered users
        public IList<ApplicationUser> UnregisteredUsers { get; private set; }

        // Grafiek voor genres
            //public IList<Product> ActionGenre { get; set; }
            //public IList<Product> MMO { get; set; }
            //public IList<Product> Adven { get; set; }
            //public IList<Product> Racer { get; set; }

        // Count total products
             // public int TotalProducts { get; set; }
        // Grafiek voor Top 5 duurste producten
            //public IList<Product> Top5HighestPrice { get; set; }


        // Alle orders die ooit zijn gemaakt in de database ( alle keys)
        public IList<Key> AllOrders { get; set; }
        public float SumOfOrders { get; set; }

        public List<Key>[] AllOrdersAll { get; set; }
        public List<float>[] AllOrdersSales { get; set; }
        public List<float>[] AllOrdersSalesWeek { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public int jaar { get; set; }
        }

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

        public async Task OnPostAsync()
        {
            // Check if the user is logged in and authorised
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {

                // Haalt alle registered users op 
                RegisteredUsers = await _context.Users.AsNoTracking().Where(t => t.EmailConfirmed == true).ToListAsync();
                UnregisteredUsers = await _context.Users.AsNoTracking().Where(t => t.EmailConfirmed == false).ToListAsync();

                // Haal de totale ordered producten op uit de database
                AllOrders = await _context.Key.Where(k => k.OrderDate.Year == Input.jaar)
                    .ToListAsync();
                // Sum products price from key
                SumOfOrders = AllOrders.Sum(t => t.Price);

                AllOrdersAll = new List<Key>[12];

                for (int i = 0; i < 12; i++)
                {
                    AllOrdersAll[i] = (from key in _context.Key
                        where key.OrderDate.Month == (i + 1) && key.OrderDate.Year == Input.jaar
                        select key).ToList();
                }

                AllOrdersSales = new List<float>[12];
                for (int i = 0; i < 12; i++)
                {
                    AllOrdersSales[i] = (from key in _context.Key
                        where key.OrderDate.Month == (i + 1) && key.OrderDate.Year == Input.jaar
                        select key.Price).ToList();
                }

            }
        }

        public async Task OnGetAsync()
        {
            // Check if the user is logged in and authorised
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                // Zet het standaard jaar neer.
                Input = new InputModel()
                {
                    jaar = DateTime.Now.Year
                };

                // Haalt alle registered users op 
                RegisteredUsers = await _context.Users.AsNoTracking().Where(t => t.EmailConfirmed == true).ToListAsync();
                UnregisteredUsers = await _context.Users.AsNoTracking().Where(t => t.EmailConfirmed == false).ToListAsync();

                // Haal de totale ordered producten op uit de database
                AllOrders = await _context.Key.Where(k => k.OrderDate.Year == Input.jaar)
                    .ToListAsync();
                // Sum products price from key
                SumOfOrders = AllOrders.Sum(t => t.Price);

                AllOrdersAll = new List<Key>[12];

                for (int i = 0; i < 12; i++)
                {
                    AllOrdersAll[i] = (from key in _context.Key
                        where key.OrderDate.Month == (i + 1) && key.OrderDate.Year == Input.jaar
                        select key).ToList();
                }

                AllOrdersSales = new List<float>[12];
                for (int i = 0; i < 12; i++)
                {
                    AllOrdersSales[i] = (from key in _context.Key
                        where key.OrderDate.Month == (i + 1) && key.OrderDate.Year == Input.jaar
                        select key.Price).ToList();
                }

              

            }
        }
    }
}