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
    //date time moet nog weer veranderd worden om input te laten beslissen wat je laat zien op grafieken en cards
    //TODO
    // 1. Maak grafiek voor jaar(sales en orders) en een knop of in dropdown "Total years" en pas de cards ook aan
    // 2. Maak niew object om data voor jaar orders op te slaan
    // 3. Maak niew object om data voor jaar Sales op te slaan
    // 4. Maak grafiek in script met nieuwe dataset over de grafiek die al bestaat voor order en sales
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
                AllOrdersYears = new List<Key>[12];
                AllOrdersSalesYears = new List<float>[12];

                for (int i = 0; i < 12; i++)
                {
                    AllOrdersYears[i] = (from key in _context.Key
                                           where key.OrderDate.Year == DateTime.Now.AddYears(-i).Year
                                           select key).ToList();
                    AllOrdersSalesYears[i] = (from key in _context.Key
                                             where key.OrderDate.Year == DateTime.Now.AddYears(-i).Year
                                             select key.Price).ToList();
                }

                // einde van de OnGet
            }
            }
        }
    }