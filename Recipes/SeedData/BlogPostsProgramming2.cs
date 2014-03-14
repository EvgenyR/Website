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
    }
}