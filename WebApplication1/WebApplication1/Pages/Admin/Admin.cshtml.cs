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

        // nodig voor create/update/delete algemeen scherm om naar toe te kunnen gaan.
        // Delete
        [TempData] public string StatusMessage1 { get; set; }
        // create
        [TempData] public string StatusMessage2 { get; set; }

        // all registered users
        public IList<ApplicationUser> RegisteredUsers { get; private set; }
        // all unregistered users
        public IList<ApplicationUser> UnregisteredUsers { get; private set; }
        // Alle orders die ooit zijn gemaakt in de database ( alle keys)
        public IList<Key> AllOrders { get; set; }
        public float SumOfOrders { get; set; }

        // Array met een list van keys in AllOrdersAll en prijs van de keys in AllOrdersSales voor alle maanden
        public List<Key>[] AllOrdersAll { get; set; }
        public List<float>[] AllOrdersSales { get; set; }

        // Array met een list van keys in AllOrdersAll en prijs van de keys in AllOrdersSales voor alle jaren
        public List<Key>[] AllOrdersYears { get; set; }
        public List<float>[] AllOrdersSalesYears { get; set; }

        public List<Key>[, ,] AllOrdersDays { get; set; }
        public List<float>[, ,] AllOrdersSalesDays { get; set; }

        public AdminModel(ApplicationDbContext context)
        {
            _context = context;
        }

        //[BindProperty] public InputModel Input { get; set; }
        //public class InputModel
        //{
        //    [Required]
        //    public int jaar { get; set; }
        //}
            
            public async Task OnGetAsync()
            {
                // Check if the user is logged in and authorised
                if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                {
                    // Zet het standaard jaar neer.
                    //Input = new InputModel()
                    //{
                    //    jaar = DateTime.Now.Year
                    //};

                    // Haalt alle registered en niet registered users op voor grafiek UsersGraph
                    RegisteredUsers = await _context.Users.AsNoTracking().Where(t => t.EmailConfirmed == true)
                        .ToListAsync();
                    UnregisteredUsers = await _context.Users.AsNoTracking().Where(t => t.EmailConfirmed == false)
                        .ToListAsync();

                    // Haal de totale ordered producten op uit de database 
                    AllOrders = await _context.Key
                        .ToListAsync();
                    
                   
                   // Orders en Sales per maand voor de laatste 3 jaren
                    AllOrdersAll = new List<Key>[36];
                    AllOrdersSales = new List<float>[36];

                // Dit zet de keys van dit jaar,vorig jaar, en 2 jaar geleden in 1 array die wordt gebruikt voor 3 grafieken
                for (int i = 0; i < 12; i++)
                    {
                        AllOrdersAll[i] = (from key in _context.Key
                                               where (key.OrderDate.Month == (DateTime.Now.AddMonths(-i).Month) &&
                                                     (key.OrderDate.Year == (DateTime.Now.Year)))
                                               select key).ToList();
                        AllOrdersAll[i+12] = (from key in _context.Key
                                               where (key.OrderDate.Month == (DateTime.Now.AddMonths(-i).Month) &&
                                                     (key.OrderDate.Year == (DateTime.Now.AddYears(-1).Year)))
                                               select key).ToList();
                        AllOrdersAll[i+24] = (from key in _context.Key
                                                where (key.OrderDate.Month == (DateTime.Now.AddMonths(-i).Month) &&
                                                      (key.OrderDate.Year == (DateTime.Now.AddYears(-2).Year)))
                                                select key).ToList();
                    }
                // Dit zet de prijs van de keys van dit jaar,vorig jaar, en 2 jaar geleden in 1 array die wordt gebruikt voor 3 grafieken
                    for (int i = 0; i < 12; i++)
                    {
                        AllOrdersSales[i] = (from key in _context.Key
                                                 where (key.OrderDate.Month == (DateTime.Now.AddMonths(-i).Month) &&
                                                       (key.OrderDate.Year == (DateTime.Now.Year)))
                                                 select key.Price).ToList();
                        AllOrdersSales[i+12] = (from key in _context.Key
                                                 where (key.OrderDate.Month == (DateTime.Now.AddMonths(-i).Month) &&
                                                       (key.OrderDate.Year == (DateTime.Now.AddYears(-1).Year)))
                                                 select key.Price).ToList();
                        AllOrdersSales[i+24] = (from key in _context.Key
                                                  where (key.OrderDate.Month == (DateTime.Now.AddMonths(-i).Month) &&
                                                        (key.OrderDate.Year == (DateTime.Now.AddYears(-2).Year)))
                                                  select key.Price).ToList();
                    }

                // Orders en Sales per jaar voor de laatste 10 jaar
                AllOrdersYears = new List<Key>[11];
                AllOrdersSalesYears = new List<float>[11];

                for (int i = 0; i < 11; i++)
                {
                    AllOrdersYears[i] = (from key in _context.Key
                                           where key.OrderDate.Year == DateTime.Now.AddYears(-i).Year
                                           select key).ToList();
                    AllOrdersSalesYears[i] = (from key in _context.Key
                                             where key.OrderDate.Year == DateTime.Now.AddYears(-i).Year
                                             select key.Price).ToList();
                }


                // Super lelijk maar het werkt voor de view. onthoud in de array [0,0,0] = 1 januari 2018 , [0,9,30] = 31 oktober 2018  en [1,1,1] = 2 februari 2019 enz
                AllOrdersDays = new List<Key>[2,12,31];
                AllOrdersSalesDays = new List<float>[2, 12, 31];
                for (int year = 0; year < 2; year++)
                {
                    for (int month = 0; month < 12; month++)
                    {
                        for (int day = 0; day < 31; day++)
                        {
                            AllOrdersDays[year,month,day] = (from key in _context.Key
                                                where key.OrderDate.Year == (year+2018) && key.OrderDate.Month == (month+1) && key.OrderDate.Day == (day+1)
                                                select key).ToList();

                            AllOrdersSalesDays[year, month, day] = (from key in _context.Key
                                                               where key.OrderDate.Year == (year + 2018) && key.OrderDate.Month == (month + 1) && key.OrderDate.Day == (day + 1)
                                                               select key.Price).ToList();
                        }
                    }
                }

                // einde van de OnGet
            }
            }
        }
    }