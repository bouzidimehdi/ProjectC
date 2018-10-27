using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;

namespace WebApplication1.Pages
{
    public class ProductInfoModel : PageModel
    {
        // Context to the model of database
        private readonly ApplicationDbContext _context;

        // Product
        public Product product;
        // Constructor
        public ProductInfoModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // OnGet inintialsise the page.
        public void OnGet(int id)
        {
            // Query the product.
            var query = from p in _context.Product
                where p.ID == id
                select p;

            if (query.Count() == 1)
            {
                foreach (Product item in query)
                {
                    this.product = item;
                }
            }
            
        }
    }
}