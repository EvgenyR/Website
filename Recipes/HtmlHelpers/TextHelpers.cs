using System.Web;
using System.Web.Mvc;

namespace HtmlHelpers
{
    public static class TextHelpers
    {
        public static IHtmlString HighLightSyntax(this HtmlHelper helper)
        {
            const string script = "<script type=\"text/javascript\">SyntaxHighlighter.all()</script>";
            return new HtmlString(script);
        }

        public static IHtmlString JQGameTheory(this HtmlHelper helper)
        {
            const string contents1 = "<h2>Conway's Game of Life - JQuery Implementation</h2><p><b>1.</b> Function createGrid creates the 'game field'.</p>";

            const string createGrid = "<pre class=\"brush: jscript\">" +
            @"function createGrid(rows, cols) {
	        var htmlStr = '';
	        htmlStr += '&lt;table&gt;';
	        for (var i = 0; i &lt; rows; i++) {
		        htmlStr += '&lt;tr&gt;';
		        var arr = [];
		        for (var j = 0; j &lt; cols; j++) {
			        htmlStr += '&lt;td id=""r' + i + 'c' + j + '"" r=""' + i + '"" c=""' + j + '"" status=""0""&gt;';
			        htmlStr += '&lt;/td&gt;';
			        arr.push('#' + 'r' + i + 'c' + j);
		        }
		        rowsArr.push(arr);
		        htmlStr += '&lt;/tr&gt;';
	        }
	        htmlStr += '&lt;/table&gt;';

	        var gamediv = $(holder);
	        gamediv.append(htmlStr);

	        $('#gamecontainer').append(htmlStr);
        }" + "</pre>";

            const string contents2 = "<p>For example, for 3 rows and 3 columns the following table will be constructed</p>";

            const string table = "<pre class=\"brush: xml\">" +
            @"&lt;table&gt;
	        &lt;tbody&gt;
		        &lt;tr&gt;
			        &lt;td id=""r0c0"" r=""0"" c=""0"" status=""0""&gt;&lt;/td&gt;
			        &lt;td id=""r0c1"" r=""0"" c=""1"" status=""0""&gt;&lt;/td&gt;
			        &lt;td id=""r0c2"" r=""0"" c=""2"" status=""0""&gt;&lt;/td&gt;
		        &lt;/tr&gt;
		        &lt;tr&gt;
			        &lt;td id=""r1c0"" r=""1"" c=""0"" status=""0""&gt;&lt;/td&gt;
			        &lt;td id=""r1c1"" r=""1"" c=""1"" status=""0""&gt;&lt;/td&gt;
			        &lt;td id=""r1c2"" r=""1"" c=""2"" status=""0""&gt;&lt;/td&gt;
		        &lt;/tr&gt;
		        &lt;tr&gt;
			        &lt;td id=""r2c0"" r=""2"" c=""0"" status=""0""&gt;&lt;/td&gt;
			        &lt;td id=""r2c1"" r=""2"" c=""1"" status=""0""&gt;&lt;/td&gt;
			        &lt;td id=""r2c2"" r=""2"" c=""2"" status=""0""&gt;&lt;/td&gt;
		        &lt;/tr&gt;
	        &lt;/tbody&gt;
        &lt;/table&gt;" + "</pre>";

            const string contents3 = "<p>and the following will be stored in rowsArr for future use.</p>";

            const string rowsArr = "<pre class=\"brush: jscript\">" + 
                @"#r0c0,#r0c1,#r0c2
                #r1c0,#r1c1,#r1c2
                #r2c0,#r2c1,#r2c2" + "</pre>";

            const string contents4 = "<p><b>2.</b> Function that gets the neighbouring cells of a particular cell.</p>";

            const string getNeighboringCels = "<pre class=\"brush: jscript\">" +
            @"function getNeighboringCels(cel) {
	            var arr = [];
	            var rowId = parseInt($(cel).attr('r'));
	            var colId = parseInt($(cel).attr('c'));

	            var nextRow = rowId + 1;
	            var nextCol = colId + 1;
	            var prevRow = rowId - 1;
	            var prevCol = colId - 1;

	            if(rowId == totalRows - 1)
		            nextRow = 0;
	            if(rowId == 0)
		            prevRow = totalRows - 1;
	            if(colId == totalCols - 1)
		            nextCol = 0;
	            if(colId == 0)
		            prevCol = totalCols - 1;

	            arr.push(rowsArr[prevRow][colId]);
	            arr.push(rowsArr[nextRow][colId]);
	            arr.push(rowsArr[rowId][prevCol]);
	            arr.push(rowsArr[rowId][nextCol]);
	            arr.push(rowsArr[prevRow][prevCol]);
	            arr.push(rowsArr[prevRow][nextCol]);
	            arr.push(rowsArr[nextRow][prevCol]);
	            arr.push(rowsArr[nextRow][nextCol]);

	            return arr.unique();
            }" + "</pre>";

            const string contents5 = "<p><b>3.</b> A function that returns the number of 'alive' (selected) neighbours for a cell</p>";

            const string getAliveNeighboursCount = "<pre class=\"brush: jscript\">" +
            @"function getAliveNeighboursCount(cel) {
	            var nArr = getNeighboringCels('#' + cel.attr('id'));
	            var nArrAliveNum = 0;
	            for (var i = 0; i &lt; nArr.length; i++) {
		            if (parseInt($(nArr[i]).attr('status'))) {
			            nArrAliveNum++;
		            }
	            }
	            return nArrAliveNum;
            }" + "</pre>";

            const string contents6 = "<p><b>4.</b> If the cell is clicked, it's state is reverted. Also, assign functions to buttons.</p>";

            const string initGameOfLife = "<pre class=\"brush: jscript\">" +
            @"function initGameOfLife() {
	            $(holder + ' td').click(function () {
		            if (parseInt($(this).attr('status'))) {
			            $(this).removeClass('cel');
			            $(this).attr('status', 0);
		            }
		            else {
			            $(this).addClass('cel');
			            $(this).attr('status', 1);
		            }
	            });
	            $('#start').click(startGameOfLife);
	            $('#stop').click(stopGameOfLife);
	            $('#reset').click(resetGameOfLife);
            }" + "</pre>";

            const string contents7 = "<p><b>5.</b> The game function has a simple logic. It runs an infinite loop, or until all cells are dead. On each step of the game, it checks each cell of the grid and calculates the number of live neighbours. If the cell is alive and has less than 2 or more than 3 live neighbours it dies, if it has exactly 2 or 3 live neighbours it keeps living. If the cell is dead and has exactly three live neighbours, it is resurrected from the dead. (More about <a href=\"http://en.wikipedia.org/wiki/Conway's_Game_of_Life\">Game of Life rules</a>). At the end of each iteration the number of live cells is calculated and, if 0, game is over.</p>";

            const string game = "<pre class=\"brush: jscript\">" +
            @"function game() {
	        console.log('...');
	        //collect cells which will live and the ones which will die
	        cLiveArr = [];
	        cDieArr = [];

	        //run a loop on all the cels and see check their status
	        $(holder + ' td').each(function () {

		        var nArrAliveNum = getAliveNeighboursCount($(this));
		        if (parseInt($(this).attr('status'))) {
			        //this cell dies
			        if (!(nArrAliveNum == 2 || nArrAliveNum == 3)) {
				        cDieArr.push($(this));
			        }
		        }
		        else {
			        //this cell is resurrected
			        if (nArrAliveNum == 3) {
				        cLiveArr.push($(this));
			        }
		        }
	        });

	        //bring to life or kill cells from collection
	        for (var i = 0; i < cLiveArr.length; i++) {
		        selectCel(cLiveArr[i]);
	        }

	        for (var i = 0; i < cDieArr.length; i++) {
		        unselectCel(cDieArr[i]);
	        }

	        //check if all cels are dead.. if so then stop the game
	        if ($('.cel').length < 1) {
		        alert('All cells dead! GAME OVER!');
		        resetGameOfLife();
	        }
        }" + "</pre>";

            const string contents8 = "<p><b>6.</b> There are interesting patterns in the game of life, and some of the simpler ones are included as examples. They are a blinker, a glider, a toad, a small spaceship and a pulsar. There are much more complex patterns of interest, but they are beyond the scope of this mini project. The patterns are defined as an array of cells. </p>";

            const string presets = "<pre class=\"brush: jscript\">" +
            @"    var presets = {
                    blinker: ['#r9c18', '#r9c19', '#r9c20'],
                    glider: ['#r8c19', '#r9c18', '#r10c18', '#r10c19', '#r10c20'],
                    toad: ['#r9c19', '#r9c20', '#r9c21', '#r10c18', '#r10c19', '#r10c20'],
                    spaceship: ['#r8c19', '#r8c20', '#r9c17', '#r9c18', '#r9c20', '#r9c21', '#r10c17', '#r10c18', '#r10c19', '#r10c20', '#r11c18', '#r11c19'],
                };" + "</pre>";

            const string contents9 = "<p>The buttons have a class of 'preset'.</p>";

            const string contents10 = "<p>The function that runs when a button with a 'preset' class is clicked selects an array from presets and selects all cells in this array.</p>";

            const string style = "<pre class=\"brush: xml\">" +
            @"&lt;td style='text-align: right;'&gt;
                &lt;strong&gt;Presets:&lt;/strong&gt; 
                &lt;button class='preset'&gt;Blinker&lt;/button&gt;
                &lt;button class='preset'&gt;Glider&lt;/button&gt;
                &lt;button class='preset'&gt;Toad&lt;/button&gt;
                &lt;button class='preset'&gt;Spaceship&lt;/button&gt;
                &lt;button class='preset'&gt;Pulsar&lt;/button&gt;
                &lt;/td&gt;" + "</pre>";

            const string ready = "<pre class=\"brush: jscript\">" +
            @"$(document).ready(function () {
	            createGrid(cols, rows);
	            initGameOfLife();

	            $('.preset').click(function () {
		            applyPreset($(this).html().toLowerCase());
	            });
            });

            function applyPreset(p) {
	            resetGameOfLife();
	            for (var i = 0; i < presets[p].length; i++) {
		            selectCel($(presets[p][i]));
	            }
            }" + "</pre>";

            return new HtmlString(contents1 + createGrid + contents2 + table + contents3 + rowsArr +
                contents4 + getNeighboringCels + contents5 + getAliveNeighboursCount + contents6 + initGameOfLife +
                contents7 + game + contents8 + presets + contents9 + style + contents10 + ready);
        }

        public static IHtmlString PhotoboxTheory(this HtmlHelper helper)
        {
            const string contents1 = "<h2>Photobox – CSS3 JQuery Image Gallery</h2><p>Photobox is a nice image gallery script which is lightweight, hardware accelerated and generally looks good. Image can be zoomed in and out using mouse wheel and navigated using mouse move. Image 'alt' is shown at the bottom, and the row of thumbnail images is also displayed at the bottom. The autoplay is supported and time is configurable. The script can be downloaded from <a href=\"https://github.com/yairEO/photobox\">Photobox github</a>. It only supports IE 8 and higher, and does not look as good as in other browsers though.</p><p>The usage is very easy: jQuery, script and css have to be referenced as usual, i.e.</p>";
            const string contents2 = "<p>A gallery with all default values (again, check <a href=\"https://github.com/yairEO/photobox\">Photobox github</a> for parameters) is included as follows";
            const string contents3 = "<p>A more involved setup with parameters may look as follows</p>";
            const string contents4 = "<p>The border around the images is totally optional</p>";

            const string scripts = "<pre class=\"brush: xml\">" + 
                                   @"&lt;script src='//ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js' type='text/javascript'&gt;&lt;/script&gt; 
                    &lt;link href='@Url.Content('~/Scripts/photobox/photobox.css')' rel='stylesheet' type='text/css'/&gt;
                    &lt;link href='@Url.Content('~/Scripts/photobox/photobox.ie.css')' rel='stylesheet' type='text/css'/&gt;
                    &lt;script src='@Url.Content('~/Scripts/photobox/photobox.js')' type='text/javascript'&gt;&lt;/script&gt;" +
                                   "</pre>";
            const string gallery = "<pre class=\"brush: xml\">" +
                                   @"&lt;div id='gallery'&gt;
		                &lt;a href='../../../Content/photobox/P1.jpg'&gt;
			                &lt;img src='../../../Content/photobox/P1_small.jpg' alt='photo1 title'/&gt;
		                &lt;/a&gt;

		                ...
		                //More images
                &lt;/div&gt;

                &lt;script type='text/javascript'&gt;
	                $(document).ready(function () {
	                    $('#gallery').photobox('a');
	                });
                &lt;/script&gt;" +
                                   "</pre>";
            const string setup = "<pre class=\"brush: jscript\">" +
                                 @"&lt;script type='text/javascript'&gt;
	            $(document).ready(function () {
	                $('#gallery').photobox('a:first', { thumbs:false, time:0 }, imageLoaded);
		            function imageLoaded(){
			            console.log('image has been loaded...');
		            }
	            });
                &lt;/script&gt;" +
                                 "</pre>";
            const string border = "<pre class=\"brush: css\">" +
                                  @"&lt;style type='text/css'&gt;
                img {
                   padding:1px;
                   border:1px solid #021a40;
                   background-color:#ff0;
                }
                &lt;/style&gt;" +
                                  "</pre>";

            return new HtmlString(contents1 + scripts + contents2 + gallery + contents3 + setup + contents4 + border);
        }

        public static IHtmlString LoggingTheory(this HtmlHelper helper)
        {
            const string content = @"<p><b>High-level requirements:</b></p><ul><li>Create logging engine that can log exceptions and other messages and store them in the database</li><li>Display a filterable grid of all messages</li></ul><p><b>Logging engine:</b></p><ul><li>Should allow logging of exceptions, including handled and unhandled</li><li>Should allow logging of custom messages</li></ul>
<p><b>Filterable grid:</b></p><ul><li>Should allow paged display of all exceptions and log messages in the database</li><li>Should allow the option to filter messages based on the date logged and severity</li></ul>

<p>These are simple classes that will allow handling of messages and exception.</p>" + "<pre class=\"brush:csharp\">" + @"public class LogEntry
{
	public int Id { get; set; }
	public DateTime TimeStamp { get; set; }
	public string Path { get; set; }
	public string RawUrl { get; set; }
	public string Source { get; set; }
	public string Message { get; set; }
	public string StackTrace { get; set; }
	public string TargetSite { get; set; }

	public int TypeId { get; set; }
	public virtual LogType LogType { get; set; }
}

public class LogType
{
	public int LogTypeId { get; set; }
	public string Type { get; set; }
}

public enum LogTypeNames
{
	All = 0,
	Info = 1,
	Warn = 2,
	Debug = 3,
	Error = 4,
	Fatal = 5,
	Exception = 6
}" + "</pre><p>These will be reflected in two database table - the main table for saving all log messages, and a helper table to keep names of message severity levels.</p><pre class=\"brush:csharp\">" + @"public DbSet&lt;LogType&gt; LogTypes { get; set; }
public DbSet&lt;LogEntry&gt; LogEntries { get; set; }" + "</pre><p>Next, it is time to mention logging of handled and unhandled exceptions.</p><p><u>Develop mechanism for logging exceptions</u></p><p><u>Log unhandled exceptions</u></p><p>Unhandled exceptions are, well, exceptions that are not handled in the source code. First, the site <b>web.config</b> must be modified to add a line in the <system.web> section</p><p>Here's how it works: a method is called in <b>Global.asax</b> file:</p><pre class=\"brush:csharp\">" + @"public static void RegisterGlobalFilters(GlobalFilterCollection filters)
{
    filters.Add(new HandleErrorAttribute());
}" + "</pre><p>It registers the <b>HandleErrorAttribute</b> as global action filter. The <b>HandleErrorAttribute</b> checks the customErrors mode, and if it is off, shows the \"yellow screen of death\". If it is on, the <b>Error</b> view is rendered and a <b>Model</b> is passed to it containing exceptions stack trace. Therefore, an <b>Error.cshtml</b> should be added under Views/Shared, and in its simplest form may look as follows</p><pre class=\"brush:xml\">" + @"@using Recipes.Logging
@using Recipes.Models
@{
    Layout = null;
    ViewBag.Title = ""Error"";
    Logger.WriteEntry(Model.Exception);
}

&lt;!DOCTYPE html&gt;
&lt;html&gt;
&lt;head&gt;
    &lt;title&gt;Error&lt;/title&gt;
&lt;/head&gt;
&lt;body&gt;
    &lt;h2&gt;
        Sorry, an error occurred while processing your request. The details of the error were logged.
    &lt;/h2&gt;
&lt;/body&gt;
&lt;/html&gt;" + "</pre><p>For simplicity, all log messages - exceptions, handled and unhandled, and all other custom messages - will be saved in a single database table.</p><p><u>Log handled exceptions</u></p><p>The handled exceptions are caught by code and handled directly.</p><pre class=\"brush:csharp\">" + @"public static class Logger
{
	public static void WriteEntry(Exception ex)
	{
		LogEntry entry = BuildExceptionLogEntry(ex);
		SaveLogEntry(entry);        
	}

	public static void WriteEntry(string mesage, string source, int logType)
	{
		LogEntry entry = BuildLogEntry(mesage, source, logType);
		SaveLogEntry(entry);
	}

	private static void SaveLogEntry(LogEntry entry)
	{
		using (RecipesEntities context = new RecipesEntities())
		{
			context.LogEntries.Add(entry);
			context.SaveChanges();
		}
	}

	private static LogEntry BuildLogEntry(string message, string source, int logType)
	{
		LogEntry entry = BuildLogEntryTemplate();

		entry.Message = message;
		entry.Source = source;
		entry.LogType = GetLogEntryType((LogTypeNames)logType);
		entry.TypeId = logType;

		return entry;
	}

	private static LogEntry BuildExceptionLogEntry(Exception x)
	{
		Exception logException = GetInnerExceptionIfExists(x);
		LogEntry entry = BuildLogEntryTemplate();

		entry.Message = logException.Message;
		entry.Source = logException.Source ?? string.Empty;
		entry.StackTrace = logException.StackTrace ?? string.Empty;
		entry.TargetSite = logException.TargetSite == null ? string.Empty : logException.TargetSite.ToString();
		entry.LogType = GetLogEntryType(LogTypeNames.Exception);
		entry.TypeId = (int) LogTypeNames.Exception;

		return entry;
	}

	private static LogEntry BuildLogEntryTemplate()
	{
		return new LogEntry
				   {
					   Path = HttpContext.Current.Request.Path,
					   RawUrl = HttpContext.Current.Request.RawUrl,
					   TimeStamp = DateTime.Now,
				   };
	}

	public static string BuildExceptionMessage(Exception x)
	{
		Exception logException = GetInnerExceptionIfExists(x);

		string strErrorMsg = Environment.NewLine + ""Error in Path :"" + HttpContext.Current.Request.Path;
		// Get the QueryString along with the Virtual Path
		strErrorMsg += Environment.NewLine + ""Raw Url :"" + HttpContext.Current.Request.RawUrl;
		// Get the error message
		strErrorMsg += Environment.NewLine + ""Message :"" + logException.Message;
		// Source of the message
		strErrorMsg += Environment.NewLine + ""Source :"" + logException.Source;
		// Stack Trace of the error
		strErrorMsg += Environment.NewLine + ""Stack Trace :"" + logException.StackTrace;
		// Method where the error occurred
		strErrorMsg += Environment.NewLine + ""TargetSite :"" + logException.TargetSite;
		return strErrorMsg;
	}

	private static LogType GetLogEntryType(LogTypeNames name)
	{
		return new LogType{LogTypeId = (int)name, Type = name.ToString()};
	}

	private static Exception GetInnerExceptionIfExists(Exception x)
	{
		if (x.InnerException != null)
			return x.InnerException;
		return x;
	}
}" + "</pre><p>With this basic structure in place, I can start adding user interface for displaying the log.</p><p><b><u>Index view.</u></b></p><p>The view will have several parts, wrapped in a form.</p><pre class=\"brush:csharp\">" + @"@using (Html.BeginForm(""Index"", ""Logging"", new { CurrentPageIndex = 1 }, FormMethod.Get, new { id = ""myform"" }))
{

}" + "</pre><p>First is the div that shows the number of records found and gives an option to choose how many records per page will be displayed.</p><pre class=\"brush:xml\">" + @"&lt;div class=""grid-header""&gt;
    &lt;div class=""grid-results""&gt;
        &lt;div class=""inner""&gt;
            &lt;span style=""float: left""&gt;
                @string.Format(""{0} records found. Page {1} of {2}"", Model.LogEvents.TotalItemCount, Model.LogEvents.PageNumber, Model.LogEvents.PageCount)
            &lt;/span&gt;

            &lt;span style=""float: right""&gt;
                Show @Html.DropDownListFor(model =&gt; model.PageSize, new SelectList(FormsHelper.PagingPageSizes, ""Value"", ""Text"", Model.PageSize), new { onchange = ""document.getElementById('myform').submit()"" }) results per page
            &lt;/span&gt;
            
            &lt;div style=""clear: both""&gt;&lt;/div&gt;
        &lt;/div&gt; &lt;!-- inner --&gt;
    &lt;/div&gt;  &lt;!-- grid-results --&gt;
 &lt;/div&gt;  &lt;!-- grid-header --&gt;" + "</pre><p>The second allows to filter records by date logged and severity</p><pre class=\"brush:xml\">" + @" &lt;div class=""grid-filter""&gt;        
    &lt;div class=""inner""&gt;
        Level : @Html.DropDownList(""LogLevel"", new SelectList(FormsHelper.LogLevels, ""Value"", ""Text""))

        For : @Html.DropDownList(""Period"", new SelectList(FormsHelper.CommonTimePeriods, ""Value"", ""Text""))
        
        &lt;input id=""btnGo"" name=""btnGo"" type=""submit"" value=""Apply Filter"" /&gt;                      
    &lt;/div&gt;
 &lt;/div&gt;  " + "</pre><p> Next is the \"pager\" div, which allows navigation if multiple pages are reqiured</p><pre class=\"brush:xml\">" + @"  &lt;div class=""paging""&gt;
    &lt;div class=""pager""&gt;
        @Html.Pager(ViewData.Model.LogEvents.PageSize, ViewData.Model.LogEvents.PageNumber, ViewData.Model.LogEvents.TotalItemCount, new { LogType = ViewData[""LogType""], Period = ViewData[""Period""], PageSize = ViewData[""PageSize""] })
    &lt;/div&gt;
 &lt;/div&gt;" + "</pre><p> Finally, the main part is the actual grid which displays the messages.</p><pre class=\"brush:xml\">" + @"@if (Model.LogEvents.Count() == 0)
 {
 &lt;p&gt;No results found&lt;/p&gt;
 }
 else
 {
 &lt;div class=""grid-container""&gt;
 &lt;table class=""grid""&gt;
    &lt;tr&gt;
        &lt;th&gt;&lt;/th&gt;
        &lt;th&gt;#&lt;/th&gt;
        &lt;th&gt;Source&lt;/th&gt;
        &lt;th&gt;Date&lt;/th&gt;
        &lt;th style='white-space: nowrap;'&gt;Time ago&lt;/th&gt;
        &lt;th&gt;Message&lt;/th&gt;
        &lt;th&gt;Type&lt;/th&gt;
    &lt;/tr&gt;

 @{int i = 0;}
     @foreach (var item in Model.LogEvents)
     {
     &lt;tr class=""@(i++ % 2 == 1 ? ""alt"" : """")""&gt;
     &lt;td&gt;
        @Html.ActionLink(""Details"", ""Details"", new { id = item.Id.ToString(), loggerProviderName = ""Go To Details"" /*item.LoggerProviderName*/ })
     &lt;/td&gt;
     &lt;td&gt;
        @i.ToString()
     &lt;/td&gt;
     &lt;td&gt;
        @item.Source
     &lt;/td&gt;
     &lt;td style='white-space: nowrap;'&gt;
        @String.Format(""{0:g}"", item.TimeStamp.ToLocalTime())
     &lt;/td&gt;
     &lt;td style='white-space: nowrap;'&gt;
        @item.TimeStamp.ToLocalTime().TimeAgoString()
     &lt;/td&gt;
     &lt;td&gt;
        &lt;pre&gt;@item.Message.WordWrap(80)&lt;/pre&gt;
     &lt;/td&gt;
     &lt;td&gt;
        @item.LogType.Type
     &lt;/td&gt;
     &lt;/tr&gt;
     }

 &lt;/table&gt;
 &lt;/div&gt; &lt;!-- grid-container --&gt;
}" + "</pre><p>A few points of interest:</p><p><b>Paging</b> control uses the <b>PagedList</b> class.</p><p>Interface:</p><pre class=\"brush:csharp\">" + @"public interface IPagedList&lt;T&gt; : IList&lt;T&gt;
{
	int PageCount { get; }
	int TotalItemCount { get; }
	int PageIndex { get; }
	int PageNumber { get; }
	int PageSize { get; }

	bool HasPreviousPage { get; }
	bool HasNextPage { get; }
	bool IsFirstPage { get; }
	bool IsLastPage { get; }
}" + "</pre><p>PagedList class:</p><pre class=\"brush:csharp\">" + @"public class PagedList&lt;T&gt; : List&lt;T&gt;, IPagedList&lt;T&gt;
{
	public PagedList(IEnumerable&lt;T&gt; source, int index, int pageSize)
		: this(source, index, pageSize, null)
	{
	}

	public PagedList(IEnumerable&lt;T&gt; source, int index, int pageSize, int? totalCount)
	{
		Initialize(source.AsQueryable(), index, pageSize, totalCount);
	}

	public PagedList(IQueryable&lt;T&gt; source, int index, int pageSize)
		: this(source, index, pageSize, null)
	{
	}

	public PagedList(IQueryable&lt;T&gt; source, int index, int pageSize, int? totalCount)
	{
		Initialize(source, index, pageSize, totalCount);
	}

	#region IPagedList Members

	public int PageCount { get; private set; }
	public int TotalItemCount { get; private set; }
	public int PageIndex { get; private set; }
	public int PageNumber { get { return PageIndex + 1; } }
	public int PageSize { get; private set; }
	public bool HasPreviousPage { get; private set; }
	public bool HasNextPage { get; private set; }
	public bool IsFirstPage { get; private set; }
	public bool IsLastPage { get; private set; }

	#endregion

	protected void Initialize(IQueryable&lt;T&gt; source, int index, int pageSize, int? totalCount)
	{
		//### argument checking
		if (index &lt; 0)
		{
			throw new ArgumentOutOfRangeException(""PageIndex cannot be below 0."");
		}
		if (pageSize &lt; 1)
		{
			throw new ArgumentOutOfRangeException(""PageSize cannot be less than 1."");
		}

		//### set source to blank list if source is null to prevent exceptions
		if (source == null)
		{
			source = new List&lt;T&gt;().AsQueryable();
		}

		//### set properties
		if (!totalCount.HasValue)
		{
			TotalItemCount = source.Count();
		}
		PageSize = pageSize;
		PageIndex = index;
		if (TotalItemCount &gt; 0)
		{
			PageCount = (int)Math.Ceiling(TotalItemCount / (double)PageSize);
		}
		else
		{
			PageCount = 0;
		}
		HasPreviousPage = (PageIndex &gt; 0);
		HasNextPage = (PageIndex &lt; (PageCount - 1));
		IsFirstPage = (PageIndex &lt;= 0);
		IsLastPage = (PageIndex &gt;= (PageCount - 1));

		//### add items to internal list
		if (TotalItemCount &gt; 0)
		{
			AddRange(source.Skip((index) * pageSize).Take(pageSize).ToList());
		}
	}
}" + "</pre><p>Pager class renders the HTML for the pager control:</p><pre class=\"brush:csharp\">" + @"public class Pager
{
	private readonly ViewContext viewContext;
	private readonly int pageSize;
	private readonly int currentPage;
	private readonly int totalItemCount;
	private readonly RouteValueDictionary linkWithoutPageValuesDictionary;

	public Pager(ViewContext viewContext, int pageSize, int currentPage, int totalItemCount, RouteValueDictionary valuesDictionary)
	{
		this.viewContext = viewContext;
		this.pageSize = pageSize;
		this.currentPage = currentPage;
		this.totalItemCount = totalItemCount;
		linkWithoutPageValuesDictionary = valuesDictionary;
	}

	/// &lt;summary&gt;
	/// Rendes HTML to display a ""pager"" control (used at the top and bottom of the list of logged messages)
	/// &lt;/summary&gt;
	/// &lt;returns&gt;String of HTML&lt;/returns&gt;
	public string RenderHtml()
	{
		int pageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
		const int nrOfPagesToDisplay = 10;

		var sb = new StringBuilder();

		// Previous
		if (currentPage &gt; 1)
		{
			sb.Append(GeneratePageLink(""&lt;"", this.currentPage - 1));
		}
		else
		{
			sb.Append(""&lt;span class=\""disabled\""&gt;&lt;&lt;/span&gt;"");
		}

		int start = 1;
		int end = pageCount;

		if (pageCount &gt; nrOfPagesToDisplay)
		{
			int middle = (int)Math.Ceiling(nrOfPagesToDisplay / 2d) - 1;
			int below = (currentPage - middle);
			int above = (currentPage + middle);

			if (below &lt; 4)
			{
				above = nrOfPagesToDisplay;
				below = 1;
			}
			else if (above &gt; (pageCount - 4))
			{
				above = pageCount;
				below = (pageCount - nrOfPagesToDisplay);
			}

			start = below;
			end = above;
		}

		if (start &gt; 3)
		{
			sb.Append(GeneratePageLink(""1"", 1));
			sb.Append(GeneratePageLink(""2"", 2));
			sb.Append(""..."");
		}
		for (int i = start; i &lt;= end; i++)
		{
			if (i == currentPage)
			{
				sb.AppendFormat(""&lt;span class=\""current\""&gt;{0}&lt;/span&gt;"", i);
			}
			else
			{
				sb.Append(GeneratePageLink(i.ToString(), i));
			}
		}
		if (end &lt; (pageCount - 3))
		{
			sb.Append(""..."");
			sb.Append(GeneratePageLink((pageCount - 1).ToString(), pageCount - 1));
			sb.Append(GeneratePageLink(pageCount.ToString(), pageCount));
		}

		// Next
		if (currentPage &lt; pageCount)
		{
			sb.Append(GeneratePageLink(""&gt;"", (currentPage + 1)));
		}
		else
		{
			sb.Append(""&lt;span class=\""disabled\""&gt;&gt;&lt;/span&gt;"");
		}
		return sb.ToString();
	}

	/// &lt;summary&gt;
	/// Generates a link to a page
	/// &lt;/summary&gt;
	/// &lt;param name=""linkText""&gt;Text displayed on the page&lt;/param&gt;
	/// &lt;param name=""pageNumber""&gt;Number of the page the link leads to&lt;/param&gt;
	/// &lt;returns&gt;&lt;/returns&gt;
	private string GeneratePageLink(string linkText, int pageNumber)
	{
		var pageLinkValueDictionary = new RouteValueDictionary(linkWithoutPageValuesDictionary) {{""page"", pageNumber}};
		var virtualPathData = RouteTable.Routes.GetVirtualPath(this.viewContext.RequestContext, pageLinkValueDictionary);

		if (virtualPathData != null)
		{
			const string linkFormat = ""&lt;a href=\""{0}\""&gt;{1}&lt;/a&gt;"";
			return String.Format(linkFormat, virtualPathData.VirtualPath, linkText);
		}
		return null;
	}
}" + "</pre>";
            return new HtmlString(content);
        }

        public static IHtmlString YahooTheory(this HtmlHelper helper)
        {
            const string contents1 = "<p><strong>WebGrid</strong> is an HTML helper provided as part of the MVC framework to simplify rendering tabular data.</p><p>When I learned how to use <strong>WebGrid</strong> I found a very good article with code samples here:</p><p><a href=\"http://msdn.microsoft.com/en-us/magazine/hh288075.aspx\">Get the Most out of WebGrid in ASP.NET MVC</a></p><p>My application of these ideas I described on my blog:</p><p><a href=\"http://justmycode.blogspot.com.au/2012/11/starting-with-webgrid.html\">Starting with WebGrid</a></p><p><a href=\"http://justmycode.blogspot.com.au/2012/11/webgrid-stronly-typed-with-server-paging.html\">WebGrid: Stronly Typed with Server Paging</a></p><p><a href=\"http://justmycode.blogspot.com.au/2012/11/webgrid-ajax-updates-server-sorting.html\">WebGrid: AJAX Updates, Server Sorting</a></p><p>Here is most of the <strong></strong>View that displays my <strong>WebGrid</strong>:</p>";
            const string contents2 = "<p>Key points:</p><p>The <strong>WebGrid</strong> is displayed in the partial view <strong>_WebGrid</strong>. The <strong>RetrieveData</strong> function triggers the controller action <strong>AddDataToDB</strong> (which calls the Yahoo website and adds results to the database). The data is then used by the <strong>ShowDialog</strong> function that displays exactly the subset of data that was retrieved. The css is used to style the <strong>WebGrid</strong>.</p><p>The <strong>WebGrid</strong> partial view:</p>";
            const string contents3 = "<p>Here the <strong>WebGrid</strong> is defined, including all columns and the format for the data to be displayed. <strong>ajaxUpdateContainerId</strong> is used to enable AJAX behaviour. The css is utilised for styling. The <strong>WebGrid</strong> is bound to the <strong>Model</strong>, which is defined as follows</p>";
            const string contents4 = "<p>Finally, this is most of the controller code:</p>";
            const string contents5 = "<p>Main points: The link on the <strong>WebGrid</strong> column has the following format: <u>http://localhost/Yahoo/Index?sort=DateTime&sortdir=ASC</u>. Therefore, the controller function can automatically receive those parameters. The parameters will be then passed over to the <strong>GetData</strong> function that retrieves data. A couple of helper functions are utilized by <strong>GetData</strong>: <strong>CreateOrderingFunc</strong> and <strong>_dataOrderings</strong>. The retrieved data is saved to the database and also sent back to the <strong>View</strong> where, as shown earlier, it is used by the <strong>ShowDialog</strong> function to display the set of data to the user.</p>";

            const string viewCode = "<pre class=\"brush: xml\">@model Recipes.ViewModels.YahooViewModel" +
                                    @"&lt;link href='http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css' rel='stylesheet' type='text/css'/&gt;
&lt;script src='http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js'&gt;&lt;/script&gt;
&lt;script src='http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js'&gt;&lt;/script&gt;

&lt;script type='text/javascript'&gt;

	$.ajaxSetup({ cache: false });

	function ShowDialog(msg) {
		$('&lt;div/&gt;').dialog({ title: 'Retrieved the following data', width: 450, height: 250, close: function(){ location.reload(); }}).html(msg);
	}

	function RetrieveData() {
		$.post('@Url.Action('AddDataToDB','yahoo')',
		function (d) {
			ShowDialog(d.o);
		});
	}

	function GetSomeData() {
		RetrieveData();
	}

&lt;/script&gt;

&lt;style type='text/css'&gt;
    .webgrid
    {
        width: 100%;
        border: 0px;
        border-collapse: collapse;
        font-size:13px;
        color:#000000;

		...
    }
    .webgrid-header
    {
		...
    }
    .webgrid-footer
    {
		...
    }
    .webgrid-alternating-row
    {
		...
    }
    .webgrid-row-style
    {
		...
    }
    .webgrid-selected-row
    {
        font-weight: bold;
    }    
    .alt {background-color: #E8E8E8; color: #000;}
    .time {width: 200px; font-weight:bold;}
    .company{width: 140px;}
    .volume{width: 100px;}
    .ask{width: 70px;}
&lt;/style&gt;

&lt;div id='page' style='min-width:500px'&gt;
    @Html.Partial('_YahooNav')
    &lt;div id='wbgrid' style='float:left; min-width:500px;'&gt;
        @Html.Partial('_WebGrid', Model)
    &lt;/div&gt;
    @Html.Partial('Doggy')
    &lt;div id='stopstart' style='padding:10px; height: 25px; clear: both;'&gt;
    &lt;input id='getsomedata' type='button' style='margin:3px' onclick='GetSomeData();' value='GetSomeData' /&gt;
        &lt;input id='stop' type='button' style='margin:3px' onclick='Stop();' value='Stop' /&gt;
        &lt;input id='start' type='button' style='margin:3px' onclick='Start();' value='Start' /&gt;
        &lt;input id='dlg' type='button' style='margin:3px' onclick='ShowDialog();' value='Dialog' /&gt;
&lt;/div&gt;</pre>";

            const string partialViewCode = "<pre class=\"brush: xml\">@model Recipes.ViewModels.YahooViewModel" + 
                                           @"@{ var grid = new WebGrid&lt;Recipes.SeedData.YahooData&gt;(null, rowsPerPage: 5, defaultSort: 'YahooSymbolName', ajaxUpdateContainerId: 'wbgrid');
grid.Bind(Model.Datas, rowCount: Model.TotalRows, autoSortAndPage: false);
}

@grid.GetHtml(columns: grid.Columns(
grid.Column('DataName', header: 'Company', style: 'company', format: @&lt;text&gt;@Html.ActionLink((string)item.DataName, 'Details', 'Company', new { id = item.SymbolId }, null)&lt;/text&gt;),
grid.Column('DateTime', header: 'Time', style: 'time', format: @&lt;text&gt;@item.DateTime.ToString('dd/MM/yyyy hh:mm')&lt;/text&gt;),
grid.Column('LTP', style: 'ask'), 
grid.Column('Volume', style: 'volume'), 
grid.Column('Ask', style: 'ask'),
grid.Column('Bid', style: 'ask'),
grid.Column('High', style: 'ask'),
grid.Column('Low', style: 'ask')),
tableStyle: 'webgrid',
headerStyle: 'webgrid-header',
footerStyle: 'webgrid-footer',
selectedRowStyle: 'webgrid-selected-row',
rowStyle: 'webgrid-row-style' 
alternatingRowStyle: 'alt')</pre>";

            const string modelCode = "<pre class=\"brush: csharp\">" +
                                     @"public class YahooViewModel
{
	public List&lt;string&gt; strings { get; set; }

	public List&lt;YahooData&gt; Datas { get; set; }
	public List&lt;YahooSymbol&gt; Symbols { get; set; }
	public YahooSymbol Symbol { get; set; }
	public int YahooSymbolID { get; set; }
	public int TotalRows { get; set; }

	public YahooViewModel(int symbolid, YahooSymbol symbol, List&lt;YahooSymbol&gt; symbols, List&lt;YahooData&gt; datas, int totalRows)
	{
		Symbol = symbol;
		YahooSymbolID = symbolid;
		Symbols = symbols;
		Datas = datas;
		TotalRows = totalRows;
	}
}</pre>";

            const string controllerCode = "<pre class=\"brush: csharp\">public class YahooController : BaseController" +
                
                                          @"{
	RecipesEntities db = new RecipesEntities();
	
	public ActionResult Index(int page = 1, string sort = 'YahooSymbolName', string sortDir = 'Ascending')
	{
		int totalRecords;
		List&lt;YahooData&gt; datas = GetData(out totalRecords, pageSize: 5, pageIndex: page - 1, sort: sort, sortOrder: GetSortDirection(sortDir));
		return View('Index', GetFullViewModel(datas, totalRecords));
	}

	private YahooViewModel GetFullViewModel(List&lt;YahooData&gt; datas, int totalRecords)
	{
		List&lt;YahooSymbol&gt; symbols = db.YahooSymbols.ToList();
		YahooSymbol symbol = symbols.First();
		int id = symbol.YahooSymbolID;
		return new YahooViewModel(id, symbol, symbols, datas, totalRecords);
	}

	// helpers that take an IQueryable&lt;Product&gt; and a bool to indicate ascending/descending
	// and apply that ordering to the IQueryable and return the result
	private readonly IDictionary&lt;string, Func&lt;IQueryable&lt;YahooData&gt;, bool, IOrderedQueryable&lt;YahooData&gt;&gt;&gt;
		_dataOrderings = new Dictionary&lt;string, Func&lt;IQueryable&lt;YahooData&gt;, bool, IOrderedQueryable&lt;YahooData&gt;&gt;&gt;
								{
									{'YahooSymbolName', CreateOrderingFunc&lt;YahooData, string&gt;(p=&gt;p.DataName)},
									{'DataName', CreateOrderingFunc&lt;YahooData, string&gt;(p=&gt;p.DataName)},
									{'Ask', CreateOrderingFunc&lt;YahooData, decimal?&gt;(p=&gt;p.Ask)},
									{'Time', CreateOrderingFunc&lt;YahooData, DateTime&gt;(p=&gt;p.DateTime)}
								};

	/// returns a Func that takes an IQueryable and a bool, and sorts the IQueryable (ascending or descending based on the bool).
	/// The sort is performed on the property identified by the key selector.
	private static Func&lt;IQueryable&lt;T&gt;, bool, IOrderedQueryable&lt;T&gt;&gt; CreateOrderingFunc&lt;T, TKey&gt;(Expression&lt;Func&lt;T, TKey&gt;&gt; keySelector)
	{
		return
			(source, ascending) =&gt;
			ascending
				? source.OrderBy(keySelector)
				: source.OrderByDescending(keySelector);
	}

	public List&lt;YahooData&gt; GetData(out int totalRecords, int pageSize, int pageIndex, string sort = 'YahooSymbolName', SortDirection sortOrder = SortDirection.Ascending )
	{
		IQueryable&lt;YahooData&gt; data = db.YahooData;
		totalRecords = data.Count();

		Func&lt;IQueryable&lt;YahooData&gt;, bool, IOrderedQueryable&lt;YahooData&gt;&gt; applyOrdering = _dataOrderings[sort];
		data = applyOrdering(data, sortOrder == SortDirection.Ascending);

		List&lt;YahooData&gt; result = data.ToList();
		if(pageSize &gt; 0 && pageIndex &gt;=0)
		{
			result = result.Skip(pageIndex*pageSize).Take(pageSize).ToList();
		}
		return result;
	}

	public List&lt;YahooData&gt; GetSingleSet()
	{
		List&lt;YahooData&gt; datas = new List&lt;YahooData&gt;();
		HttpWebRequest req = (HttpWebRequest)WebRequest.Create('http://download.finance.yahoo.com/d/quotes.csv?s=GOOG+AAPL+MSFT+YHOO&f=snd1l1t1vb3b2hg');
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
		List&lt;YahooData&gt; datas = GetSingleSet();
		datas.ForEach(d =&gt; db.YahooData.Add(d));
		db.SaveChanges();

		string s = '&lt;table&gt;&lt;thead&gt;&lt;tr class=\'webgrid-header\'&gt;&lt;th&gt;Company&lt;/th&gt;&lt;th&gt;Time&lt;/th&gt;&lt;th&gt;LTP&lt;/th&gt;&lt;th&gt;Volume&lt;/th&gt;&lt;th&gt;Ask&lt;/th&gt;&lt;th&gt;Bid&lt;/th&gt;&lt;th&gt;High&lt;/th&gt;&lt;th&gt;Low&lt;/th&gt;&lt;/tr&gt;&lt;/thead&gt;&lt;tbody&gt;';

		foreach (var yahooData in datas)
		{
			s = s + '&lt;tr class=\'webgrid-row-style\'&gt;' + 
				'&lt;td class=\'company\'&gt;' + yahooData.DataName + '&lt;/td&gt;' +
				'&lt;td class=\'time\'&gt;' + yahooData.DateTime.ToString('dd/MM/yyyy hh:mm') + '&lt;/td&gt;' +
				'&lt;td class=\'ask\'&gt;' + yahooData.LTP + '&lt;/td&gt;' +
				'&lt;td class=\'volume\'&gt;' + yahooData.Volume + '&lt;/td&gt;' +
				'&lt;td class=\'ask\'&gt;' + yahooData.Ask + '&lt;/td&gt;' +
				'&lt;td class=\'ask\'&gt;' + yahooData.Bid + '&lt;/td&gt;' +
				'&lt;td class=\'ask\'&gt;' + yahooData.High + '&lt;/td&gt;' +
				'&lt;td class=\'ask\'&gt;' + yahooData.Low + '&lt;/td&gt;' +
				'&lt;/tr&gt;';
		}
		s = s + '&lt;/tbody&gt;&lt;/table&gt;';

		return Json(new { o = s });
	}

	private List&lt;YahooData&gt; ParseData(string[] lines)
	{
		List&lt;YahooData&gt; datas = new List&lt;YahooData&gt;();
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
		catch (Exception ex)
		{
			//log.Fatal('Exception in InsertData: ', ex);
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
							SymbolId = GetSymbol(splitLine[0].Replace('\'', '')),
							DataName = splitLine[1].Replace('\'', ''),
							Date = DateTime.ParseExact(splitLine[2].Replace('\'', ''), 'MM/d/yyyy', CultureInfo.InvariantCulture),
							LTP = decimal.Parse(splitLine[3]),
							Time = DateTime.Parse(splitLine[4].Replace('\'', '')),
							Volume = decimal.Parse(splitLine[5]),
							Ask = decimal.Parse(splitLine[6]),
							Bid = decimal.Parse(splitLine[7]),
							High = decimal.Parse(splitLine[8]),
							Low = decimal.Parse(splitLine[9]),
							DateTime = DateTime.ParseExact(splitLine[2].Replace('\'', '') + ' ' + splitLine[4].Replace('\'', ''), 'MM/d/yyyy h:mmtt', CultureInfo.InvariantCulture)
			};
		}
		catch (Exception ex)
		{
			//log.Fatal('Exception in GetDatum: ', ex);
		}
		return datum;
	}

	private int GetSymbol(string name)
	{
		YahooSymbol symbol = db.YahooSymbols.Where(s =&gt; s.YahooSymbolName == name).FirstOrDefault();
		return symbol.YahooSymbolID;
	}

	private SortDirection GetSortDirection(string sortDirection)
	{
		if (sortDirection != null)
		{
			if (sortDirection.Equals('DESC', StringComparison.OrdinalIgnoreCase) ||
				sortDirection.Equals('DESCENDING', StringComparison.OrdinalIgnoreCase))
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
}</pre>";

            return new HtmlString(contents1 + viewCode + contents2 + partialViewCode + contents3 + modelCode + contents4 + controllerCode + contents5);
        }

        public static IHtmlString SearchTheory(this HtmlHelper helper)
        {
            const string contents = @"<p><strong>Automatic extraction of Google search results</strong></p><p>The page gets results from Google search by two means.</p><p>1. Using the HtmlAgilityPack HTML parser, the Google search is returned with System.Net.Webclient, then the HTML is parsed and links are extracted. Here is the code for retrieving the HTML</p>";

            const string code1 = "<pre class=\"brush: csharp\">public static WebClient webClient = new WebClient();" +
 
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
            
            const string contents2 = "<p>The drawbacks of this method are that Google will server 503 errors if it suspects you are trying to automate the calls to the search engine.</p><p>2. Using the Google API. The easiest way to do that was to use Google API for .NET. When it is referenced, the following code will return the results</p>";
            
            const string code2 = "<pre class=\"brush: csharp\">private void btnSearch_Click(object sender, EventArgs e)" +
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
            
                                 @"The drawbacks are that the API is deprecated, the number of search results returned is limited to 64 and the number of calls to the API per day is limited.</p><p><strong>References:</strong></p><a href='http://gapi4net.codeplex.com/'>Google API for .NET</a><br/><a href='https://developers.google.com/web-search/docs/'>Developer's guide to Google Search API</a><br/><a href='https://developers.google.com/errors/'>Error description which specifies that automated requests are prohibited</a><br/><a href='http://stackoverflow.com/questions/5121090/google-search-api'>Google Search API</a><br/><a href='http://stackoverflow.com/questions/6084096/what-free-web-search-apis-are-available/8666532'>What free web search api's are available?</a>";

            return new HtmlString(contents + code1 + contents2 + code2);
        }

        public static IHtmlString StoneTheory(this HtmlHelper helper)
        {
            const string contents = @"<p><strong>Stepping Stone Markov Chain model</strong></p><p>A Markov chain is a process which can be in a number of states. The process starts in one of the states
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
            string contents = @"<p><strong>Game Rules [1]</strong></p><p>The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician 
                John Horton Conway in 1970.</p><p>The universe of the Game of Life is an infinite two-dimensional orthogonal grid of square cells, each of which is in one of two 
                possible states, alive or dead. Every cell interacts with its eight neighbours, which are the cells that are horizontally, vertically, or diagonally adjacent. 
                At each step in time, the following transitions occur:</p><p><ul><li>Any live cell with fewer than two live neighbours dies, as if caused by under-population.</li>
                <li>Any live cell with two or three live neighbours lives on to the next generation.</li><li>Any live cell with more than three live neighbours dies, as if by 
                overcrowding.</li><li>Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.</li></ul></p><p>The initial pattern constitutes the 
                seed of the system. The first generation is created by applying the above rules simultaneously to every cell in the seed—births and deaths occur simultaneously, 
                and the discrete moment at which this happens is sometimes called a tick (in other words, each generation is a pure function of the preceding one). The rules continue 
                to be applied repeatedly to create further generations.</p><p><strong>Implementation</strong></p><p>[1] 
                <a href=&quot;http://en.wikipedia.org/wiki/Conway%27s_game_of_life&quot;>Conway's Game Of Life</a></p>";

            const string t = "<p>To refresh the page every second, javaScript <strong></strong>setInterval function is used to load the partial view into the div. A method in the controller generates the partial view.</p><p><strong>The Controller</strong></p><pre class=\"brush: csharp\">public class GameController : BaseController" +
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
            }</pre><p>The partial view is called <strong>_Table</strong> and is nothing more than the <strong>HtmlString</strong>.</p><p><strong>_Table.cshtml</strong></p><pre class=""brush: csharp"">@model HtmlString
           
            @{ Layout = null; }

            @Model</pre><p>The model is just the <strong>HtmlString</strong> which gets rendered, and the <strong>HtmlString</strong> itself is just a simple table of a specified number of cells.</p><p><strong>Index.cshtml</strong></p><pre class=""brush: xml"">&lt;script type=&quot;text/javascript&quot;&gt;

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
            &lt;/div&gt;</pre><p>Note how the interval is set to 1000 ms and the <strong>OutputCache</strong> duration in the controller is set to the same value. Every second the call to load will return a partial view from the <strong>Update</strong> method. What does the <strong>Update</strong> method return? When the game starts, and empty html table is created with each cell having a blue background.</p><pre class=""brush: csharp"">public static void NewGameTable()
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
            }</pre><p>Function <strong>CheckCell</strong> applies game rules to a cell to check if it will be alive or dead in the next iteration.</p><pre class=""brush: csharp"">public static bool CheckCell(bool[,] arr, int i, int j)
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

        public static IHtmlString GlobalAlignmentTheory(this HtmlHelper helper)
        {
            const string contents = @"Global Alignment Theory Goes Here";

            return new HtmlString(contents);
        }
    }
}