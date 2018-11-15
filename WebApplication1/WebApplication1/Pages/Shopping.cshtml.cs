using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Resource.Pagination;
using WebApplication1.Resource.Option;
using WebApplication1.Searchengine;

namespace WebApplication1.Pages
{
    public class ShoppingModel : PageModel
    {
        // database context
        public readonly ApplicationDbContext _context;
        public ShoppingModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // Variablen
        public Product[] Products { get; set; }
        public Product_search[] Products_search { get; set; }
        public Option<Page<Product>> Products_page { get; set; }
        public bool show_Pagination { get; set; }

        // Define input requirements
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Search")]
        public string Search { get; set; }

        public void OnGet()
        {
            int page_index = 0;
            int page_size = 10;
            Products_page = _context.Product.GetPage(page_index, page_size, a => a.ID);
            Products = Products_page.data.Items;
        }

        public void OnGetPage(int page_index,int page_size)
        {
            Products_page = _context.Product.GetPage(page_index, page_size, a => a.ID);
            Products = Products_page.data.Items;
        }

        public void OnPostSearch(string Search)
        {
            Searchbar Searchbar = new Searchbar(_context);

            Page<Product_search> Products_page = Searchbar.search(Search, 50, 0);
            Products_search = Products_page.Items;
            Products = Products_search;
            Products = Products.Skip(0).Take(50).ToArray();
            Products_page = null;
        }
    }
}
