using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Google.API.Search;

namespace Recipes.HtmlHelpers
{
    public static class SearchHelpers
    {
        public static WebClient webClient = new WebClient();
        public static Regex extractUrl = new Regex(@"[&?](?:q|url)=([^&]+)", RegexOptions.Compiled);

        public static string GetSearchResultHtlm(string keywords)
        {
            StringBuilder sb = new StringBuilder("http://www.google.com/search?q=");
            sb.Append(keywords);
            return webClient.DownloadString(sb.ToString());
        }

        public static List<String> ParseSearchResultHtml(string html)
        {
            List<String> searchResults = new List<string>();

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var nodes = (from node in doc.DocumentNode.SelectNodes("//a")
                         let href = node.Attributes["href"]
                         where null != href
                         where href.Value.Contains("/url?") || href.Value.Contains("?url=")
                         select href.Value).ToList();

            foreach (var node in nodes)
            {
                var match = extractUrl.Match(node);
                string test = HttpUtility.UrlDecode(match.Groups[1].Value);
                searchResults.Add(test);
            }

            return searchResults;
        }

        public static List<String> GoogleAPIStringResultList(string terms, int number)
        {
            IList<IWebResult> list;
            GwebSearchClient client = new GwebSearchClient("");
            List<String> results = new List<string>();

            try
            {
                list = client.Search(terms, number);
                foreach (var result in list)
                {
                    results.Add(result.Url);
                }
            }
            catch(Exception ex)
            {
                results.Add(ex.ToString());
            }

            return results;
        }

        public static string ResultList(string header, List<String> results)
        {
            StringBuilder sb = new StringBuilder("<div>");
            sb.Append("<form><fieldset><legend>");
            sb.Append(header);
            sb.Append("</legend>");

            sb.Append("<ul>");
            foreach (var result in results)
            {
                sb.Append("<li class='styled'>");
                sb.Append("<a href='");
                sb.Append(result);
                sb.Append("'>");
                sb.Append(result);
                sb.Append("</a>");
                sb.Append("</li>");
            }
            sb.Append("</ul>");
            sb.Append("</fieldset></form>");
            sb.Append("</div>");
            return sb.ToString();
        }
    }
}