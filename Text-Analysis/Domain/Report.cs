using System;
namespace TextAnalysis.Domain
{
    public class Report
    {
        #region(constructor)
        public Report()
        {
        }
        #endregion

        #region(feilds)
        private int wordCount;
        private int characterOccurence;
        private int wordOccurence;
        private int numberOfLines;
        private int numberOfCharacters;
        private string mostUsedWord;
        private string longestWord;
        #endregion

        #region(properties)
        public int WordCount
        {
            get
            {
                return wordCount;
            }
            set
            {
                wordCount = value;
            }
        }

        public int CharacterOccurence
        {
            get
            {
                return characterOccurence;
            }
            set
            {
                characterOccurence = value;
            }
        }

        public int WordOccurence
        {
            get
            {
                return wordOccurence;
            }
            set
            {
                wordOccurence = value;
            }
        }

        public int NumberOfLines
        {
            get
            {
                return numberOfLines;
            }
            set
            {
                numberOfLines = value;
            }
        }

        public int NumberOfCharacters
        {
            get
            {
                return numberOfCharacters;
            }
            set
            {
                numberOfCharacters = value;
            }
        }

        public string MostUsedWord
        {
            get
            {
                return mostUsedWord;
            }
            set
            {
                mostUsedWord = value;
            }
        }

        public string LongestWord
        {
            get
            {
                return longestWord;
            }
            set
            {
                longestWord = value;
            }
        }
        #endregion

    }
}
