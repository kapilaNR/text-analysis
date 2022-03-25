﻿using System;
namespace TextAnalysis.Util
{
    //This class contain all the constant values which use inside text-analysis programme
    static class Constant
    {
        //escape characters to validate user input
        public static char[] escapeCharacters = new char[] { '.', '?', '!', ' ', ';', ':', ',' , ' ' };

        //Input file names that used to analyse text
        public static string[] inputFileNames = new string[] { "Text1.txt", "Text2.txt", "Text3.txt", "Text4.txt" };

        //English alphabet array used to identify letters in the text file
        public static char[] alphabet = new char[] { 'a', 'b', 'c', 'd' ,'e','f','g','h','i','j','k','l','m','n','o','p','q','r','t','s','u','v','w','x','y','z'};

        //Text file names
        public const string Text1 = "Text1.txt";
        public const string Text2 = "Text2.txt";
        public const string Text3 = "Text3.txt";
        public const string Text4 = "Text4.txt";

        //Main menu options as a strings
        public const string wordOccurence = "Enter a word and see how many times it occurs in the file.";
        public const string charactereOccurence = "Enter a single character and see how many times it occurs in the file.";
        public const string numberOfLines = "Get the number of lines in the file.";
        public const string numberOfWords = "Get the number of words in the file.";
        public const string numberOfChars = "Get the number of characters in the file.";
        public const string mostFreqWord = "Get most frequently occurring word.";
        public const string longestWord = "Get the longest word.";
        public const string getAnalysis = "Get all text analysis summary.";
        public const string exit = "Finish text analysis.";

        //Head line of the programme
        public const string header = "Text analyser";

    }
}
