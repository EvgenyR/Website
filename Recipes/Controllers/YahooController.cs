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
    public class YahooController : Controller
    {
        RecipesEntities db = new RecipesEntities();
        //
        // GET: /Yahoo/
        
        public ActionResult Index(int page=1)
        {
            //CookieContainer container = Authenticate();
            //CookieCollection cookies = container.GetCookies(new Uri("http://download.yahoo.com"));

            //List<Cookie> modelCookies = new List<Cookie>();

            //for (int i = 0; i < cookies.Count; i++ )
            //{
            //    Cookie cookie = cookies[i];
            //    modelCookies.Add(cookie);
            //}

            //return View(new YahooViewModel(new List<string>{"one", "two", "three"}));
            //List<YahooData> datas = GetData();
            int totalRecords;
            List<YahooData> datas = GetData(out totalRecords, pageSize: 5, pageIndex: page - 1);

            List<YahooSymbol> symbols = db.YahooSymbols.ToList();
            YahooSymbol symbol = symbols.First();
            int id = symbol.YahooSymbolID;
            return View(new YahooViewModel(id, symbol, symbols, datas, totalRecords));
        }

        public ActionResult Theory()
        {
            return View();
        }

        // helpers that take an IQueryable<Product> and a bool to indicate ascending/descending
        // and apply that ordering to the IQueryable and return the result
        private readonly IDictionary<string, Func<IQueryable<YahooData>, bool, IOrderedQueryable<YahooData>>>
            _productOrderings = new Dictionary<string, Func<IQueryable<YahooData>, bool, IOrderedQueryable<YahooData>>>
                                    {
                                        {"DataName", CreateOrderingFunc<YahooData, string>(p=>p.DataName)},
                                        {"Ask", CreateOrderingFunc<YahooData, decimal?>(p=>p.Ask)}
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
            List<YahooData> data = GetData();
            totalRecords = data.Count;

            //Func<IQueryable<YahooData>, bool, IOrderedQueryable<YahooData>> applyOrdering = _productOrderings[sort];
            //data = applyOrdering(data, sortOrder == SortDirection.Ascending);

            if(pageSize > 0 && pageIndex >=0)
            {
                data = data.Skip(pageIndex*pageSize).Take(pageSize).ToList();
            }
            return data.ToList();
        }

        public List<YahooData> GetData()
        {
            List<YahooData> datas = new List<YahooData>();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://download.finance.yahoo.com/d/quotes.csv?s=GOOG+AAPL+MSFT+YHOO&f=snd1l1t1vb3b2hg");
            //req.CookieContainer = _yahooContainer;
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader streamReader = new StreamReader(resp.GetResponseStream()))
            {
                string t = streamReader.ReadToEnd();
                string[] strings = t.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                datas = InsertData(strings);
            }
            
            return datas;
        }

        private List<YahooData> InsertData(string[] lines)
        {
            List<YahooData> datas = new List<YahooData>();
            try
            {
                foreach (string line in lines)
                {
                    if (!String.IsNullOrEmpty(line))
                    {
                        YahooData datum = GetDatum(line);
                        for (int i = 0; i < 5; i++ )
                            datas.Add(datum);
                        //_db.Data.AddObject(datum);
                        //_db.SaveChanges();
                    }
                }
                //_db.Refresh(RefreshMode.StoreWins, _db.Data);
                //DataDownloaded(this, new EventArgs());
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }
}
