using System.Text;
using System.Linq;

namespace Recipes.HtmlHelpers
{
    public static class GameOfLifeHelpers
    {
        public const int x = 50;
        public const int y = 50;

        public static bool[,] arrOne = new bool[x, y];
        public static bool[,] arrTwo = new bool[x, y];

        public static StringBuilder table;
        public static int counter;

        public static void InitializeGame()
        {
            NewGameTable();
            InitializeArray(arrOne, false);
            InitializeArray(arrTwo, false);
        }

        public static void InitializeArray(bool[,] arr, bool value)
        {
            int iDim = arr.GetLength(0);
            int jDim = arr.GetLength(1);
            for (int i = 0; i < iDim; i++)
            {
                for (int j = 0; j < jDim; j++)
                {
                    arr[i, j] = value;
                }
            }
        }

        public static void AddGlider(bool[,] arr, int x, int y)
        {
            arr[x - 1, y] = false;
            arr[x - 1, y + 1] = false;
            arr[x - 1, y + 2] = true;

            arr[x, y] = true;
            arr[x, y + 1] = false;
            arr[x, y + 2] = true;

            arr[x + 1, y] = false;
            arr[x + 1, y + 1] = true;
            arr[x + 1, y + 2] = true;
        }

        public static void DrawStartIteration()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (arrOne[i, j])
                    {
                        table = GameOfLifeTableReplaceCell(i, j, "#FF0000", table);
                    }
                }
            }
        }

        public static void DrawNextIteration()
        {
            bool[,] arrCurrent = counter % 2 == 0 ? arrOne : arrTwo;
            bool[,] arrNext = counter % 2 == 0 ? arrTwo : arrOne;

            FillArray(arrNext, arrCurrent);

            counter++;

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (arrNext[i, j] != arrCurrent[i, j])
                    {
                        table = arrNext[i, j] ? GameOfLifeTableReplaceCell(i, j, "#FF0000", table) : GameOfLifeTableReplaceCell(i, j, "#0276FD", table);
                    }
                }
            }
        }

        public static void NewGameTable()
        {
            table = new StringBuilder(@"<table border=1 bordercolor=black cellspacing=0 cellpadding=0>");

            for (int i = 0; i < y; i++)
            {
                table.Append("<tr>");

                for (int j = 0; j < x; j++)
                {
                    table.Append("<td width=10px height=10px bgcolor=#0276FD></td>");
                }

                table.Append("</tr>");
            }

            table.Append("</table>");
        }

        public static StringBuilder GameOfLifeTableReplaceCell(int i, int j, string colour, StringBuilder sb)
        {
            const int rowLength = 48 * x + 9;
            const int cellLength = 48;

            int start = 62 + i * rowLength + 4 + j * cellLength + 35;

            sb.Remove(start, 7);
            sb.Insert(start, colour);

            return sb;
        }

        public static void FillArray(bool[,] arrNext, bool[,] arrCurrent)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    arrNext[i, j] = CheckCell(arrCurrent, i, j);
                }
            }
        }

        public static bool CheckCell(bool[,] arr, int i, int j)
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

            int val = neighbours.Count(c => c);

            if (arr[i, j])
                return (val >= 2 && val <= 3) ? true : false;
            else
                return (val == 3) ? true : false;
        }
    }
}