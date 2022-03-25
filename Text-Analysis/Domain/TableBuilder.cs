using System;
namespace TextAnalysis.Domain
{
    public class TableBuilder
    {
        #region(Constructor)
        public TableBuilder()
        {
        }
        #endregion

        static int tableWidth = 175;

        #region(methods)

        //Print a '-' characters with defined lenght in console
        public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        //Print a table raw 
        public void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        //Alight text in the raw
        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        #endregion
    }
}
