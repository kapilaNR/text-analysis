using System;
using TextAnalysis.Util;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace TextAnalysis.Domain
{
    public class Helper
    {
        #region(constructor)
        public Helper()
        {
        }
        #endregion

        #region(method)
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
            int freq = text.ToLowerInvariant().Count(f => (f == character));
            return freq;
        }

        public string GetLongestWord(string[] words)
        {
            //string[] words = GetSplitArray(text);
            string longestWord = "";
            int size = 0;
            foreach(string word in words)
            {
                int currentSize = CountNumberOfCharacters(word);
                if (size < currentSize)
                {
                    size = currentSize;
                    longestWord = word;
                }
            }
            
            return longestWord;
        }

        public string GetLongestWord(List<string> words)
        {
            //string[] words = GetSplitArray(text);
            string longestWord = "";
            int size = 0;
            foreach (string word in words)
            {
                int currentSize = CountNumberOfCharacters(word);
                if (size < currentSize)
                {
                    size = currentSize;
                    longestWord = word;
                }
            }

            return longestWord;
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
            string[] reslts = text.Split(Constant.escapeCharacters, StringSplitOptions.RemoveEmptyEntries);
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

        public string FindLogestWord(string fileName)
        {
            String filePath = Directory.GetCurrentDirectory() + "/Input/" + fileName;
            StreamReader streamReader = new StreamReader(filePath);
            
            List<string> filterdWords = new List<string>();
            while (!streamReader.EndOfStream)
            {
                String text = streamReader.ReadLine();
                filterdWords.Add(GetLongestWord(GetSplitArray(text)));
            }
            return GetLongestWord(filterdWords);
        }

        public string FindFreqWord(string fileName)
        {
            String filePath = Directory.GetCurrentDirectory() + "/Input/" + fileName;
            StreamReader streamReader = new StreamReader(filePath);

            IDictionary<string, int> wordOccurences = new Dictionary<string, int>();

            while (!streamReader.EndOfStream)
            {
                String text = streamReader.ReadLine();
                wordOccurences = UpdateWordDictionary(GetSplitArray(text), wordOccurences);
            }
            wordOccurences.FirstOrDefault(x => x.Value == wordOccurences.Values.Max()) ;
            return wordOccurences.FirstOrDefault(x => x.Value == wordOccurences.Values.Max()).Key;
        }

        public IDictionary<string, int> UpdateWordDictionary(string[] wordArray, IDictionary<string, int> wordOccurences)
        {
            foreach(string word in wordArray)
            {
                if (wordOccurences.ContainsKey(word))
                {
                    wordOccurences[word] = wordOccurences[word]+1;
                }
                else
                {
                    wordOccurences.Add(word, 1);
                }
                
            }
            return wordOccurences;
        }
        #endregion
    }
}
