﻿using System;
using System.Collections;
using System.Collections.Generic;
using WebApplication1.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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

        public Product[] search(string searchquery)
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
            Product[] results_query = new Product[] { };
            foreach(string word in words)
            {
                if (word != "")
                {
                    var query = from p in _context.Product
                        where p.QueryName.Contains(word)
                                select p;

                    results_query = query.ToArray();
                }
            }

            // Maak de punten telling voor array.
            List<Product_search> results = new List<Product_search>();
            foreach (Product result in results_query)
            {
                Product_search final_result = new Product_search(result);
                final_result.points = 5;;

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

            Product[] array_products = array_results;

            return array_products;

        }

        public Product[] search_simple(string searchquery)
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
            Product[] results_query = new Product[] { };
            foreach(string word in words)
            {
                if (word != "")
                {
                    var query = from p in _context.Product
                        where p.QueryName.Contains(word)
                        select p;

                    results_query = query.ToArray();
                }
            }

            return results_query;

        }
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