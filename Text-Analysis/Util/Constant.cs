using System;
namespace TextAnalysis.Util
{
    public class Constant
    {

        private static char[] escapeCharacters = new char[] { '.', '?', '!', ' ', ';', ':', ',' , ' ' };
        private static string[] inputFileNames = new string[] { "Text1.txt", "Text2.txt", "Text3.txt", "Text4.txt" };

        public char[] GetEscapeCharacters()
        {
            return escapeCharacters;
        }

        public string[] GetInputFiles()
        {
            return inputFileNames;
        }
    }
}
