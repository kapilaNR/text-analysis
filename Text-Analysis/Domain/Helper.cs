using System;
using TextAnalysis.Util;
using System.Linq;
using System.IO;

namespace TextAnalysis.Domain
{
    public class Helper
    {
        public Helper()
        {
        }

        Constant constant = new Constant();

        public int CountWordOccurence(String text, String term)
        {
            //Convert the string into an array of words  
            string[] source = GetSplitArray(text);

            // Create the query.  Use ToLowerInvariant to match "data" and "Data"
            var matchQuery = from word in source
                             where word.ToLowerInvariant() == term.ToLowerInvariant()
                             select word;

            // Count the matches, which executes the query.  
            int wordCount = matchQuery.Count();
            return wordCount;
        }

        public int CountCharacterOccurence(String text, char character)
        {
            int freq = text.Count(f => (f == character));
            return freq;
        }

        public int CountNumberOfLines(string fileName)
        {
            return 0;
        }

        public int CountNumberOfWords(String text)
        {
            string[] reslts = GetSplitArray(text);
            return reslts.Length;
        }

        public int CountNumberOfCharacters(String text)
        {
            int count = 0;
            foreach (char c in text)
            {
                count++;
            }
            return count;
        }

        private string[] GetSplitArray(String text)
        {
            string[] reslts = text.Split(constant.GetEscapeCharacters(), StringSplitOptions.RemoveEmptyEntries);
            return reslts;
        }

        public int Analyzer(string option, string fileName)
        {
            int count = 0;
            String filePath = Directory.GetCurrentDirectory() + "/Input/" + fileName;
            StreamReader streamReader = new StreamReader(filePath);
            while (!streamReader.EndOfStream)
            {
                String text = streamReader.ReadLine();
                switch (option)
                {
                    case "words":
                        count = count + CountNumberOfWords(text);
                        break;
                    case "lines":
                        count = count + 1;
                        break;
                    case "characters":
                        count = count + CountNumberOfCharacters(text);
                        break;

                }

            }
            return count;
        }

        public int Analyzer(string option, string fileName, string term)
        {

                int wordCount = 0;
                String filePath = Directory.GetCurrentDirectory() + "/Input/" + fileName;
                StreamReader streamReader = new StreamReader(filePath);
                while (!streamReader.EndOfStream)
                {
                    String text = streamReader.ReadLine();
                    wordCount = wordCount + CountWordOccurence(text, term);
                }
                streamReader.Close();
            return wordCount;

        }

        public int Analyzer(string option, string fileName, char term)
        {
            int CharacterCount = 0;
            String filePath = Directory.GetCurrentDirectory() + "/Input/" + fileName;
            StreamReader streamReader = new StreamReader(filePath);
            while (!streamReader.EndOfStream)
            {
                String text = streamReader.ReadLine();
                CharacterCount = CharacterCount + CountCharacterOccurence(text, term);
            }
            streamReader.Close();
            return CharacterCount;

        }
    }
}
