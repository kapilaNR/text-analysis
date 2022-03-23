using System;
using TextAnalysis.Util;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace TextAnalysis.Domain
{
    public class TextAnalyser
    {
        #region(Feilds)
        Helper helper;
        string[] fileNames;
        string fileName;
        #endregion

        #region(Constructor)
        public TextAnalyser(string fileName)
        {
            this.fileName = fileName;
            helper = new Helper();
        }
        #endregion
        

        #region(Methods)
        public void GetWordOccurence(String term)
        {
            if(!fileName.Equals(null) )
                Console.WriteLine("{0} has {1} Word Occurence.", fileName, helper.Analyzer("WordOccurence",fileName, term));

        }

        public void GetCharacterOccurence(char character)
        {
            if (!fileName.Equals(null))
                Console.WriteLine("{0} has {1} Character Occurence.", fileName, helper.Analyzer("CharacterOccurence", fileName, character));

        }

        public void GetNumberOfLines()
        {
            if (!fileName.Equals(null))
                Console.WriteLine("{0} has {1} lines.", fileName, helper.Analyzer("lines", fileName));


        }

        public void GetNumberOfWords()
        {
            if (!fileName.Equals(null))
                Console.WriteLine("{0} has {1} words.", fileName, helper.Analyzer("words", fileName));

        }

        public void GetNumberOfCharacters()
        {
            if (!fileName.Equals(null))
                Console.WriteLine("{0} has {1} Characters.", fileName, helper.Analyzer("characters", fileName));

        }

        public void GetLongWord()
        {
            if (!fileName.Equals(null))
                Console.WriteLine("Longest Word in {0} file is '{1}' .", fileName, helper.FindLogestWord(fileName));

        }

        public void GetMostUsedWord()
        {
            if (!fileName.Equals(null))
                Console.WriteLine("Most used word in {0} file is '{1}' .", fileName, helper.FindFreqWord(fileName));

        }

        private IDictionary<string, Report> GetComparison(char character, string word)
        {
            IDictionary<string, Report> reports = new Dictionary<string, Report>();
            fileNames = Constant.inputFileNames;
            if (!word.Equals(Constant.escapeCharacters))
                foreach (var fileName in fileNames)
                {
                    Report report = new Report();
                    report.CharacterOccurence = helper.Analyzer("CharacterOccurence", fileName, character);
                    report.WordOccurence = helper.Analyzer("WordOccurence", fileName, word);
                    report.NumberOfCharacters = helper.Analyzer("characters", fileName);
                    report.NumberOfLines = helper.Analyzer("lines", fileName);
                    report.WordCount = helper.Analyzer("words", fileName);
                    report.LongestWord = helper.FindLogestWord(fileName);
                    report.MostUsedWord = helper.FindFreqWord(fileName);
                    reports.Add(fileName, report);
                }

            return reports;

        }

        public void GetSummaryReport(char character, string word)
        {
            TableBuilder table = new TableBuilder();
            IDictionary<string, Report> reports = GetComparison(character, word);
            table.PrintLine();
            table.PrintRow("File", "CharacterOccurence ", "WordOccurence", "WordCount", "NumberOfCharacters", "NumberOfLines", "Longest Word","Most Used Word");
            table.PrintLine();
            foreach (var item in reports)
            {

                table.PrintRow(item.Key, item.Value.CharacterOccurence.ToString(),
                    item.Value.WordOccurence.ToString(), item.Value.WordCount.ToString(),
                    item.Value.NumberOfCharacters.ToString(), item.Value.NumberOfLines.ToString(),
                    item.Value.LongestWord, item.Value.MostUsedWord);
            }
            table.PrintLine();

        }
        #endregion
    }
}
