using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Resource.Pagination;
using WebApplication1.Resource.Option;
using WebApplication1.Searchengine;
using WebApplication1.Data;


namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {   

       //producten van rij 1 ( bovenste )
        public Product product;
        public Product product2;
        public Product product3;
        public Product product4;
        //producten van rij 2 ( middelste )
        public Product product5;
        public Product product6;
        public Product product7;
        public Product product8;
        //producten van rij 3 ( onderste )
        public Product product9;
        public Product product10;
        public Product product11;
        public Product product12;

        //dit is de random nummer generator
        public Random rand = new Random();
        //public Product[] Products { get; set; }

        public void OnGet()
        {
            
        }

        // database context gekopieerd uit Shopping.cshtml.cs
        public readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;

            //bovenste rij random nummers
            int single1 = rand.Next(1, 10000);
            int single2 = rand.Next(1, 10000);
            int single3 = rand.Next(1, 10000);
            int single4 = rand.Next(1, 10000);
            //middelste rij random nummers
            int single5 = rand.Next(1, 10000);
            int single6 = rand.Next(1, 10000);
            int single7 = rand.Next(1, 10000);
            int single8 = rand.Next(1, 10000);
            //onderste rij random nummers
            int single9 = rand.Next(1, 10000);
            int single10 = rand.Next(1, 10000);
            int single11 = rand.Next(1, 10000);
            int single12 = rand.Next(1, 10000);

            // Query the product. rij 1 ( bovenste )
            var query = from p in _context.Product
                        where p.ID == single1
                        select p;
            var query2 = from p in _context.Product
                        where p.ID == single2
                        select p;
            var query3 = from p in _context.Product
                        where p.ID == single3
                        select p;
            var query4 = from p in _context.Product
                        where p.ID == single4
                        select p;
            // Query the product. rij 2 ( middelste )
            var query5 = from p in _context.Product
                        where p.ID == single5
                        select p;
            var query6 = from p in _context.Product
                         where p.ID == single6
                         select p;
            var query7 = from p in _context.Product
                         where p.ID == single7
                         select p;
            var query8 = from p in _context.Product
                         where p.ID == single8
                         select p;
            // Query the product. rij 3 ( onderste )
            var query9 = from p in _context.Product
                         where p.ID == single9
                         select p;
            var query10 = from p in _context.Product
                         where p.ID == single10
                         select p;
            var query11 = from p in _context.Product
                         where p.ID == single11
                         select p;
            var query12 = from p in _context.Product
                         where p.ID == single12
                         select p;
            //hieronder rij 1.
            if (query.Count() == 1)
            {
                foreach (Product item in query)
                {
                    this.product = item;
                }
            }
            if (query2.Count() == 1)
            {
                foreach (Product item2 in query2)
                {
                    this.product2 = item2;
                }
            }
            if (query3.Count() == 1)
            {
                foreach (Product item3 in query3)
                {
                    this.product3 = item3;
                }
            }
            if (query4.Count() == 1)
            {
                foreach (Product item4 in query4)
                {
                    this.product4 = item4;
                }
            }
            //hieronder rij 2.
            if (query5.Count() == 1)
            {
                foreach (Product item5 in query5)
                {
                    this.product5 = item5;
                }
            }
            if (query6.Count() == 1)
            {
                foreach (Product item6 in query6)
                {
                    this.product6 = item6;
                }
            }
            if (query7.Count() == 1)
            {
                foreach (Product item7 in query7)
                {
                    this.product7 = item7;
                }
            }
            if (query8.Count() == 1)
            {
                foreach (Product item8 in query8)
                {
                    this.product8 = item8;
                }
            }
            //hieronder rij 2.
            if (query9.Count() == 1)
            {
                foreach (Product item9 in query9)
                {
                    this.product9 = item9;
                }
            }
            if (query10.Count() == 1)
            {
                foreach (Product item10 in query10)
                {
                    this.product10 = item10;
                }
            }
            if (query11.Count() == 1)
            {
                foreach (Product item11 in query11)
                {
                    this.product11 = item11;
                }
            }
            if (query12.Count() == 1)
            {
                foreach (Product item12 in query12)
                {
                    this.product12 = item12;
                }
            }

        }
        // Variablen gekopieerd uit Shopping.cshtml.cs
        public Product[] Products { get; set; }



    }

}
