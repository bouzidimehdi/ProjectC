using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Data;

namespace WebApplication1.Pages
{ 
    public class FinishCheckoutModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;


        public FinishCheckoutModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Key> Key { get; set; }

        public async Task OnGetAsync()
        {
            Key = await _context.Key
                    .Include(k => k.Products).Where(k => k.OrderDate > DateTime.Now.AddHours(-24)).ToListAsync();
        }
    }
}