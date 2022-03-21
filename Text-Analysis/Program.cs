using System;
using TextAnalysis.Domain;

namespace TextAnalysis
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            TextAnalyser ts = new TextAnalyser();
            //string text = "I am a student.But I am cute.";
            //Console.WriteLine(ts.CountNumberOfWords(text));
            //Console.WriteLine(ts.CountWordOccurence(text, "am"));
            //Console.WriteLine(ts.CountCharacterOccurence(text, 'a'));
            //Console.WriteLine(ts.CountNumberOfCharacters(text));
            ts.GetCharacterOccurence('i');
            ts.GetWordOccurence("in");
            ts.GetNumberOfLines();
            ts.GetNumberOfWords();
            ts.GetNumberOfCharacters();
            ts.GetSummaryReport('i', "in");
            //ts.LoadFiles();

        }
    }
}
