using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Resource.Pagination;
using WebApplication1.Resource.Option;

namespace WebApplication1.Pages
{
    public class AboutModel : PageModel
    {
        // database context
        public readonly ApplicationDbContext _context;
        public AboutModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // Variablen
        public Option<Page<Product>> Products { get; set; }


        public void OnGet()
        {
            int page_index = 0;
            int page_size = 50;
            Products = _context.Product.GetPage(page_index, page_size, a => a.ID);
        }

        public void OnGetPage(int page_index,int page_size)
        {
            Products = _context.Product.GetPage(page_index, page_size, a => a.ID);
        }
    }
}
