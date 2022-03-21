﻿using System;
using TextAnalysis.Util;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace TextAnalysis.Domain
{
    public class TextAnalyser
    {
        #region(Constructor)
        public TextAnalyser()
        {
            fileNames = constant.GetInputFiles();
        }
        #endregion

        Helper helper = new Helper();
        Constant constant = new Constant();
        string[] fileNames;

        #region(Methods)

        public void GetWordOccurence(String term)
        {            
            foreach (var fileName in fileNames)
            {
                Console.WriteLine("{0} has {1} Word Occurence.", fileName, helper.Analyzer("WordOccurence",fileName,term));
            }
        }

        public void GetCharacterOccurence(char character)
        {
            
            foreach (var fileName in fileNames)
            {               
                Console.WriteLine("{0} has {1} Character Occurence.", fileName, helper.Analyzer("CharacterOccurence", fileName, character));

            }
        }

        public void GetNumberOfLines()
        {           
            foreach (var fileName in fileNames)
            {
               
                Console.WriteLine("{0} has {1} lines.", fileName, helper.Analyzer("lines", fileName));

            }
        }

        public void GetNumberOfWords()
        {
            
            foreach (var fileName in fileNames)
            {
                Console.WriteLine("{0} has {1} words.", fileName, helper.Analyzer("words", fileName));

            }
        }

        public void GetNumberOfCharacters()
        {           
            foreach (var fileName in fileNames)
            {
                Console.WriteLine("{0} has {1} Characters.", fileName, helper.Analyzer("characters", fileName));

            }
        }

        public IDictionary<string, Report> GetComparison(char character, string word)
        {
            IDictionary<string, Report> reports = new Dictionary<string, Report>();
            foreach (var fileName in fileNames)
            {
                Report report = new Report();
                report.CharacterOccurence = helper.Analyzer("CharacterOccurence", fileName, character);
                report.WordOccurence = helper.Analyzer("WordOccurence", fileName, word);
                report.NumberOfCharacters = helper.Analyzer("characters", fileName);
                report.NumberOfLines = helper.Analyzer("lines", fileName);
                report.WordCount = helper.Analyzer("words", fileName);
                reports.Add(fileName, report);
            }
            return reports;

        }

        public void GetSummaryReport(char character, string word)
        {
            IDictionary<string, Report> reports = GetComparison(character, word);
            Console.WriteLine("| File | CharacterOccurence | WordOccurence | WordCount | NumberOfCharacters | NumberOfLines |");
            foreach (var item in reports)
            {
                Console.WriteLine("| {0} | {1} | {2} | {3} | {4} | {5} |", item.Key, item.Value.CharacterOccurence, item.Value.WordOccurence, item.Value.WordCount,
                    item.Value.NumberOfCharacters, item.Value.NumberOfLines);
                Console.WriteLine("______________________________");
            }
            
        }
        #endregion
    }
}
