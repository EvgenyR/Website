using System.Collections.Generic;
using Recipes.Models.Yahoo;

namespace Recipes.ViewModels
{
    public class YahooViewModel
    {
        //public List<Cookie> Cookies { get; set; }

        public List<string> strings { get; set; }

        public List<YahooData> Datas { get; set; }
        public List<YahooSymbol> Symbols { get; set; }
        public YahooSymbol Symbol { get; set; }
        public int YahooSymbolID { get; set; }

        public YahooViewModel(int symbolid, YahooSymbol symbol, List<YahooSymbol> symbols, List<YahooData> datas)
        {
            Symbol = symbol;
            YahooSymbolID = symbolid;
            Symbols = symbols;
            Datas = datas;
        }

        /*
        public YahooViewModel(List<Cookie> cookies)
        {
            Cookies = cookies;
        }*/
    }
}