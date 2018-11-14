using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Searchengine;
using WebApplication1.Resource.Pagination;

namespace WebApplication1.Pages
{
    public class SearchModel : PageModel
    {
        // database context
        public readonly ApplicationDbContext _context;
        public SearchModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Variablen 
        public Search_Page<Product_search> Products_page { get; set; }

        public void OnPost(string Search, int page_index, int page_size)
        {
            Searchbar Searchbar = new Searchbar(_context);

            Products_page = Searchbar.search(Search, page_size, page_index);
        }

        public void OnGet(string Search, int page_index, int page_size)
        {
            Searchbar Searchbar = new Searchbar(_context);

            Products_page = Searchbar.search(Search, page_size, page_index);
        }
    }
}