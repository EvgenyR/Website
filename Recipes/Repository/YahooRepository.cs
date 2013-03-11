using System.Collections.Generic;
using System.Linq;
using Recipes.SeedData;
using Recipes.Models;

namespace Recipes.Repository
{
    public class YahooRepository
    {
        public List<YahooSymbol> GetYahooSymbols()
        {
            using(RecipesEntities db = new RecipesEntities())
            {
                return db.YahooSymbols.ToList();
            }
        }

        public IQueryable<YahooData> GetYahooData()
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.YahooData;
            }
        }

        public void AddYahooData(List<YahooData> datas)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                datas.ForEach(d => db.YahooData.Add(d));
                db.SaveChanges();
            }       
        }

        public int GetYahooSymbolByName(string name)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                YahooSymbol symbol = db.YahooSymbols.Where(s => s.YahooSymbolName == name).FirstOrDefault();
                return symbol.YahooSymbolID;
            }
        }
    }
}