namespace Recipes.SeedData
{
    public static partial class BlogPostsProgramming
    {
        //Global alignment problem
        public const string content_13032014_b = "<p>The solution to the Manhattan problem described <a href=\"http://justmycode.blogspot.dk/2014/03/manhattan-tourist-problem.html\">here</a> only returned us the maximum score, but did not give instructions on how exactly we should walk through Manhattan to achieve this score. To lay out the path (and to use the solution in bioinformatics to align aminoacid sequences) we need an additional step: keep the history of our walk so that we could \"backtrack\" from the last intersection all the way back to the start. Essentially, it is simple: when we arrive to a new node, we always come from somewhere. This is the node we need to remember.</p>";
        public const string content_13032014_r = "<p>We should also consider that, unlike Manhattan graph, where we only had streets going \"west\" or \"south\", we now have \"diagonal\" streets if we want to adapt the problem to align aminoacid sequences. Consider the image below:</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/13032014_Alignment_graph_matches.png\" alt=\"Alignment graph matches\" /></div><p align=\"center\">Alignment graph matches</p><p>The red diagonal arrows show the places where one sequence matches the other. We can give these edges a higher \"score\" so the path that goes through most of such edges is the highest scored. In this case we have three ways to reach any node <b>s[i,j]</b>: we can come from <b>s[i - 1,j]</b> by moving down, from <b>s[i,j - 1]</b> by moving right, or from <b>s[i - 1, j - 1]</b> by moving diagonally. In the simplest case, we'll calculate anything other than a match as a <b>0</b>, and a match as <b>1</b>. Then the score for any <b>s[i,j]</b> node will be calculated using the following formula:</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/13032014_Global_alignment_formula.png\" alt=\"Global alignment formula\" /></div><p align=\"center\">Global alignment formula</p><p>In more complex scenarios, we may use scoring matrices, where each combination of two aminoacids is given a certain score, depending on how biologically reasonable is this combination.</p><p>Therefore, the following algorithm is used to calculate the score matrix <b>s</b>, and at the same time fill the backtracking matrix <b>backtrack</b>.</p><pre class=\"brush:csharp\">" + @"AlignmentMatrix(v, w)
	for i ← 0 to |v|
		si, 0 ← 0
	for j ← 0 to |w| 
		s0, j ← 0
	for i ← 1 to |v|
		for j ← 1 to |w|
			si, j = max{si-1, j, si,j-1, si-1, j-1 + 1 (if vi = wj)}
			backtracki, j = ↓ if si, j = si-1, j ; → if si, j = si, j-1 ; ↘ if si, j = si-1, j-1 + 1
	return s|v|, |w| , backtrack" + "</pre><p>After both the scoring matrices are filled, we will use the following algorithm to backtrack from the <b>s[i,j]</b> all the way back to the starting node. Along the way we will output two string. In places where there is a match between the strings, a symbol will be placed, and in other places we will fill in a dash. Following is the backtracking algorithm. We are filling two strings, <b>v</b> and <b>w</b>. If we came to the point <b>i,j</b> by a diagonal edge, we have a match, and output the same symbol into both strings. If we came by a vertical or horisontal edge, one of the strings receives a symbol, and the other a \"mismatch\" - a \"<b>-</b>\".</p><pre class=\"brush:csharp\">" + @"OUTPUTALIGNMENT(backtrack, v, w, i, j)
	if i = 0 or j = 0
		return
	if backtracki, j = ↓
		output vi = ""-""
		outpuv wi
		OUTPUTLCS(backtrack, v, i - 1, j)
	else if backtracki, j = →
		output vi
		output wi = ""-""
		OUTPUTLCS(backtrack, v, i, j - 1)
	else
		OUTPUTLCS(backtrack, v, i - 1, j - 1)
		output vi
		output wi" + "</pre><p>This is the C# implementation of the algorithms.</p><pre class=\"brush:csharp\">" + @"public static void GlobalAlignment(string s1, string s2)
{
	int s1l = s1.Length;
	int s2l = s2.Length;

	int[,] matrix = new int[s1l + 1, s2l + 1];
	int[,] backtrack = new int[s1l + 1, s2l + 1];

	for (int i = 0; i &lt;= s1l; i++) for (int j = 0; j &lt;= s2l; j++) matrix[i, j] = 0;
	for (int i = 0; i &lt;= s1l; i++) for (int j = 0; j &lt;= s2l; j++) backtrack[i, j] = 0;

	for (int i = 0; i &lt;= s1l; i++) matrix[i, 0] = 0;
	for (int j = 0; j &lt;= s2l; j++) matrix[0, j] = 0;

	for (int i = 1; i &lt;= s1l; i++)
	{
		for (int j = 1; j &lt;= s2l; j++)
		{
			matrix[i, j] = Math.Max(Math.Max(matrix[i - 1, j], matrix[i, j - 1]), matrix[i - 1, j - 1] + 1);

			if (matrix[i, j] == matrix[i - 1, j]) backtrack[i, j] = -1;
			else if (matrix[i, j] == matrix[i, j - 1]) backtrack[i, j] = -2;
			else if (matrix[i, j] == matrix[i - 1, j - 1] + 1) backtrack[i, j] = 1;
		}
	}

	OUTPUTLCSALIGN(backtrack, s2, s1, s1l, s2l);

	string aligned1 = ReverseString(Result);
	string aligned2 = ReverseString(Result2);
}

public static void OUTPUTLCSALIGN(int[,] backtrack, string v, string w, int i, int j)
{
	if (i == 0 || j == 0)
		return;
	if (backtrack[i, j] == -1)
	{
		Result = Result + ""-"";
		Result2 = Result2 + w[i - 1];
		OUTPUTLCSALIGN(backtrack, v, w, i - 1, j);
	}
	else if (backtrack[i, j] == -2)
	{
		Result = Result + v[j - 1];
		Result2 = Result2 + ""-"";
		OUTPUTLCSALIGN(backtrack, v, w, i, j - 1);
	}
	else
	{
		Result = Result + v[j - 1];
		Result2 = Result2 + w[i - 1];
		OUTPUTLCSALIGN(backtrack, v, w, i - 1, j - 1);
	}
}

public static string ReverseString(string input)
{
	char[] charArray = input.ToCharArray();
	Array.Reverse(charArray);
	return new string(charArray);
}" + "</pre><p>A slightly modified version of the function takes into account a penalty for an insertion / deletion (-5 in this case) and uses a <a href=\"http://www.ncbi.nlm.nih.gov/Class/FieldGuide/BLOSUM62.txt\">BLOSUM62 scoring matrix</a> </p><pre class=\"brush:csharp\">" + @"public static void GlobalAlignment(string s1, string s2)
{
	int indelPenalty = -5;

	int s1l = s1.Length;
	int s2l = s2.Length;

	int[,] matrix = new int[s1l + 1, s2l + 1];
	int[,] backtrack = new int[s1l + 1, s2l + 1];

	for (int i = 0; i &lt;= s1l; i++) for (int j = 0; j &lt;= s2l; j++) matrix[i, j] = 0;
	for (int i = 0; i &lt;= s1l; i++) for (int j = 0; j &lt;= s2l; j++) backtrack[i, j] = 0;

	for (int i = 0; i &lt;= s1l; i++) matrix[i, 0] = indelPenalty * i;
	for (int j = 0; j &lt;= s2l; j++) matrix[0, j] = indelPenalty * j;

	for (int i = 1; i &lt;= s1l; i++)
	{
		for (int j = 1; j &lt;= s2l; j++)
		{
			//deletion
			int delCoef = matrix[i - 1, j] + indelPenalty;
			//insertion
			int insCoef = matrix[i, j - 1] + indelPenalty;
			//match / mismatch
			int mCoef = matrix[i - 1, j - 1] + BlosumCoeff(s1[i - 1], s2[j - 1]);

			matrix[i, j] = Math.Max(Math.Max(delCoef, insCoef), mCoef);

			if (matrix[i, j] == delCoef) backtrack[i, j] = -1; //
			else if (matrix[i, j] == insCoef) backtrack[i, j] = -2; //
			else if (matrix[i, j] == mCoef) backtrack[i, j] = 1;
		}
	}

	OUTPUTLCSALIGN(backtrack, s2, s1, s1l, s2l);

	string aligned1 = ReverseString(Result);
	string aligned2 = ReverseString(Result2);
}" + "</pre><p>Given the following two strings</p><p><b>PLEASANTLY</b><br/><b>MEANLY</b></p><p>The following alignment will be returned</p>" + "<p><b>PLEASANTLY</b><br/><b>-MEA--N-LY</b></p>" + "by <a title= \"Evgeny\" rel=\"author\" href=\"https://plus.google.com/112677661119561622427?rel=author\" alt=\"Google+\" title=\"Google+\">Evgeny</a>";
        public const string content_13032014_d = "Algorithm for solving the global alignment problem between two amino acid sequences";
        public const string content_13032014_k = "Bioinformatics algorithm C# development global alignment";

        //Adding Areas to the Existing ASP.NET MVC Project
        public const string content_26032014_b = "<p>At some point I noticed that I have enough stuff in my MVC project that the list of views becomes too long to be manageable. Naturally, the first idea was to organize it, probably hierarchically. It did not take me long to come across the concept of \"areas\" in MVC. Even though they were introduced back in MVC2, I did not have a chance to use them yet. There are multiple detailed guides on using areas, and I like <a href=\"http://www.codeproject.com/Articles/714356/Areas-in-ASP-NET-MVC\">this one</a>.";
        public const string content_26032014_r = "Overall, adding and configuring areas is fairly easy and intuitive - as usual, Visual Studio and framework do most of the work.</p><p>It was more interesting to see how an existing project can be organised using areas and what surprises may be expected. Additionally, I wanted a tiny bit more complexity compared to the example. Here is the hierarchy from the example above:</p><blockquote>" + @"http://localhost/Men/Clothing/Index<br>
http://localhost/Women/Clothing/Index" + "</blockquote><p>In this case, having two similar areas for <b>Men</b> and <b>Women</b> reached the desired effect. But what if I would like to have a slightly more complex organisation, for example:</p><blockquote>" + @"http://localhost/Men/2014/Clothing/Index<br>
http://localhost/Women/2014/Clothing/Index<br>
http://localhost/Men/2013/Clothing/Index<br>
http://localhost/Women/2013/Clothing/Index" + "</blockquote><p>I tried to solve this problem with routing, but did not find a way to do so easily yet. It starts with routing, though. When the area is created, a default route is added automatically to the YourareanameAreaRegistration.cs, where Yourareaname is what you called your area.</p><pre class=\"brush:csharp\">" + @"context.MapRoute(
	""Yourareaname_default"",
	""Yourareaname/{controller}/{action}/{id}"",
	new { action = ""Index"", id = UrlParameter.Optional }
);" + "</pre><p>Now to catch the url that leads to the \"subarea\" I have to add another route before the default route registration, like this one</p><pre class=\"brush:csharp\">" + @"context.MapRoute(
	""Yourareaname_subareaname"",
	""Yourareaname/Yoursubareaname/{controller}/{action}/{id}"",
	new { action = ""Index"", id = UrlParameter.Optional }
);" + "</pre><p>And if I run the project at this point, I get routed to my controller successfully, but it is unable to locate the view. One straightforward way to fix it is just to return a certain view from the controller.</p><pre class=\"brush:csharp\">" + @"public ActionResult Index()
{
	return View(""~/Areas/Examples/Views/LatestExamples/Amazing/Index.cshtml"");
}" + "</pre><p>This is what I chose for now. I don't like it very much as it looks a lot like hardcoding, but that's the best I could think of for now.</p><p>Next thing I noticed was that my project does not build due to my custom Html helpers not working. This was solved by adding a reference to the namespace containing helpers under <b></b>, to the <b>~/Areas/AreaName/Views/web.config</b> section, as explained <a href=\"http://stackoverflow.com/questions/5638967/custom-html-helpers-in-asp-net-mvc-areas\">here</a>.</p><p>Next I noticed that my css styles do not apply inside the area. The root cause of that was that the css was referenced from the <b>_Layout.chtml</b>, and the <b>_Layout.chtml</b> also did not work inside the area. That was solved by adding a <b>_ViewStart.cshtml</b> under <b>~/Areas/AreaName/Views/</b>, and the full content of this <b>_ViewStart.cshtml</b> is as follows:</p><pre class=\"brush:csharp\">" + @"@{
    Layout = ""~/Views/Shared/_Layout.cshtml"";
}" + "</pre><p>And, of course, if I have more than one area, such <b>_ViewStart.cshtml</b> has to be added to each area.</p><p>That was a step in the right direction, because next time I ran my project, I got this exception inside the <b>_ViewStart.cshtml</b> (which means it was reached! Hooray!)</p><pre class=\"brush:csharp\">" + @"The controller for path '/Yourareaname/Yourcontroller/Index' was not found or does not implement IController." + "</pre><p>That happens when, for example, I'm calling <b>@Html.Action</b> to render the menu that is part of the <b>_Layout.cshtml</b>.</p><p>And here is the reason: When a page, that is located inside an area, wants to access a controller that is located outside of this area (such as a shared layout page or a certain page inside a different area), the area of this controller needs to be added. Since the common controller is not in a specific area but part of the main project, I had to make the modification everywhere where this was the case, from</p><pre class=\"brush:csharp\">" + @"@Html.Action(""MenuResult"", ""LeftMenu"")" + "</pre><p>to </p><pre class=\"brush:csharp\">" + @"@Html.Action(""MenuResult"", ""LeftMenu"", new { area = """" })" + "</pre><p>Fortunately, there were only three such places. And at this point, I could reach my \"stub\" views that I placed under the area and verify, that the layout of the page is as I want it, with all the partial views laid out, and the url to the views is also as I expect it, in the following form:</p><p>http://localhost/MyAreaName/MySubAreaName/MyViewFolder/Index</p><p><b>References</b></p><a href=\"http://www.codeproject.com/Articles/714356/Areas-in-ASP-NET-MVC\">Areas in ASP.NET MVC 4</a><br/><a href=\"http://stackoverflow.com/questions/5638967/custom-html-helpers-in-asp-net-mvc-areas\">Custom Html Helpers in Asp.net MVC Areas</a><br/><a href=\"http://stackoverflow.com/questions/7653538/relative-path-in-stylesheets-within-asp-net-mvc-areas\">relative path in stylesheets within asp.net mvc areas</a><br/><a href=\"http://stackoverflow.com/questions/13277126/force-all-areas-to-use-same-layout\">Force all Areas to use same Layout</a><br/><a href=\"http://stackoverflow.com/questions/7828525/asp-net-mvc-areas-with-shared-layout\">ASP.NET MVC Areas with shared layout</a><br/><a href=\"http://stackoverflow.com/questions/14011026/the-controller-for-path-was-not-found-or-does-not-implement-icontroller\">The controller for path was not found or does not implement IController</a><br/>" + "by <a title= \"Evgeny\" rel=\"author\" href=\"https://plus.google.com/112677661119561622427?rel=author\" alt=\"Google+\" title=\"Google+\">Evgeny</a>";
        public const string content_26032014_d = "Challenges that may occur during adding areas to the existing ASP.NET MVC project.";
        public const string content_26032014_k = "ASP.NET MVC programming software development";

    }
}