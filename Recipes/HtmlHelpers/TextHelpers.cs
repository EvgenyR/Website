using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlHelpers
{
    public static class TextHelpers
    {
        public static IHtmlString HighLightSyntax(this HtmlHelper helper)
        {
            string script = "<script type=\"text/javascript\">SyntaxHighlighter.all()</script>";
            return new HtmlString(script);
        }

        public static IHtmlString SearchTheory(this HtmlHelper helper)
        {
            string contents = @"<p><b>Automatic extraction of Google search results</b></p><p>The page gets results from Google search by two means.</p><p>1. Using the HtmlAgilityPack HTML parser, the Google search is returned with System.Net.Webclient, then the HTML is parsed and links are extracted. Here is the code for retrieving the HTML</p>";

            string code1 = "<pre class=\"brush: csharp\">public static WebClient webClient = new WebClient();" +
 
            @"public static string GetSearchResultHtlm(string keywords)
            {
                StringBuilder sb = new StringBuilder('http://www.google.com/search?q=');
                sb.Append(keywords);
                return webClient.DownloadString(sb.ToString());
            }</pre><p>And here is the example of parsing the HTML to extract the actual links.</p>" + 
                        "<pre class=\"brush: csharp\">public static Regex extractUrl = new Regex(@\"[&?](?:q|url)=([^&]+)\", RegexOptions.Compiled);" +
 
            @"public static List&lt;String&gt; ParseSearchResultHtml(string html)
            {
                List&lt;String&gt; searchResults = new List&lt;string&gt;();
 
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
 
                var nodes = (from node in doc.DocumentNode.SelectNodes('//a')
                             let href = node.Attributes['href']
                             where null != href
                             where href.Value.Contains('/url?') || href.Value.Contains('?url=')
                             select href.Value).ToList();
 
                foreach (var node in nodes)
                {
                    var match = extractUrl.Match(node);
                    string test = HttpUtility.UrlDecode(match.Groups[1].Value);
                    searchResults.Add(test);
                }
 
                return searchResults;
            }</pre>";
            
            string contents2 = "<p>The drawbacks of this method are that Google will server 503 errors if it suspects you are trying to automate the calls to the search engine.</p><p>2. Using the Google API. The easiest way to do that was to use Google API for .NET. When it is referenced, the following code will return the results</p>";
            
            string code2 = "<pre class=\"brush: csharp\">private void btnSearch_Click(object sender, EventArgs e)" +
            @"{
             string searchTerms = txtTerms.Text;
             List&lt;string&gt; GoogleApiResults = GoogleAPI.StringResultList(searchTerms, 100);
            }
 
            public static class GoogleAPI
            {
             public static GwebSearchClient client = new GwebSearchClient("");
 
             public static List&lt;String&gt; StringResultList(string terms, int number)
             {
              IList&lt;IWebResult&gt; list = client.Search(terms, number);
              List&lt;String&gt; results = new List&lt;string&gt;();
              foreach (var result in list)
              {
               results.Add(result.Url);
              }
              return results;
             }
            }</pre><p>" +
            
            @"The drawbacks are that the API is deprecated, the number of search results returned is limited to 64 and the number of calls to the API per day is limited.</p><p><b>References:</b></p><a href='http://gapi4net.codeplex.com/'>Google API for .NET</a><br/><a href='https://developers.google.com/web-search/docs/'>Developer's guide to Google Search API</a><br/><a href='https://developers.google.com/errors/'>Error description which specifies that automated requests are prohibited</a><br/><a href='http://stackoverflow.com/questions/5121090/google-search-api'>Google Search API</a><br/><a href='http://stackoverflow.com/questions/6084096/what-free-web-search-apis-are-available/8666532'>What free web search api's are available?</a>";

            return new HtmlString(contents + code1 + contents2 + code2);
        }

        public static IHtmlString StoneTheory(this HtmlHelper helper)
        {
            string contents = @"<p><b>Stepping Stone Markov Chain model</b></p><p>A Markov chain is a process which can be in a number of states. The process starts in one of the states
                and moves successively from one to another. Each move is called a step. At each step a process has a probability to move to another state, and the probability does not depend
                on any of the previous states of the process. That is why such process is called “memoryless”.</p><p>Example: In a weather model, a day can be either nice, rainy or snowy.
                If the day is nice, the next day will be either rainy or snowy with 50% probability. If the day is rainy or snowy, it will stay the same with 50% probability, or will change 
                to one of the other two possibilities with 25% probability. This is a Markov chain because the process determines its next state base on the current state only, without any prior information.
                The probabilities can be presented in the transition matrix.</p><p align='center'><img src=http://4.bp.blogspot.com/-S0b0j0qjybU/UFJP44P0CgI/AAAAAAAABJ0/dpLqNRS8M_o/s1600/2.png></img></p><p>The 
                first row presents the probabilities of the next day’s weather if today is rainy (R): 1/2 that it will remain rainy, 1/4 that it will be nice and 1/4 that it will be snowy. The sum of 
                probabilities across the row must be equal to 1.</p><p>The 'Stepping Stone' model is another example that has been used in the study of genetics. In this model we have an n-by-n 
                array of squares, and each square is initially any one of k different colors. For each step, a square is chosen at random. This square then chooses one of its eight neighbors at random 
                and assumes the color of that neighbor. To avoid boundary problems, we assume that if a square S is on the left-hand boundary, say, but not at a corner, it is adjacent to the square T 
                on the right-hand boundary in the same row as S, and S is also adjacent to the squares just above and below T. A similar assumption is made about squares on the upper and lower boundaries. 
                With these adjacencies, each square in the array is adjacent to exactly eight other squares.</p><p>A state in this Markov chain is a description of the color of each square. This is an example
                of a Markov chain that is easy to simulate but difficult to analyze in terms of its transition matrix. The program simulates this chain. It starts with a random initial configuration of eight 
                colors with n = 50.</p><p>Future goals: make number of colours k and array dimension n configurable. Improve the visual representation of the model.</p>";

            return new HtmlString(contents);
        }

        public static IHtmlString GameTheory(this HtmlHelper helper)
        {
            string contents = @"<p><b>Game Rules [1]</b></p><p>The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician 
                John Horton Conway in 1970.</p><p>The universe of the Game of Life is an infinite two-dimensional orthogonal grid of square cells, each of which is in one of two 
                possible states, alive or dead. Every cell interacts with its eight neighbours, which are the cells that are horizontally, vertically, or diagonally adjacent. 
                At each step in time, the following transitions occur:</p><p><ul><li>Any live cell with fewer than two live neighbours dies, as if caused by under-population.</li>
                <li>Any live cell with two or three live neighbours lives on to the next generation.</li><li>Any live cell with more than three live neighbours dies, as if by 
                overcrowding.</li><li>Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.</li></ul></p><p>The initial pattern constitutes the 
                seed of the system. The first generation is created by applying the above rules simultaneously to every cell in the seed—births and deaths occur simultaneously, 
                and the discrete moment at which this happens is sometimes called a tick (in other words, each generation is a pure function of the preceding one). The rules continue 
                to be applied repeatedly to create further generations.</p><p><b>Implementation</b></p><p>[1] 
                <a href=&quot;http://en.wikipedia.org/wiki/Conway%27s_game_of_life&quot;>Conway's Game Of Life</a></p>";

            string t =
                "<p>To refresh the page every second, javaScript <b></b>setInterval function is used to load the partial view into the div. A method in the controller generates the partial view.</p><p><b>The Controller</b></p><pre class=\"brush: csharp\">public class GameController : BaseController" +
                @"{
                public ActionResult Index()
                {
                    GameOfLifeHelpers.InitializeGame();
                    return View(new HtmlString(GameOfLifeHelpers.table.ToString()));
                }

                [OutputCache(NoStore = true, Location = OutputCacheLocation.Client, Duration = 1)]
                public ActionResult Update()
                {
                    return PartialView(&quot;_Table&quot;, NextIteration());
                }

                public HtmlString NextIteration()
                {
                    GameOfLifeHelpers.DrawNextIteration();
                    return new HtmlString(GameOfLifeHelpers.table.ToString());
                }
            }</pre><p>The partial view is called <b>_Table</b> and is nothing more than the <b>HtmlString</b>.</p><p><b>_Table.cshtml</b></p><pre class=""brush: csharp"">@model HtmlString
           
            @{ Layout = null; }

            @Model</pre><p>The model is just the <b>HtmlString</b> which gets rendered, and the <b>HtmlString</b> itself is just a simple table of a specified number of cells.</p><p><b>Index.cshtml</b></p><pre class=""brush: xml"">&lt;script type=&quot;text/javascript&quot;&gt;

                var timerID;

                function Start() {
                    timerID = setInterval(""$('#update').load('/Game/Update')"", 1000);
                }

                function Stop() {
                    clearInterval(timerID);
                }
            &lt;/script&gt;
            @model HtmlString
            @{
                ViewBag.Title = ""Index"";
            }
            @Html.BodyTagUpdate(""game"")
            &lt;div id=""page""&gt;
                @Html.Partial(""_GameNav"")
                &lt;div id=""update"" style=""border: 1px solid #AAA""&gt;
                    @{Html.RenderPartial(""_Table"", Model);}
                &lt;/div&gt;
                &lt;div style=""height: 25px""&gt;
                    &lt;input id=""stop"" type=""button"" onclick=""Stop();"" value=""Stop"" /&gt;&lt;input id=""start""
                        type=""button"" onclick=""Start();"" value=""Start"" /&gt;
                &lt;/div&gt;
            &lt;/div&gt;</pre><p>Note how the interval is set to 1000 ms and the <b>OutputCache</b> duration in the controller is set to the same value. Every second the call to load will return a partial view from the <b>Update</b> method. What does the <b>Update</b> method return? When the game starts, and empty html table is created with each cell having a blue background.</p><pre class=""brush: csharp"">public static void NewGameTable()
            {
                table = new StringBuilder(@""&lt;table border=1 bordercolor=black cellspacing=0 cellpadding=0&gt;"");

                for (int i = 0; i &lt; y; i++)
                {
                    table.Append(""&lt;tr&gt;"");

                    for (int j = 0; j &lt; x; j++)
                    {
                        table.Append(""&lt;td width=10px height=10px bgcolor=#0276FD&gt;&lt;/td&gt;"");
                    }

                    table.Append(""&lt;/tr&gt;"");
                }

                table.Append(""&lt;/table&gt;"");
            }</pre><p>Then, on each iteration, a new boolean array is filled to specify which cells will be ""alive"".</p><pre class=""brush: csharp"">public static void DrawNextIteration()
            {
                bool[,] arrCurrent = counter % 2 == 0 ? arrOne : arrTwo;
                bool[,] arrNext = counter % 2 == 0 ? arrTwo : arrOne;

                FillArray(arrNext, arrCurrent);
                counter++;

                for (int i = 0; i &lt; y; i++)
                {
                    for (int j = 0; j &lt; x; j++)
                    {
                        if (arrNext[i, j] != arrCurrent[i, j])
                        {
                            table = arrNext[i, j] ? GameOfLifeTableReplaceCell(i, j, ""#FF0000"", table) : GameOfLifeTableReplaceCell(i, j, ""#0276FD"", table);
                        }
                    }
                }
            }</pre><p>The function that replaces the cell is very simple - it calculates the position where the font for the cell is specified based on the coordinates and makes the cell color red if it went from ""dead"" to ""alive"", and vice versa.</p><pre class=""brush: csharp"">public static StringBuilder GameOfLifeTableReplaceCell(int i, int j, string colour, StringBuilder sb)
            {
                const int rowLength = 48*x + 9;
                const int cellLength = 48;

                int start = 62 + i * rowLength + 4 + j * cellLength + 35;

                sb.Remove(start, 7);
                sb.Insert(start, colour);

                return sb;
            }</pre><p>Function <b>CheckCell</b> applies game rules to a cell to check if it will be alive or dead in the next iteration.</p><pre class=""brush: csharp"">public static bool CheckCell(bool[,] arr, int i, int j)
            {
                int nextI = i == (x - 1) ? 0 : i + 1;
                int prevI = i == 0 ? x - 1 : i - 1;
                int nextJ = j == (y - 1) ? 0 : j + 1;
                int prevJ = j == 0 ? y - 1 : j - 1;

                bool[] neighbours = new[]{
                                            arr[prevI, prevJ],   arr[i, prevJ],   arr[nextI, prevJ],
                                            arr[prevI, j],       arr[nextI, j],   arr[prevI, nextJ],
                                            arr[i, nextJ],       arr[nextI, nextJ]
                                        };

                int val = neighbours.Count(c =&gt; c);

                if (arr[i, j])
                    return (val &gt;= 2 && val &lt;= 3) ? true : false;
                else
                    return (val == 3) ? true : false;
            }        
            </pre><p>The rest should be straightforward.</p>";

            contents += t;
            return new HtmlString(contents);
        }
    }
}