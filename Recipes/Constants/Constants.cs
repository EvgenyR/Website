using Recipes.Models;

namespace Constants
{
    public static class Constants
    {
        public static string DataExceptionMessage = "Unable to save changes - data exception";

        public static string IngredientNameTooShort = "Ingredient Name has to be at least 3 characters long!";
        public static string IngredientNameTooLong = "Ingredient Name has to be less than 50 characters long!";

        public static string CategoryNameTooShort = "Category Name has to be at least 3 characters long!";
        public static string CategoryNameTooLong = "Category Name has to be less than 50 characters long!";
        public static string CategoryDescTooShort = "Category Description has to be at least 10 characters long!";
        public static string CategoryDescTooLong = "Category Descripton has to be less than 100 characters long!";

        public static string RecipeNameTooShort = "Recipe Name has to be at least 3 characters long!";
        public static string RecipeNameTooLong = "Recipe Name is too long! Sure you can make it shorter.";
        public static string RecipeHasNoIngredients = "The recipe needs at least one ingredient!";
        public static string RecipeHasNoCategory = "The recipe needs to belong to a category, please choose one!";
        public static string RecipeHasNoSubCategory = "The recipe needs to belong to a subcategory, please choose one!";

        public static decimal FatCalPerGram = 9;
        public static decimal ProtCalPerGram = 4;
        public static decimal CarbCalPerGram = 4;

        public const string BlogMetaKeywords = "C#, MVC, Entity Framework, SQL Compact, Database, Programming, Blog Engine";
        public const string BlogMetaDescription = "The Blog engine is implemented using MVC Framework and Entity Framework using the Code First approach. The goal of the development was to learn developing applications using MVC framework and Entity Framework, and also to provide an alternate hosting for my own blog.";

        public const string RecipeMetaKeywords = "C#, MVC, Entity Framework, SQL Compact, Database, Programming";
        public const string RecipeMetaDescription = "The Recipe database is implemented using MVC Framework and Entity Framework using the Code First approach. The goal of the development was to learn developing applications using MVC framework and Entity Framework.";

        public const string StoneMetaKeywords = "C#, MVC, Markov Chain, Stepping Stone, Programming";
        public const string StoneMetaDescription = "Stepping Stone Markov Chain model is an example that has been used in the study of genetics. In this model we have an n-by-n array of squares, and each square is initially any one of k different colors. For each step, a square is chosen at random. This square then chooses one of its eight neighbors at random and assumes the color of that neighbor";

        public const string YahooMetaKeywords = "C#, MVC, Finance, Stock data, Quote, HttpWebRequest, WebGrid, Programming";
        public const string YahooMetaDescription = "WebGrid is an HTML helper provided as part of the MVC framework to simplify rendering tabular data. Stock data can be downloaded from http://finance.yahoo.com/d/quotes.csv?s=[stock symbol string]&f=[special tags]. The data is then loaded into the paginated, sortable WebGrid control";

        public const string GameMetaKeywords = "C#, MVC, Game of Life, Programming";
        public const string GameMetaDescription = "The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970. This page implements the Game of Life using MVC Framework";

        public const string MainMetaKeywords = "C#, MVC, Developer, Programmer, WebSite, Blog";
        public const string MainMetaDescription = "The goal of this website is to provide some information about Evgeny and Software Development";

        public const string SearchMetaKeywords = "C#, MVC, HTTP, Google API, Search, Programming, Development";
        public const string SearchMetaDescription = "Automatic extraction of Google search results. The page gets results from Google search by two means: First,using the HtmlAgilityPack HTML parser, the Google search is returned with System.Net.Webclient, then the HTML is parsed and links are extracted. Second, using Google API for .NET.";

        public const string PhotoboxMetaKeywords = "CSS3 jQuery Photobox Image Gallery";
        public const string PhotoboxMetaDescription = "Implementation of Photobox - a practical lightweight image gallery script";

        public const string JQGameMetaKeywords = "jQuery, MVC, Game of Life, HTML, CSS";
        public const string JQGameMetaDescription = "jQuery Implementation of Conway's Game of Life";
    }
}