using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Searchengine;
using WebApplication1.Resource.Pagination;
using WebApplication1.Resource.Option;

namespace WebApplication1.Pages
{
    public class SearchModel : PageModel
    {
        // database context
        public readonly ApplicationDbContext _context;
        public int page_size;

        //check if user is admin
        public bool IsAdmin { get; set; }

        public SearchModel(ApplicationDbContext context)
        {
            _context = context;
            page_size = 50;
        }

        // Variablen 
        public Option<Search_Page<Product_search>> Products_page { get; set; }
        public int _Min;
        public int _Max;

        public void OnPost(string Search, int page_index, int page_size, int? min, int? max)
        {
            // check if user is an admin ( if not then Admin = false)
            var Admin = User.IsInRole("Admin");
            IsAdmin = Admin;

            Func<Product, bool> filter = p => true;
            if (min != null && max != null)
            {
                _Min = min.GetValueOrDefault();
                _Max = max.GetValueOrDefault();
                filter = p => p.PriceFinal > min && p.PriceFinal < max;
            }
            Searchbar Searchbar = new Searchbar(_context);

            Products_page = Searchbar.search(Search, page_size, page_index, p => p.points, filter);
        }

        public void OnGet(string Search, int page_index, int page_size)
        {
            // check if user is an admin ( if not then Admin = false)
            var Admin = User.IsInRole("Admin");
            IsAdmin = Admin;

            Searchbar Searchbar = new Searchbar(_context);

            Products_page = Searchbar.search(Search, page_size, page_index, p => p.points, p => true);
        }
    }
}