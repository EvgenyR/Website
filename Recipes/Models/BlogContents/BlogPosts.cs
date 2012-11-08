
namespace Recipes.Models.BlogContents
{
    public static class BlogPosts
    {
        public const string content_07092012_b =
            "<p>You will need:<ul><li><a href=\"http://htmlagilitypack.codeplex.com/\">HtmlAgilityPack</a> HTML Parser</li><li>Development environment</li><li>Internet connection</li></ul></p><p>Create a Visual Studio project, for example C# Windows Forms application. Drop a <b>TextBox</b>, a <b>Button</b> and a <b>ListView</b> on the form. Creat a class for the methods to be used, let's say <b>Helper.cs</b>. First, I'm using the <b>System.Net.Webclient</b> to call Google and get a page of search results.</p><pre class=\"brush: csharp\">" +

            @"public static WebClient webClient = new WebClient();

            public static string GetSearchResultHtlm(string keywords)
            {
                StringBuilder sb = new StringBuilder(""http://www.google.com/search?q="");
                sb.Append(keywords);
                return webClient.DownloadString(sb.ToString());
            }" +

            "</pre>";

        public const string content_07092012_r = "<p>The string that is returned is the html of the first page of the Google search for the string that is passed to the method. Opened in the web browser, it will look something like this</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><a href=\"http://1.bp.blogspot.com/-zxDpRcouMs0/UEbx0fDzesI/AAAAAAAABFQ/tCO-XaW9PpA/s1600/1.png\" imageanchor=\"1\" style=\"margin-left:1em; margin-right:1em\"><img border=\"0\" height=\"320\" width=\"297\" src=\"http://1.bp.blogspot.com/-zxDpRcouMs0/UEbx0fDzesI/AAAAAAAABFQ/tCO-XaW9PpA/s320/1.png\" /></a></div><p align=\"center\">Google search result page</p><p>What I want to extract is the actual links, which are marked in red on the screenshot above. Here I'm going to use <b>HtmlAgilityPack</b> to load the string into the <b>HtmlDocument</b> object. After the string is loaded, I will use a simple LINQ query to extract the nodes that match certain conditions: They are html links (a href), and the URL of the link contains either <b>\"/url?\"</b> or <b>\"?url=\"</b>. By this point, I get quite and unreadable list of values.</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><a href=\"http://1.bp.blogspot.com/-j6lEU61m_AQ/UEbx09VZE7I/AAAAAAAABFc/YPdWzf3c1XQ/s1600/2.png\" imageanchor=\"1\" style=\"margin-left:1em; margin-right:1em\"><img border=\"0\" height=\"61\" width=\"320\" src=\"http://1.bp.blogspot.com/-j6lEU61m_AQ/UEbx09VZE7I/AAAAAAAABFc/YPdWzf3c1XQ/s320/2.png\" /></a></div><p align=\"center\">Raw URLs</p><p>To bring it into readable form, I'll match it to a regular expression and then load the results into the <b>ListView</b>. Here is the code:</p><pre class=\"brush: csharp\">" +

            @"public static Regex extractUrl = new Regex(@""[&?](?:q|url)=([^&]+)"", RegexOptions.Compiled);

            public static List&lt;String&gt; ParseSearchResultHtml(string html)
            {
                List&lt;String&gt; searchResults = new List&lt;string&gt;();

                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var nodes = (from node in doc.DocumentNode.SelectNodes(""//a"")
                             let href = node.Attributes[""href""]
                             where null != href
                             where href.Value.Contains(""/url?"") || href.Value.Contains(""?url="")
                             select href.Value).ToList();

                foreach (var node in nodes)
                {
                    var match = extractUrl.Match(node);
                    string test = HttpUtility.UrlDecode(match.Groups[1].Value);
                    searchResults.Add(test);
                }

                return searchResults;
            }" +

            "</pre><p>Here is the result:</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><a href=\"http://3.bp.blogspot.com/-QVsWrmIXGj8/UEbx1eIxZNI/AAAAAAAABFo/C0XmdtYVLJw/s1600/3.png\" imageanchor=\"1\" style=\"margin-left:1em; margin-right:1em\"><img border=\"0\" height=\"221\" width=\"320\" src=\"http://3.bp.blogspot.com/-QVsWrmIXGj8/UEbx1eIxZNI/AAAAAAAABFo/C0XmdtYVLJw/s320/3.png\" /></a></div><p align=\"center\">Final Results</p><p>I'm not quite sure why this may be useful, but as an exercise it is possible to add an option to parse through a certain number of pages, rather than just the first page. But if you try to run those queries in an automated mode, Google will soon start serving 503 errors to you.</p>";


        public const string content_03102012_b =
            "<p>When I have a long list on a web page, I would like to give the user an option to hide it. Turns out that is simple to do with a little bit of <b>jQuery</b>. All the contents that I would like to hide or show would go into a div element. Next to it, I will add a link to toggle the hide/show behaviour. Here's how it looks in my code:</p><pre class=\"brush: xml\">" +

            @"&lt;div class=""buttonlink""&gt;
             &lt;a href=""#"" class=""show_hide""&gt;Show/Hide List&lt;/a&gt;
             &lt;/div&gt;
            &lt;div class=""slidingDiv""&gt;
            @foreach (var item in Model.Recipes)
            {
              &lt;ol&gt;
                &lt;li class=""styled""&gt;
                &lt;div class=""display-button""&gt;@Html.ActionLink(""Edit"", ""Edit"", new { id = item.RecipeID })
                &lt;/div&gt;
                &lt;div class=""display-button""&gt;@Html.ActionLink(""Details"", ""Details"", new { id = item.RecipeID })&lt;/div&gt;
                &lt;div class=""display-button""&gt;@Html.ActionLink(""Delete"", ""Delete"", new { id = item.RecipeID })&lt;/div&gt;
                &lt;div class=""display-info""&gt;@item.RecipeName&lt;/div&gt;
                &lt;/li&gt;<br/>
                &lt;/ol&gt;<br/>
            }<br/>
            &lt;a href=""#"" cla<br/>ss=""show_hide""&gt;Hide&lt;/a&gt;
            &lt;/div&gt;<br/>" +
            "</pre>";

            public const string content_03102012_r = "<p>Here is the jQuery function that is called when the link is clicked</p><pre class=\"brush: jscript\">" +

            @"$(document).ready(function () {<br/>
                $("".slidingDiv"").hide();<br/>
                $("".show_hide"").show();<br/>
                $('.show_hide').click(function () {<br/>
                $("".slidingDiv"").slideToggle();<br/>
                });<br/>
            });<br/>" +

            "</pre><p>And the styles for the classes that I've just introduced above.</p><pre class=\"brush: css\">" +
            
            @".slidingDiv {<br/>
                height:300px;<br/>
                padding:20px;<br/>
                margin-top:35px;<br/>
                margin-bottom:10px;<br/>
            }<br/>
            .show_hide {<br/>
                display:none;<br/>
            }<br/>" + 
            
            "</pre><p>That's it.</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><a href=\"http://4.bp.blogspot.com/-q9MqGc1LXhI/UG02_CqIJVI/AAAAAAAABLg/REfr0SMG1BI/s1600/1.png\" imageanchor=\"1\" style=\"margin-left:1em; margin-right:1em\"><img border=\"0\" height=\"207\" width=\"320\" src=\"http://4.bp.blogspot.com/-q9MqGc1LXhI/UG02_CqIJVI/AAAAAAAABLg/REfr0SMG1BI/s320/1.png\" /></a></div><p align=\"center\">Shown</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><a href=\"http://3.bp.blogspot.com/-lBgp-Wh5xzg/UG02_iwB16I/AAAAAAAABLs/7S2ItkNT6Z0/s1600/2.png\" imageanchor=\"1\" style=\"margin-left:1em; margin-right:1em\"><img border=\"0\" height=\"189\" width=\"320\" src=\"http://3.bp.blogspot.com/-lBgp-Wh5xzg/UG02_iwB16I/AAAAAAAABLs/7S2ItkNT6Z0/s320/2.png\" /></a></div><p align=\"center\">Hidden</p>" +
            "<p><b>References</b></p><a href=\"http://stackoverflow.com/questions/3394996/jquery-show-hide-div\">jquery show/hide div</a><br/><a href=\"http://papermashup.com/simple-jquery-showhide-div/\">Simple jQuery Show/Hide Div</a><br/><a href=\"http://jsfiddle.net/mattball/rPYLK/\">Fiddle</a><br/>";

        public const string content_12082012_b =
            "<p>Today I had to perform a fairly specific task: restrict access to a Windows 7 folder to a single user. I think I found the way to do it properly, and it is not a straightforward task. Before I forget, I might keep a record of all actions required because I did not find a clear sequence anywhere on the net. It will only take 10 easy steps.</p>";

        public const string content_12082012_r = "<p>Let's assume there is a folder called <b>Bob's Documents</b> where only Bob, and not even the <b>Admin</b>, should have access.</p><ol><li>Right-click on <b>Bob's Documents</b> and select <b>Properties</b></li><div class=\"separator\" style=\"clear: both; text-align: center;\"><a href=\"http://2.bp.blogspot.com/-dMe0CEBvxZ8/UCg9SSny_nI/AAAAAAAABDA/ZZwUhdEKM98/s1600/Untitled00.png\" imageanchor=\"1\" style=\"margin-left:1em; margin-right:1em\"><img border=\"0\" height=\"209\" width=\"320\" src=\"http://2.bp.blogspot.com/-dMe0CEBvxZ8/UCg9SSny_nI/AAAAAAAABDA/ZZwUhdEKM98/s320/Untitled00.png\" /></a></div><p align=\"center\">Select Bob's Documents <b>Properties</b></p><li><b>Bob's Documents Properties</b> window will open. Switch to <b>Security</b> tab and click <b>Advanced</b> button.</li><div class=\"separator\" style=\"clear: both; text-align: center;\"><a href=\"http://4.bp.blogspot.com/-QaH7Te4GvpY/UCg9SgWLRVI/AAAAAAAABDM/OrazYUy6bkY/s1600/Untitled01.png\" imageanchor=\"1\" style=\"margin-left:1em; margin-right:1em\"><img border=\"0\" height=\"320\" width=\"246\" src=\"http://4.bp.blogspot.com/-QaH7Te4GvpY/UCg9SgWLRVI/AAAAAAAABDM/OrazYUy6bkY/s320/Untitled01.png\" /></a></div>"
        +
        "<p align=\"center\">Bob's Documents Properties</p><li><b>Advanced Security Settings for Bob's Documents</b> will open. On the <b>Permissions</b> tab, Click <b>Change Permissions</b> button.</li><div class=\"separator\" style=\"clear: both; text-align: center;\"><a href=\"http://3.bp.blogspot.com/-a7ZbFEu57Vw/UCg9S1fND3I/AAAAAAAABDY/mqKCELLvFZQ/s1600/Untitled02.png\" imageanchor=\"1\" style=\"margin-left:1em; margin-right:1em\"><img border=\"0\" height=\"206\" width=\"320\" src=\"http://3.bp.blogspot.com/-a7ZbFEu57Vw/UCg9S1fND3I/AAAAAAAABDY/mqKCELLvFZQ/s320/Untitled02.png\" /></a></div>"
        +
        "<p align=\"center\">Advanced Security Settings for Bob's Documents</p><li>Another window will open. Unfortunately, it's too called <b>Advanced Security Settings for Bob's Documents</b>, adding to confusion. In this new window, untick <b>Include inheritable permissions from this object's parent</b> - that will simplify things a lot, because we only care about permissions to this folder, not its parent folder.</li><div class=\"separator\" style=\"clear: both; text-align: center;\"><a href=\"http://4.bp.blogspot.com/-wWFN3mJr5o0/UCg9TC6lgPI/AAAAAAAABDk/9bRtE7yoG7w/s1600/Untitled03.png\" imageanchor=\"1\" style=\"margin-left:1em; margin-right:1em\"><img border=\"0\" height=\"218\" width=\"320\" src=\"http://4.bp.blogspot.com/-wWFN3mJr5o0/UCg9TC6lgPI/AAAAAAAABDk/9bRtE7yoG7w/s320/Untitled03.png\" /></a></div>"
        +
        "<p align=\"center\">Advanced Security Settings for Bob's Documents - but not the same one!</p><li>As soon as the chechbox is unticked, a warning called <b>Windows Security</b> will pop up. Since we're getting rid of parent permissions, click <b>Remove</b>.</li><div class=\"separator\" style=\"clear: both; text-align: center;\">"
        +
        "<a href=\"http://2.bp.blogspot.com/-kYY21szUGvs/UCg8E6fEfcI/AAAAAAAABC0/1YTnoumTHb0/s1600/Untitled04.png\" imageanchor=\"1\" style=\"margin-left:1em; margin-right:1em\"><img border=\"0\" height=\"146\" width=\"320\" src=\"http://2.bp.blogspot.com/-kYY21szUGvs/UCg8E6fEfcI/AAAAAAAABC0/1YTnoumTHb0/s320/Untitled04.png\" /></a></div><p align=\"center\"> "
        +
        "<b>Windows Security</b> warning</p><li>All permissions should have disappeared from the <b>Permission entries</b>. Now click <b>Add</b>.</li><li><b>Select User or Group</b> window will open. In <b>Enter the object name to select</b>, type Bob and click <b>Check Names</b> to make sure there is no typo. "
        +
        "Bob's name should resolve to PCName\\Bob.</li><div class=\"separator\" style=\"clear: both; text-align: center;\"><a href=\"http://1.bp.blogspot.com/-zrsGWl30oDw/UCg8Eh58kbI/AAAAAAAABCo/AZl4DUFqe6w/s1600/Untitled05.png\" imageanchor=\"1\" style=\"margin-left:1em; margin-right:1em\"><img border=\"0\" height=\"170\" "
        +
        "width=\"320\" src=\"http://1.bp.blogspot.com/-zrsGWl30oDw/UCg8Eh58kbI/AAAAAAAABCo/AZl4DUFqe6w/s320/Untitled05.png\" /></a></div><p align=\"center\">Select User or Group</p><li>Click <b>OK</b>. Now the <b>Permissions Entry for Bob's Documents</b> window will pop up. Let's give Bob full control - click the checkbox across from <b>Full Control</b> under <b>Allow</b>. All other checkboxes under <b>Allow</b> will select automatically. Click <b>OK</b> to close this window.</li><div class=\"separator\" style=\"clear: both; text-align: center;\"><a href=\"http://1.bp.blogspot.com/-KjhuD2ebT1k/UCg8EW-5UdI/AAAAAAAABCc/4ta4-IT-Zg4/s1600/Untitled06.png\" imageanchor=\"1\" style=\"margin-left:1em; margin-right:1em\"><img border=\"0\" height=\"320\" width=\"250\" src=\"http://1.bp.blogspot.com/-KjhuD2ebT1k/UCg8EW-5UdI/AAAAAAAABCc/4ta4-IT-Zg4/s320/Untitled06.png\" /></a></div><p align=\"center\">Permissions Entry for Bob's Documents</p><li>About done. Click <b>OK</b> in <b>Advanced Security Settings for Bob's Documents</b> to close it, and in another <b>Advanced Security Settings for Bob's Documents</b> to close it too, and <b>OK</b> in <b>Bob's Documents Properties</b>.</li><li>Try to browse to <b>Bob's Documents</b>. Even if you're on <b>Administrator</b> account, you should not be able to, but you should if you are logged in as Bob.</li><div class=\"separator\" style=\"clear: both; text-align: center;\"><a href=\"http://4.bp.blogspot.com/-o6D7UJbi200/UCg8EKsNOdI/AAAAAAAABCQ/68g828PrdUk/s1600/Untitled07.png\" imageanchor=\"1\" style=\"margin-left:1em; margin-right:1em\"><img border=\"0\" height=\"155\" width=\"320\" src=\"http://4.bp.blogspot.com/-o6D7UJbi200/UCg8EKsNOdI/AAAAAAAABCQ/68g828PrdUk/s320/Untitled07.png\" /></a></div><p align=\"center\">Permissions are set</p></ol>"
        ;
    }
}