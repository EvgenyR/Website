using System;

namespace Recipes.Models.Yahoo
{
    public class YahooData
    {
        public virtual YahooSymbol Symbol { get; set; }

        public int SymbolId { get; set; }
        public int YahooDataID { get; set; }
        public string DataName { get; set; }
        public DateTime Date { get; set; }
        public decimal LTP { get; set; }
        public DateTime Time { get; set; }
        public decimal Volume { get; set; }
        public decimal Ask { get; set; }
        public decimal Bid { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public DateTime DateTime { get; set; }
    }
}