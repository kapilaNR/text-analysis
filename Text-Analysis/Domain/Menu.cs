using System;
using System.Collections.Generic;
using TextAnalysis.Util;

namespace TextAnalysis.Domain
{
    public class Menu
    {

        #region(constructor)
        //Defualt constructor
        public Menu()
        {
        }
        #endregion

        //Empty dictionary for Main Menu Items
        IDictionary<int, string> menuItems = new Dictionary<int, string>();

        //Empty dictionary for File selection items
        IDictionary<int, string> fileItems = new Dictionary<int, string>();

        #region(method)
        //Print Main Options in the Console
        public void GetMenu()
        {
            SetMenu();
            AddHeader();
            AddLine();
            foreach (var item in menuItems)
            {
                Console.WriteLine("{0} : {1}", item.Key,item.Value);
            }
            AddLine();
        }

        //Set Main Option menu items to menuItem dictionary
        private void SetMenu()
        {
            menuItems.Add(1, Constant.wordOccurence);
            menuItems.Add(2, Constant.charactereOccurence);
            menuItems.Add(3, Constant.numberOfLines);
            menuItems.Add(4, Constant.numberOfWords);
            menuItems.Add(5, Constant.mostFreqWord);
            menuItems.Add(6, Constant.longestWord);
            menuItems.Add(7, Constant.getAnalysis);
            menuItems.Add(8, Constant.getFileList);
            menuItems.Add(9, Constant.exit);
        }

        //Print 100 lenght horizontal line in console
        private void AddLine()
        {
            Console.WriteLine(new string('-', 100));
        }

        //Print Heading of the Programme
        private void AddHeader()
        {
            Console.WriteLine(Constant.header);
        }

        //Set file name to fileName dictonary
        private void SetFileMenu()
        {
            fileItems.Add(1, Constant.text1);
            fileItems.Add(2, Constant.text2);
            fileItems.Add(3, Constant.text3);
            fileItems.Add(4, Constant.text4);
        }

        //Print Menu for file names in the fileItem dictionary and collect user filename input option
        public string GetFileMenu()
        {
            SetFileMenu();
            AddLine();
            foreach (var item in fileItems)
            {
                Console.WriteLine("Press {0} for {1}", item.Key, item.Value);
            }
            AddLine();
            Console.Write("Enter file Option :");
            int fileKey;
            try
            {
                fileKey = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.Write("Invalid input Please.Please enter again.");
                Console.Write("Enter file Option :");
                fileKey = Convert.ToInt32(Console.ReadLine());
            }
            
            return fileItems[fileKey];
        }
        #endregion
    }
}
