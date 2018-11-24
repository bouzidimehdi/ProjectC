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
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Pages
{
    public class ShoppingModel : PageModel
    {
        // database context
        public readonly ApplicationDbContext _context;
        public int page_size;

        //check if user is admin
        public bool IsAdmin { get; set; }

        public ShoppingModel(ApplicationDbContext context)
        {
            _context = context;
            page_size = 50;
        }

        // Variablen
        public int _Min { get; set; }
        public int _Max { get; set; }
        public Option<Page<Product>> Products_page { get; set; }
        public bool show_Pagination { get; set; }

        // Define input requirements
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Search")]
        public string Search { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Price { get; set; }
                
        public void OnGet()
        {
            // check if user is an admin ( if not then Admin = false)
            var Admin = User.IsInRole("Admin");
            IsAdmin = Admin;

            int page_index = 0;
            int page_size = 50;
            Products_page = _context.Product.GetPage(page_index, page_size, a => a.ID, P => true);
        }

        public void OnGetPage(int page_index, int page_size, int? min, int? max)
        {
            Func<Product, bool> filter;
            if (min != null && max != null)
            {
                _Min = min.GetValueOrDefault();
                _Max = max.GetValueOrDefault();
                filter = P => min <= P.PriceFinal && max >= P.PriceFinal;
            }
            else
            {
                filter = P => true;
            }

            Products_page = _context.Product.GetPage(page_index, page_size, a => a.ID, filter);

        }
    }
}