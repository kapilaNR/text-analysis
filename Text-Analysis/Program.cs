using System;
using TextAnalysis.Domain;

namespace TextAnalysis
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Menu menu = new Menu();
            string file = menu.GetFileMenu();

            TextAnalyser ts = new TextAnalyser(file);

            menu.GetMenu();
            int option = 0;
            do
            {
                Console.Write("Option :");
                option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    Console.Write("Enter word :");
                    string word = Console.ReadLine();
                    ts.GetWordOccurence(word);
                }
                    
                if (option == 2)
                {
                    Console.Write("Enter charater :");
                    char character = Convert.ToChar(Console.ReadLine());
                    ts.GetCharacterOccurence(character);
                }
                if (option == 3)
                {
                    ts.GetNumberOfLines();
                }
                if (option == 4)
                {
                    ts.GetNumberOfWords();
                }
                if (option == 5)
                {
                    ts.GetMostUsedWord();
                }
                if (option == 6)
                {
                    ts.GetLongWord();
                }
                if (option == 7)
                {
                    Console.Write("Enter word :");
                    string input1 = Console.ReadLine();
                    Console.Write("Enter charater :");
                    char input2 = Convert.ToChar(Console.ReadLine());
                    ts.GetSummaryReport(input2, input1);
                }     
                
            } while (option != 8);           
        }
    }
}
