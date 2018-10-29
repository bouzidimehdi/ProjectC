using System;
using System.Collections;
using System.Collections.Generic;
using WebApplication1.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace WebApplication1.Searchengine
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
            string[] words_count = this.stringsplitter(searchquery);
            SearchQuery[] words = new SearchQuery[words_count.Length];

            for (int i = 0; i < words_count.Length; i++)
            {
                words[i] = new SearchQuery();
                words[i].search_query = words_count[i];
            }


            // Filteren van de stop woorden.
            int k = 0;
            foreach (SearchQuery word in words)
            {
                // Filter alle nummers als niet querable.
                double num;
                if (double.TryParse(word.search_query, out num)) words[k].queryable = false;

                if (word.search_query == "the") words[k].search_query = "";
                if (word.search_query == "of") words[k].search_query = "";
                if (word.search_query == "de") words[k].search_query = "";
                if (word.search_query == "een") words[k].search_query = "";
                if (word.search_query == "het") words[k].search_query = "";
                if (word.search_query == "a") words[k].search_query = "";
                if (word.search_query == "an") words[k].search_query = "";
                if (word.search_query == "by") words[k].search_query = "";
                if (word.search_query == "to") words[k].search_query = "";
                if (word.search_query == "on") words[k].search_query = "";
                k++;
            }

            var isNumeric = int.TryParse("123", out int n);

            // Zoek alle producten op die in een word bevat dat in de title staat.
            List<IQueryable> result_query_list = new List<IQueryable>();
            List<Product> results_query = new List<Product> { };
            foreach (SearchQuery word in words)
            {
                // Als de word veld niet leeg is of queryable is dan wordt er gezocht op dat word.
                if (word.search_query != "" && word.queryable)
                {
                    var query = from p in _context.Product
                        where p.QueryName.Contains(word.search_query)
                        select p;

                    result_query_list.Add(query);
                }
            }

            // IQueryable to list
            foreach (IQueryable query in result_query_list)
            {
                foreach (Product item in query)
                {
                    results_query.Add(item);
                }
            }

            // Maak de punten telling voor array.
            List<Product_search> results = new List<Product_search>();
            foreach (Product result in results_query)
            {
                Product_search final_result = new Product_search(result);
                final_result.points = 5;
                ;
                string[] queryname = this.stringsplitter(final_result.QueryName);

                // Controleert hoevaak een wordt voorkomt in een zin.
                var matchQuery = from word in words
                    from name in queryname
                    where name == word.search_query
                    select word;

                // Bepaalt het aantal punten opbasis van het aantal overeenkomende worden.
                final_result.points = final_result.points + matchQuery.Count() * 3000;

                // Bepaalt het aantal punten op basis van het aantal recommendations.
                final_result.points = final_result.points + result.RecommendationCount / 1000;

                if (result.PlatformLinux) final_result.points = final_result.points + 15;
                if (result.PlatformMac) final_result.points = final_result.points + 15;
                if (result.PlatformWindows) final_result.points = final_result.points + 50;

                results.Add(final_result);
            }

            // Zet de producten op volgorde van 
            Product_search[] array_results = results.OrderByDescending(p => p.points).ToArray();

            return array_results;

        }
    }

    /// <summary>
    /// Class die de zoek worden bijhoud en bijhoud of deze opgezocht mogen worden of niet.
    /// </summary>
    public class SearchQuery
    {
        public SearchQuery()
        {
            queryable = true;
        }
        public string search_query { get; set; }
        public bool queryable { get; set; }
    }

    /// <summary>
    /// Class extends van van product.
    /// Heeft als extra attribute points voor het odreren van de zoek query.
    /// </summary>
    public class Product_search : Product
    {
        public Product_search(Product product)
        {
            ID = product.ID;
            QueryID = product.QueryID;
            ResponseID = product.ResponseID;
            QueryName = product.QueryName;
            ResponseName = product.ResponseName;
            ReleaseDate = product.ReleaseDate;
            RequiredAge = product.RequiredAge;
            DemoCount = product.DemoCount;
            DeveloperCount = product.DeveloperCount;
            DLCCount = product.DLCCount;
            Metacritic = product.Metacritic;
            MovieCount = product.MovieCount;
            PackageCount = product.PackageCount;
            RecommendationCount = product.RecommendationCount;
            PublisherCount = product.PublisherCount;
            ScreenshotCount = product.ScreenshotCount;
            SteamSpyOwners = product.SteamSpyOwners;
            SteamSpyOwnersVariance = product.SteamSpyOwnersVariance;
            SteamSpyPlayersEstimate = product.SteamSpyPlayersEstimate;
            SteamSpyPlayersVariance = product.SteamSpyPlayersVariance;
            AchievementCount = product.AchievementCount;
            AchievementHighlightedCount = product.AchievementHighlightedCount;
            ControllerSupport = product.ControllerSupport;
            IsFree = product.IsFree;
            FreeVerAvail = product.FreeVerAvail;
            PurchaseAvail = product.PurchaseAvail;
            SubscriptionAvail = product.SubscriptionAvail;
            PlatformWindows = product.PlatformLinux;
            PlatformLinux = product.PlatformLinux;
            PlatformMac = product.PlatformMac;
            PCReqsHaveMin = product.PCReqsHaveMin;
            PCReqsHaveRec = product.PCReqsHaveRec;
            LinuxReqsHaveMin = product.LinuxReqsHaveMin;
            LinuxReqsHaveRec = product.LinuxReqsHaveRec;
            MacReqsHaveMin = product.MacReqsHaveMin;
            MacReqsHaveRec = product.MacReqsHaveRec;
            CategorySinglePlayer = product.CategorySinglePlayer;
            CategoryMultiplayer = product.CategoryMultiplayer;
            CategoryCoop = product.CategoryCoop;
            CategoryMMO = product.CategoryMMO;
            CategoryInAppPurchase = product.CategoryInAppPurchase;
            CategoryIncludeSrcSDK = product.CategoryIncludeSrcSDK;
            CategoryIncludeLevelEditor = product.CategoryIncludeLevelEditor;
            CategoryVRSupport = product.CategoryVRSupport;
            GenreIsNonGame = product.GenreIsNonGame;
            GenreIsIndie = product.GenreIsIndie;
            GenreIsAction = product.GenreIsAction;
            GenreIsAdventure = product.GenreIsAdventure;
            GenreIsCasual = product.GenreIsCasual;
            GenreIsStrategy = product.GenreIsStrategy;
            GenreIsRPG = product.GenreIsRPG;
            GenreIsSimulation = product.GenreIsSimulation;
            GenreIsEarlyAccess = product.GenreIsEarlyAccess;
            GenreIsFreeToPlay = product.GenreIsFreeToPlay;
            GenreIsSports = product.GenreIsSports;
            GenreIsRacing = product.GenreIsRacing;
            GenreIsMassivelyMultiplayer = product.GenreIsMassivelyMultiplayer;
            PriceCurrency = product.PriceCurrency;
            PriceInitial = product.PriceInitial;
            PriceFinal = product.PriceFinal;
            SupportEmail = product.SupportEmail;
            SupportURL = product.SupportURL;
            AboutText = product.AboutText;
            Background = product.Background;
            ShortDescrip = product.ShortDescrip;
            DetailedDescrip = product.DetailedDescrip;
            DRMNotice = product.DRMNotice;
            ExtUserAcctNotice = product.ExtUserAcctNotice;
            HeaderImage = product.HeaderImage;
            LegalNotice = product.LegalNotice;
            Reviews = product.Reviews;
            SupportedLanguages = product.SupportedLanguages;
            Website = product.Website;
            PCMinReqsText = product.PCMinReqsText;
            PCRecReqsText = product.PCRecReqsText;
            LinuxMinReqsText = product.LinuxMinReqsText;
            LinuxRecReqsText = product.LinuxRecReqsText;
            MacRecReqsText = product.MacRecReqsText;
            MacMinReqsText = product.MacMinReqsText;
        }

        public int points;
    }
}