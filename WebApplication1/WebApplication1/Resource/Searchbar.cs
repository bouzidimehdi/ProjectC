using System;
using System.Collections;
using System.Collections.Generic;
using WebApplication1.Data;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebApplication1.Searchbar
{
    /// <summary>
    /// Class die het zoeken via regelt op basis van punten.
    /// </summary>
    public class Searchbar
    {
        // Verbinding met database _context
        private readonly ApplicationDbContext _context;

        // Constructor die de verbinding ophaalt uit de database.
        public Searchbar(ApplicationDbContext context)
        {
            this._context = context;
        }
        private string[] stringsplitter(string searchquery) => searchquery.Split(' ');

        public Product_search[] search(string searchquery)
        {
            // Maak de zoek item tekst kleiner.
            searchquery = searchquery.ToLower();

            // Split de zoek term op in woorden.
            string[] words = this.stringsplitter(searchquery);

            // Filteren van de stop woorden.
            int k = 0;
            foreach (var word in words)
            {

                if (word == "the") words[k] = "";
                if (word == "of") words[k] = "";
                if (word == "de") words[k] = "";
                if (word == "een") words[k] = "";
                if (word == "het") words[k] = "";
                if (word == "a") words[k] = "";
                if (word == "an") words[k] = "";
                if (word == "by") words[k] = "";
                if (word == "to") words[k] = "";
                if (word == "on") words[k] = "";
                k++;
            }

            // Zoek alle producten op die in een word bevat dat in de title staat.
            List<IEnumerable> results_query = null;
            foreach (string word in words)
            {
                if (word != "")
                {
                    var query = from p in _context.Product
                        where p.QueryName.Contains(word)
                        select new product_query(p.ID, p.QueryName, p.ResponseName, p.PlatformWindows, p.PlatformLinux, p.PlatformMac, p.RecommendationCount, p.HeaderImage, p.AboutText, p.PriceCurrency, p.PriceFinal);

                    results_query.Add(query.ToList());
                }
            }

            // Maak de punten telling voor array.
            List<Product_search> results = null;
            foreach (product_query result in results_query)
            {
                Product_search final_result = new Product_search();
                final_result.points = 5;

                final_result.QueryName = result.QueryName;
                final_result.ID = result.ID;
                final_result.ResponseName = result.ResponseName;

                int recommendationpoints = 0;

                for (int i = 0; i < result.RecommendationCount; i=+ 100)
                {
                    if (i > result.RecommendationCount) final_result.points = +recommendationpoints;
                    else
                    {
                        recommendationpoints = +10;
                    }
                }

                if (result.PlatformLinux) final_result.points = +15;
                if (result.PlatformMac) final_result.points = +15;
                if (result.PlatformWindows) final_result.points = +50;

                results.Add(final_result);
            }

            // Zet de producten op volgorde van 
            Product_search[] array_results = results.OrderBy(p => p.points).ToArray();

            return array_results;

        }
    }

    /// <summary>
    /// Class die inherite van Product.
    /// Die ook een import functie heeft van een paar velden van Products.
    /// </summary>
    public class product_query : Product
    {
        public product_query(int ID, string QueryName, string ResponseName, bool PlatformWindows, bool PlatformLinux, bool PlatformMac, int RecommendationCount, string HeaderImage, string AboutText, string PriceCurrency, float PriceFinal)
        {
            this.ID = ID;
            this.QueryName = QueryName;
            this.ResponseName = ResponseName;
            this.RecommendationCount = RecommendationCount;
            this.PlatformLinux = PlatformLinux;
            this.PlatformMac = PlatformMac;
            this.PlatformWindows = PlatformWindows;
            this.HeaderImage = HeaderImage;
            this.AboutText = AboutText;
            this.PriceCurrency = PriceCurrency;
            this.PriceFinal = PriceFinal;
        }
    }

    /// <summary>
    /// Class extends van van product.
    /// Heeft als extra attribute points voor het odreren van de zoek query.
    /// </summary>
    public class Product_search : Product
    {
        public int points;
    }
}