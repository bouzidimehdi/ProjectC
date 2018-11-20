using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Pages.Account.Manage
{
    public class TestEditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public TestEditModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public ApplicationUser Users { get; set; }
        public async Task<IActionResult> OnGet(string id)
        {
            Users = await _context.Users.FindAsync(id);
            if(Users == null)
            {
                return RedirectToPage("Account/Manage/Admin");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Users).State = EntityState.Modified;
            //Users.ConcurrencyStamp = Guid.NewGuid().ToString();
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception($"User {Users.Id} not found!", e);
            }

            return RedirectToPage("Account/Manage/Admin");
        }
    }
}