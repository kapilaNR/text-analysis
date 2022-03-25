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

        //Return Count number of characters in given text
        public int CountCharacterOccurence(String text, char character)
        {
            int freq = text.ToLowerInvariant().Count(f => (f == character));
            return freq;
        }

        //Return longest word in given string array
        public string GetLongestWord(string[] words)
        {           
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

        //Return logest word in given string word list. This is a method overloading.
        public string GetLongestWord(List<string> words)
        {
            
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

        //Return count of word in the string
        public int CountNumberOfWords(String text)
        {
            string[] reslts = GetSplitArray(text);
            return reslts.Length;
        }

        //Return count of charaters in the string
        public int CountNumberOfCharacters(String text)
        {
            int count = 0;
            foreach (char c in text)
            {
                count++;
            }
            return count;
        }

        //Return splitted word array in given text.
        private string[] GetSplitArray(String text)
        {
            List<string> words = new List<string>() ;
            string wordLine = text.ToLowerInvariant();
            string word="";
            for (int i =0; wordLine.Length > i; i++)
            {
                //Check character is equal to alphabet letter
                if (Constant.alphabet.Contains(wordLine[i]))
                {
                    word = word + wordLine[i];
                }
                else
                {
                    //Add string to words array if next charater is not a letter
                    if(word.Length>0)
                        words.Add(word);

                    word = "";
                }
            }
            return words.ToArray();
        }

        //Return word count, character count based on the option and file name
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

        //Return word occurence count using given file and given word
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

        //Return character occurenece using given file and character
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

        //Return lonest word in the file
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

        //Return most frequently used word in the file
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

        //Return dictionary with word as a key and occurence count as a value
        private IDictionary<string, int> UpdateWordDictionary(string[] wordArray, IDictionary<string, int> wordOccurences)
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
