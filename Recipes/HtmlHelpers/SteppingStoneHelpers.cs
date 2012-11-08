using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.HtmlHelpers
{
    public static class SteppingStoneHelpers
    {
        static Random rnd = new Random();

        public const int x = 50;
        public const int y = 50;

        public static int numColoursUsed = 4;

        public static int[,] arr = new int[x,y];

        public static StringBuilder table;

        public static List<string> colours = new List<string>()
                                                 {
                                                     "#00FFFF", //aqua
                                                     "#000000", //black
                                                     "#0000FF", //blue
                                                     "#FF00FF", //fuchsia
                                                     "#808080", //gray
                                                     "#008000", //green
                                                     "#00FF00", //lime
                                                     "#800000", //maroon
                                                     "#000080", //navy
                                                     "#808000", //olive
                                                     "#800080", //purple
                                                     "#FF0000", //red
                                                     "#C0C0C0", //silver
                                                     "#008080", //teal
                                                     "#FFFFFF", //white
                                                     "#FFFF00", //yellow
                                                 };

        
            
         public static void CreateNewTable()
         {
             int colourID = 0;

             table = new StringBuilder(@"<table border=1 bordercolor=black cellspacing=0 cellpadding=0>");

             for (int i = 0; i < y; i++)
             {
                 table.Append("<tr>");

                 for (int j = 0; j < x; j++)
                 {
                     table.Append("<td width=10px height=10px bgcolor=");
                     colourID = rnd.Next(0, numColoursUsed - 1);
                     arr[i, j] = colourID;
                     table.Append(colours[colourID]);
                     table.Append("></td>");
                 }

                 table.Append("</tr>");
             }

             table.Append("</table>");
         }

        public static void CalculateNextIteration()
        {
            //get a random element
            int randomI = rnd.Next(0, x);
            int randomJ = rnd.Next(0, y);

            int nextI = randomI == (x - 1) ? 0 : randomI + 1;
            int prevI = randomI == 0 ? x - 1 : randomI - 1;
            int nextJ = randomJ == (y - 1) ? 0 : randomJ + 1;
            int prevJ = randomJ == 0 ? y - 1 : randomJ - 1;

            //choose its random neighbour
            int neighbourI = 0, neighbourJ = 0;
            int randomNeighbour = rnd.Next(0, 7);
            switch (randomNeighbour)
            {
                case 0:
                    neighbourI = prevI;
                    neighbourJ = prevJ;
                    break;
                case 1:
                    neighbourI = randomI;
                    neighbourJ = prevJ;
                    break;
                case 2:
                    neighbourI = nextI;
                    neighbourJ = prevJ;
                    break;
                case 3:
                    neighbourI = prevI;
                    neighbourJ = randomJ;
                    break;
                case 4:
                    neighbourI = nextI;
                    neighbourJ = randomJ;
                    break;
                case 5:
                    neighbourI = prevI;
                    neighbourJ = nextJ;
                    break;
                case 6:
                    neighbourI = randomI;
                    neighbourJ = nextJ;
                    break;
                case 7:
                    neighbourI = nextI;
                    neighbourJ = nextJ;
                    break;
            }

            //assume colour of the neighbour
            int colour = arr[neighbourI, neighbourJ];
            //replace cell at i, j with neighbour's colour
            SteppingStoneTableReplaceCell(randomI, randomJ, colour, table);

        }

        public static StringBuilder SteppingStoneTableReplaceCell(int i, int j, int id, StringBuilder sb)
        {
            const int rowLength = 48 * x + 9;
            const int cellLength = 48;

            int start = 62 + i * rowLength + 4 + j * cellLength + 35;

            sb.Remove(start, 7);
            sb.Insert(start, colours[id]);

            return sb;
        }
    }
}