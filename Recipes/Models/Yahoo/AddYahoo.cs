using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Recipes.Models.Yahoo
{
    public static class AddYahoo
    {
        public static void AddSymbols(RecipesEntities context)
        {
            try
            {
                List<YahooSymbol> symbols = new List<YahooSymbol>

                                                {
                                                    new YahooSymbol {YahooSymbolID = 1, YahooSymbolName = "GOOG"},
                                                    new YahooSymbol {YahooSymbolID = 2, YahooSymbolName = "AAPL"},
                                                    new YahooSymbol {YahooSymbolID = 3, YahooSymbolName = "MSFT"},
                                                    new YahooSymbol {YahooSymbolID = 4, YahooSymbolName = "YHOO"}
                                                };

                symbols.ForEach(p => context.YahooSymbols.Add(p));
                context.SaveChanges();
            }
            catch (DbEntityValidationException vex)
            {
                foreach (var err in vex.EntityValidationErrors)
                {
                    foreach (var err2 in err.ValidationErrors)
                    {
                        string msg = err2.ErrorMessage;
                    }
                }
            }
        }
    }
}
