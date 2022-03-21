using System;
namespace TextAnalysis.Domain
{
    public class Report
    {
        public Report()
        {
        }

        #region(feilds)
        private int wordCount;
        private int characterOccurence;
        private int wordOccurence;
        private int numberOfLines;
        private int numberOfCharacters;
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
        #endregion

    }
}
