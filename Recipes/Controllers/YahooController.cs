using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web.Mvc;
using System;
using System.IO;
using Recipes.Models;
using Recipes.ViewModels;
using System.Collections.Generic;
using Recipes.Models.Yahoo;
using System.Globalization;

namespace Recipes.Controllers
{
    public class YahooController : BaseController
    {
        RecipesEntities db = new RecipesEntities();
        //
        // GET: /Yahoo/

        [MetaKeywords(Constants.Constants.YahooMetaKeywords)]
        [MetaDescription(Constants.Constants.YahooMetaDescription)]
        public ActionResult Index(int page = 1, string sort = "YahooSymbolName", string sortDir = "Ascending")
        {
            int totalRecords;
            List<YahooData> datas = GetData(out totalRecords, pageSize: 5, pageIndex: page - 1, sort: sort, sortOrder: GetSortDirection(sortDir));
            return View("Index", GetFullViewModel(datas, totalRecords));
        }

        private YahooViewModel GetFullViewModel(List<YahooData> datas, int totalRecords)
        {
            List<YahooSymbol> symbols = db.YahooSymbols.ToList();
            YahooSymbol symbol = symbols.First();
            int id = symbol.YahooSymbolID;
            return new YahooViewModel(id, symbol, symbols, datas, totalRecords);
        }

        [MetaKeywords(Constants.Constants.YahooMetaKeywords)]
        [MetaDescription(Constants.Constants.YahooMetaDescription)]
        public ActionResult Theory()
        {
            return View();
        }

        // helpers that take an IQueryable<Product> and a bool to indicate ascending/descending
        // and apply that ordering to the IQueryable and return the result
        private readonly IDictionary<string, Func<IQueryable<YahooData>, bool, IOrderedQueryable<YahooData>>>
            _dataOrderings = new Dictionary<string, Func<IQueryable<YahooData>, bool, IOrderedQueryable<YahooData>>>
                                    {
                                        {"YahooSymbolName", CreateOrderingFunc<YahooData, string>(p=>p.DataName)},
                                        {"DataName", CreateOrderingFunc<YahooData, string>(p=>p.DataName)},
                                        {"Ask", CreateOrderingFunc<YahooData, decimal?>(p=>p.Ask)},
                                        {"Time", CreateOrderingFunc<YahooData, DateTime>(p=>p.DateTime)}
                                    };

        /// <summary>
        /// returns a Func that takes an IQueryable and a bool, and sorts the IQueryable (ascending or descending based on the bool).
        /// The sort is performed on the property identified by the key selector.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        private static Func<IQueryable<T>, bool, IOrderedQueryable<T>> CreateOrderingFunc<T, TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return
                (source, ascending) =>
                ascending
                    ? source.OrderBy(keySelector)
                    : source.OrderByDescending(keySelector);
        }

        public List<YahooData> GetData(out int totalRecords, int pageSize, int pageIndex, string sort = "YahooSymbolName", SortDirection sortOrder = SortDirection.Ascending )
        {
            IQueryable<YahooData> data = db.YahooData;
            totalRecords = data.Count();

            Func<IQueryable<YahooData>, bool, IOrderedQueryable<YahooData>> applyOrdering = _dataOrderings[sort];
            data = applyOrdering(data, sortOrder == SortDirection.Ascending);

            List<YahooData> result = data.ToList();
            if(pageSize > 0 && pageIndex >=0)
            {
                result = result.Skip(pageIndex*pageSize).Take(pageSize).ToList();
            }
            return result;
        }

        public List<YahooData> GetSingleSet()
        {
            List<YahooData> datas = new List<YahooData>();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://download.finance.yahoo.com/d/quotes.csv?s=GOOG+AAPL+MSFT+YHOO&f=snd1l1t1vb3b2hg");
            //req.CookieContainer = _yahooContainer;
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader streamReader = new StreamReader(resp.GetResponseStream()))
            {
                string t = streamReader.ReadToEnd();
                string[] strings = t.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                datas = ParseData(strings);
            }
            
            return datas;
        }

        public ActionResult AddDataToDB()
        {
            List<YahooData> datas = GetSingleSet();
            datas.ForEach(d => db.YahooData.Add(d));
            db.SaveChanges();

            string s = "<table><thead><tr class=\"webgrid-header\"><th>Company</th><th>Time</th><th>LTP</th><th>Volume</th><th>Ask</th><th>Bid</th><th>High</th><th>Low</th></tr></thead><tbody>";

            foreach (var yahooData in datas)
            {
                s = s + "<tr class=\"webgrid-row-style\">" + 
                    "<td class=\"company\">" + yahooData.DataName + "</td>" +
                    "<td class=\"time\">" + yahooData.DateTime.ToString("dd/MM/yyyy hh:mm") + "</td>" +
                    "<td class=\"ask\">" + yahooData.LTP + "</td>" +
                    "<td class=\"volume\">" + yahooData.Volume + "</td>" +
                    "<td class=\"ask\">" + yahooData.Ask + "</td>" +
                    "<td class=\"ask\">" + yahooData.Bid + "</td>" +
                    "<td class=\"ask\">" + yahooData.High + "</td>" +
                    "<td class=\"ask\">" + yahooData.Low + "</td>" +
                    "</tr>";
            }

            s = s + "</tbody></table>";

            return Json(new { o = s });

            //return View("Index", model);
        }

        private List<YahooData> ParseData(string[] lines)
        {
            List<YahooData> datas = new List<YahooData>();
            try
            {
                foreach (string line in lines)
                {
                    if (!String.IsNullOrEmpty(line))
                    {
                        YahooData datum = GetDatum(line);
                        datas.Add(datum);
                    }
                }
            }
            catch (Exception)
            {
                //log.Fatal("Exception in InsertData: ", ex);
            }

            return datas;
        }

        private YahooData GetDatum(string line)
        {
            var datum = new YahooData();
            try
            {
                string[] splitLine = line.Split(',');
                datum = new YahooData()
                            {
                                SymbolId = GetSymbol(splitLine[0].Replace("\"", "")),
                                DataName = splitLine[1].Replace("\"", ""),
                                Date =
                                    DateTime.ParseExact(splitLine[2].Replace("\"", ""), "MM/d/yyyy",
                                                        CultureInfo.InvariantCulture),
                                LTP = decimal.Parse(splitLine[3]),
                                Time = DateTime.Parse(splitLine[4].Replace("\"", "")),
                                Volume = decimal.Parse(splitLine[5]),
                                Ask = decimal.Parse(splitLine[6]),
                                Bid = decimal.Parse(splitLine[7]),
                                High = decimal.Parse(splitLine[8]),
                                Low = decimal.Parse(splitLine[9]),
                                DateTime = DateTime.ParseExact(splitLine[2].Replace("\"", "") + " " + splitLine[4].Replace("\"", ""), "MM/d/yyyy h:mmtt", CultureInfo.InvariantCulture)
                };
            }
            catch (Exception)
            {
                //log.Fatal("Exception in GetDatum: ", ex);
            }
            return datum;
        }

        private int GetSymbol(string name)
        {
            YahooSymbol symbol = db.YahooSymbols.Where(s => s.YahooSymbolName == name).FirstOrDefault();
            return symbol.YahooSymbolID;
        }

        public CookieContainer Authenticate()
        {
            string LoginUrl = "https://login.yahoo.com/config/login";
            string MyYahoo = "my.yahoo.com";
            string _login = "ttester414@yahoo.com";
            string _password = "123456";
            CookieContainer _yahooContainer;

            string strPostData = String.Format("login={0}&passwd={1}", _login, _password);

            // Setup the http request.
            HttpWebRequest wrWebRequest = WebRequest.Create(LoginUrl) as HttpWebRequest;
            wrWebRequest.Method = "POST";
            wrWebRequest.ContentLength = strPostData.Length;
            wrWebRequest.ContentType = "application/x-www-form-urlencoded";
            _yahooContainer = new CookieContainer();
            wrWebRequest.CookieContainer = _yahooContainer;

            // Post to the login form.
            using (StreamWriter swRequestWriter = new StreamWriter(wrWebRequest.GetRequestStream()))
            {
                swRequestWriter.Write(strPostData);
                swRequestWriter.Close();
            }

            // Get the response.
            HttpWebResponse hwrWebResponse = (HttpWebResponse)wrWebRequest.GetResponse();

            if (hwrWebResponse.ResponseUri.AbsoluteUri.Contains(MyYahoo))
            {
                //Authenticated(this, new EventArgs());
            }
            return _yahooContainer;
        }

        private SortDirection GetSortDirection(string sortDirection)
        {
            if (sortDirection != null)
            {
                if (sortDirection.Equals("DESC", StringComparison.OrdinalIgnoreCase) ||
                    sortDirection.Equals("DESCENDING", StringComparison.OrdinalIgnoreCase))
                {
                    return SortDirection.Descending;
                }
            }
            return SortDirection.Ascending;
        }
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }
}
