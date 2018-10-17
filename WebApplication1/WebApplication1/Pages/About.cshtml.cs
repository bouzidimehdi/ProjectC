using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class AboutModel : PageModel
    {
        ItemDataAccessLayer objemployee = new ItemDataAccessLayer();
        public List<Items> employee { get; set; }

        public void OnGet()
        {
            employee = objemployee.GetAllEmployees().ToList();
        }
    }
}
