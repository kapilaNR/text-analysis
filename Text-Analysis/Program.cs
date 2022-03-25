using System;
using TextAnalysis.Domain;

namespace TextAnalysis
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Create menu class object
            Menu menu = new Menu();

            //Get file name for analysis
            string file = menu.GetFileMenu();

            //Create text analyser Object using the file
            TextAnalyser ts = new TextAnalyser(file);

            //Show main menu
            menu.GetMenu();

            //Initiate menu opttion
            int option = 0;

            //This while loop will run untile Option not qual to 8
            do
            {
                Console.Write("Option :");
                option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    //Get word for matching
                    Console.Write("Enter word :");
                    string word = Console.ReadLine();

                    //Call word matching method
                    ts.GetWordOccurence(word);
                }                   
                if (option == 2)
                {
                    //Get character for search
                    Console.Write("Enter charater :");
                    char character = Convert.ToChar(Console.ReadLine());

                    //Call character matching method
                    ts.GetCharacterOccurence(character);
                }
                if (option == 3)
                {
                    //Call line counting method
                    ts.GetNumberOfLines();
                }
                if (option == 4)
                {
                    //Call word count method
                    ts.GetNumberOfWords();
                }
                if (option == 5)
                {
                    //Call most used word method
                    ts.GetMostUsedWord();
                }
                if (option == 6)
                {
                    //Call longest word method
                    ts.GetLongWord();
                }
                if (option == 7)
                {
                    //Get word as input
                    Console.Write("Enter word :");
                    string input1 = Console.ReadLine();

                    //Get character as input
                    Console.Write("Enter charater :");
                    char input2 = Convert.ToChar(Console.ReadLine());

                    //Call Summary report method
                    ts.GetSummaryReport(input2, input1);
                }     
                
            } while (option != 8);
            
        }
    }
}
