using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;

namespace WebApplication1.Pages.Account.Manage
{
    public class TestCreateProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public InputModel Input { get; set; }

        //public string ReturnUrl { get; set; }
        [TempData]
        public string StatusMessage { get; set; }

        public TestCreateProductModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public class InputModel
        {
            // Queryname belangrijk voor search, zorg ervoor dat het alleen lowercase toe laat
            //public string QueryName { get; set; }
            //public int QueryID { get; set; }

            // nodig voor ProductInfo pagina
            //HeaderImage , Background , ResponseName , AboutText , PriceFinal , RecommendationCount
            [Url]
            public string HeaderImage { get; set; }
            [Url]
            public string Background { get; set; }
            [Required]
            [Display(Name = "Name of the Game *")]
            public string ResponseName { get; set; }
            [Required]
            [Display(Name = "Put Information about product here *")]
            public string AboutText { get; set; }
            [Required]
            [Display(Name = "Price of the product")]
            public float PriceFinal  { get; set; }
            public int RecommendationCount { get; set; }

            
        }

        public IActionResult  OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    QueryName = Input.ResponseName.ToLower(),
                    //QueryID = ,
                    HeaderImage = Input.HeaderImage,
                    Background = Input.Background,
                    ResponseName = Input.ResponseName,
                    AboutText = Input.AboutText,
                    PriceFinal = Input.PriceFinal,
                    RecommendationCount = Input.RecommendationCount,
                };
                var result = _context.Product.Add(product);
                await _context.SaveChangesAsync();

                StatusMessage = "Your Product has been added to the database!";
                return RedirectToPage();
            }
            return Page();
         }
    }
}