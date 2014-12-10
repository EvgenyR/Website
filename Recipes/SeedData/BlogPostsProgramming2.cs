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


        //My First Mobile Application.
        public const string content_05122014_b = "<p>It is time to write my first mobile application. The inspiration comes from a <a href=\"http://www.itmasters.edu.au/free-short-course-cross-platform-mobile-app-development/\">free online course on cross platform mobile development</a>. The course uses <a href=\"http://phonegap.com/\">PhoneGap</a> for development. This post is about configuring the environment on Windows and creating an empty \"Hello World\" application.</p>";
        public const string content_05122014_r = "<p>Step one was to gather and install the required software. The list includes</p><p><ul><li>AndroidSDK</li><li>ApacheAnt</li><li>Eclipse</li><li>JDK</li><li>NodeJS</li></ul></p><p>It is important to download the correct version of your operating system (Windows 64 or 32 bit in my case), and also where the software is copied to or installed to, because it will be necessary to add these locations to environment variables.</p><p><ul><li><a href=\"http://nodejs.org/download/\">NodeJs download link</a></li><li><a href=\"http://developer.android.com/sdk/index.html\">Eclipse download link, which fortunately includes Android SDK</a></li><li><a href=\"http://www.oracle.com/technetwork/java/javase/downloads/index.html\">JDK download link (not JRE!)</a></li><li><a href=\"http://ant.apache.org/bindownload.cgi\">ApacheAnt download link</a></li></ul></p><p>Now, the installation - Node.js and JDK are installed, and Eclipse and Ant are just extracted to your preferred location. I, personally, tried to make the path to this location as simple as I could, i.e. <b>C:\\Development\ant</b>.</p><p>Next, install PhoneGap. After you installed Node.js, you have <b>Node.js command prompt</b> in your Start menu. Run it and execute<br><b>npm install -g phonegap</b></p>" + 
            "<p>Now some path modifications are required. Here are brief instructions to locate where it is done:</p><p><ul><li>Right-click <b></b>My Computer and click <b></b>Properties</li><li>Click <b></b>Advanced System Settings link in the left column</li><li>In the <b></b>System Properties window click the <b></b>Environment Variables button</li><li>Select the variable you want to edit (i.e. PATH)</li><li>Select the edit button.</li></ul></p><p>Here is what was necessary for me:<br>Create <b>ANT_HOME</b> (my value is <b>C:\\Development\ant</b>)</p>" + 
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/05122014_Add_ANT_HOME.png\" alt=\"Add ANT_HOME\" /></div><p align=\"center\">Add ANT_HOME Environment Variable</p><p>Create <b>JAVA_HOME</b> (my value is <b>C:\\Program Files\\Java\\jdk1.8.0_25</b>)<br>Add the following to the PATH variable at the end:<br><b>;C:\\Development\\adt\\sdk\\platform-tools;C:\\Development\\adt\\sdk\\tools;%ANT_HOME%\bin;%JAVA_HOME%;%JAVA_HOME%\bin</b>.</p>" + 
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/05122014_Add_ANT_HOME_to_PATH.png\" alt=\"Add ANT_HOME to PATH\" /></div><p align=\"center\">Add ANT_HOME to PATH</p><p align=\"center\">Add ANT_HOME to PATH</p><p>As you can see, that includes Java, Ant and ADT. And to check that everything is set up properly, you need to run the following commands one by one from the command prompt:</p><p><ul><li>java</li><li>javac</li><li>android</li><li>adb</li><li>ant</li></ul></p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/05122014_Java_Configuration_Check.png\" alt=\"Java Configuration Check\" /></div><p align=\"center\">Check if Java is Configured Properly</p><p>If any of those return the error <b>'<name>' is not recognized as an internal or external command, operable program or batch file</b>, there is probably an issue with the PATH - something is not included, or points to the wrong location.</p><p>Note: when you run \"ant\", you will likely get the following message:</p><p>Buildfile: build.xml does not exist!<br>Build failed</p><p>This is expected and no need to worry about.</p><p>Now the prerequisites are installed. Time to create the actual PhoneGap project. In Node.js command prompt, navigate to the place where you would like your project to be created and execute<br><b></b>phonegap create . \"com.yourname.app\" \"yourappname\"</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/05122014_App_Created.png\" alt=\"App Created\" /></div><p align=\"center\">App is Created</p><p>The project should be created. Just to make it a little different from the empty Hello World application, I went into the www folder and modified the text in the header in index.html. Index.html can be viewed in the browser at this point. </p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/05122014_App_In_Browser.png\" alt=\"App In Browser\" /></div><p align=\"center\">App is Viewed in Browser</p><p>Now the command to build the project.<br><b></b>phonegap install android<br>At this point I got the following error</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/05122014_Error_in_Build.png\" alt=\"Error in Build\" /></div><p align=\"center\">Error in Build</p><p>As you can see, the Android-19 target is missing. The solution is to launch Eclipse, start Android SDK manager, and, to put it simple, install everything that has 19 in it. In my case it looks like this:</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/05122014_Android_SDK_Manager.png\" alt=\"Android SDK Manager\" /></div><p align=\"center\">Android SDK Manager - what to Install?</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/05122014_Android_SDK_Manager_2.png\" alt=\"Android SDK Manager 2\" /></div><p align=\"center\">Android SDK Manager - what to Install?</p><p>This will take some time. When it is done, run the command again.<br><b>phonegap install android</b><br>And in my case I received the following error:<br><b>No emulator images (avds) found ...</b><br>I solved it by running<br><b></b>android avd<br>This started the visual wizard where I could choose the desired parameters for the Android emulator and create it.</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/05122014_Create_AVD.png\" alt=\"Create AVD\" /></div><p align=\"center\">Create new AVD</p><p>And finally, again<br><b>phonegap install android</b><br>This time it started the emulator, on which the application ran.</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/05122014_App_Runs_on_Emulator.png\" alt=\"App Runs on Emulator\" /></div><p align=\"center\">App Running on Emulator</p><p>So this sounds fairly straightforward at the moment, but I had instructions when I started and still I spent probably about 4-6 hours on two PCs over the course of two days to figure out how to get to this point of running an empty application. In my defence, I can say that I had exactly zero prior experience in mobile development.</p><br>by <a title= \"Evgeny\" rel=\"author\" href=\"https://plus.google.com/112677661119561622427?rel=author\" alt=\"Google+\" title=\"Google+\">Evgeny</a>";
        public const string content_05122014_d = "Starting Mobile Application Development with PhoneGap";
        public const string content_05122014_k = "Mobile Android iOS PhoneGap Software Development";

        //My First Mobile Application - With More Functionality
        public const string content_08122014_b = "<p>Next step in my fist mobile app was to actually add something meaningful to the empty application, for example the functionality to take a photo using camera or select a photo from the gallery. My goal was to add as little as possible to the app to be able to identify only the necessary steps, to create, so to speak, a \"minimal viable app\". Also I concentrated on the Android because I down't own an iOS device. But I show some iOS related code below in some cases anyway. There may be more needed to create a proper iOS app.</p>";
        public const string content_08122014_r = "<p>First step - <a href=\"http://jquerymobile.com/download/\">download jQuery mobile</a>. Next, after unpacking, I copied the following files into my project structure, into App/www/js folder.</p><p><ul><li>jquery.1.11.1.min.js</li><li>jquery.mobile-1.4.5.js</li><li>jquery.mobile-1.4.5.min.js</li><li>jquery.mobile-1.4.5.min.map</li></ul></p><p>Next, changes to the application config.xml file.</p><p>Most important change is, probably, the addition of a camera feature.</p><pre class=\"brush:xml\">" + @"&lt;!-- Camera --&gt;
&lt;feature name=""Camera""&gt;
  &lt;param name=""android-package"" value=""org.apache.cordova.camera.CameraLauncher /&gt;
&lt;/feature&gt;
&lt;feature name=""Camera""&gt;
	&lt;param name=""ios-package"" value=""CDVCamera"" /&gt;
&lt;/feature&gt;" + "</pre><p>You may modify the apps details from the default ones</p><pre class=\"brush:xml\">" + @"&lt;name&gt;Camera app&lt;/name&gt;
&lt;description&gt;
	JQuery Mobile and Camera
&lt;/description&gt;
&lt;author email=""evgeny@example.com"" href=""http://ynegve.info""&gt;
	Evgeny
&lt;/author&gt;" + "</pre><p>If you use icons in your app (I guess there should be at least the one), they should be created for all screen resolutions. A good idea, of course, is to create a quality icon in high resolution and then scale it down, rather than vice versa.</p><pre class=\"brush:xml\">" + @"&lt;!-- Icons --&gt;
&lt;icon gap:platform=""android"" gap:qualifier=""ldpi"" src=""www/res/icon/android/icon-36-ldpi.png"" /&gt;
&lt;icon gap:platform=""android"" gap:qualifier=""mdpi"" src=""www/res/icon/android/icon-48-mdpi.png"" /&gt;
&lt;icon gap:platform=""android"" gap:qualifier=""hdpi"" src=""www/res/icon/android/icon-72-hdpi.png"" /&gt;
&lt;icon gap:platform=""android"" gap:qualifier=""xhdpi"" src=""www/res/icon/android/icon-96-xhdpi.png"" /&gt;
&lt;icon gap:platform=""ios"" height=""57"" src=""www/res/icon/ios/icon-57.png"" width=""57"" /&gt;
&lt;icon gap:platform=""ios"" height=""72"" src=""www/res/icon/ios/icon-72.png"" width=""72"" /&gt;
&lt;icon gap:platform=""ios"" height=""114"" src=""www/res/icon/ios/icon-57-2x.png"" width=""114"" /&gt;
&lt;icon gap:platform=""ios"" height=""144"" src=""www/res/icon/ios/icon-72-2x.png"" width=""144"" /&gt;" + "</pre><p>Same deal with the splash screen.</p><pre class=\"brush:xml\">" + @"&lt;gap:splash gap:platform=""android"" gap:qualifier=""port-ldpi"" src=""www/res/screen/android/screen-ldpi-portrait.png"" /&gt;
&lt;gap:splash gap:platform=""android"" gap:qualifier=""port-mdpi"" src=""www/res/screen/android/screen-mdpi-portrait.png"" /&gt;
&lt;gap:splash gap:platform=""android"" gap:qualifier=""port-hdpi"" src=""www/res/screen/android/screen-hdpi-portrait.png"" /&gt;
&lt;gap:splash gap:platform=""android"" gap:qualifier=""port-xhdpi"" src=""www/res/screen/android/screen-xhdpi-portrait.png"" /&gt;
&lt;gap:splash gap:platform=""ios"" height=""480"" src=""www/res/screen/ios/screen-iphone-portrait.png"" width=""320"" /&gt;
&lt;gap:splash gap:platform=""ios"" height=""960"" src=""www/res/screen/ios/screen-iphone-portrait-2x.png"" width=""640"" /&gt;
&lt;gap:splash gap:platform=""ios"" height=""1136"" src=""www/res/screen/ios/screen-iphone-portrait-568h-2x.png"" width=""640"" /&gt;
&lt;gap:splash gap:platform=""ios"" height=""1024"" src=""www/res/screen/ios/screen-ipad-portrait.png"" width=""768"" /&gt;
&lt;gap:splash gap:platform=""ios"" height=""768"" src=""www/res/screen/ios/screen-ipad-landscape.png"" width=""1024"" /&gt;" + "</pre><p>Now the actual functionality. I placed all of it into the index.html, but the javaScript could be placed in the separate file.</p><p>Reference the required javaScript files.</p><pre class=\"brush:jscript\">" + @"&lt;script src=""js/jquery.1.11.1.min.js""&gt;&lt;/script&gt;
&lt;script src=""js/jquery.mobile-1.4.5.min.js""&gt;&lt;/script&gt;
&lt;script src=""cordova.js""&gt;&lt;/script&gt;
&lt;script src=""cordova_plugins.js""&gt;&lt;/script&gt;
&lt;script src=""js/apiCalls.js""&gt;&lt;/script&gt;" + "</pre><p>Add a div with the buttons that will provide functionality.</p><pre class=\"brush:xml\">" + @"&lt;div id=""buttons""&gt;
  &lt;button onclick=""TakePhotoUsingCamera();""&gt;Take Photo Using Camera&lt;/button&gt;
  &lt;button onclick=""TakePhotoFromLibrary();""&gt;Take Photo From Library&lt;/button&gt;
&lt;/div&gt;" + "</pre><p>Add a div to test that the image can be retrieved from the camera. Let's place the image into a div on the main page.</p><pre class=\"brush:xml\">" + @"&lt;div align=""center""&gt;
Name: Evgeny&lt;br&gt;
Job Title: Developer&lt;p&gt;
&lt;img src = ""images/exampleimages/imgNobody.png"" width=""25%"" id = ""myImage""&gt;&lt;p&gt;
&lt;/div&gt;" + "</pre><p>Add some javaScript. Call the onLoad from the body tag, for example. What we want is to make sure that PhoneGap is ready to handle native events. After the device is ready, we will take the photo using the camera. If that is successful, the photo should appear on the main screen of the app. If not, we should see the alert which explains the reason for failure.</p><pre class=\"brush:xml\">" + @"&lt;body onload=""onLoad()""&gt;

...

function onLoad(){
  document.addEventListener(""deviceready"", onDeviceReady, false);
}

function onDeviceReady(){
  console.log(navigator.camera);
  alert('Device is ready');
}

And actual utilisation of the camera

function TakePhotoUsingCamera(){
  TakePhoto(Camera.PictureSourceType.CAMERA);
}

function TakePhotoFromLibrary(){
  TakePhoto(Camera.PictureSourceType.PHOTOLIBRARY);
}

function onSuccess(imageData){
  var image = document.getElementById('myImage');
  image.src = ""data:image/jpeg;base64,"" + imageData;
}

function onFail(message){
  alert('Failed because: ' + message);
}

function TakePhoto(sourceType){
   var camOptions = {
	 quality:50,
	 destinationType: Camera.DestinationType.DATA_URL,
	 sourceType: sourceType,
	 correctOrientation: true
   };
 navigator.camera.getPicture(onSuccess, onFail, camOptions);
}" + "</pre><p>This is probably all of the code that will be needed. Also, the API for the camera has to be added explicitly. Run the following command<br></p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/08122014_Add_Camera_to_Application.png\" alt=\"Add Camera to Application\" /></div><p align=\"center\">Add Camera to Application</p><p>You will notice that the new folder was added under plugins.</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/pr/2014/08122014_Camera_Added.png\" alt=\"Camera Added\" /></div><p align=\"center\">Camera Added</p><p>Finally, as with the \"Hello world\" application, build it and then run on the emulator.</p><p><b>phonegap build android</b><br><b>phonegap install android</b><br></p><p>You won't be able to use the camera on the emulator, so to test it install the apk on the Android device.</p>" + "by <a title= \"Evgeny\" rel=\"author\" href=\"https://plus.google.com/112677661119561622427?rel=author\" alt=\"Google+\" title=\"Google+\">Evgeny</a>";
        public const string content_08122014_d = "Adding functionality to a simple mobile application developed with PhoneGap";
        public const string content_08122014_k = "Mobile software development Android iOS PhoneGap";

    }
}