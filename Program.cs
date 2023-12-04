using System;
using static System.Console;

namespace Moment3CSharp
{
    class Program
    {
        
        static void Main(string[] args)
        {
           //create a new guest book object
         GuestBook NewGuestBook = new GuestBook();
         Clear();
         //call method which shows the menu
        NewGuestBook.ShowMenu();
            while (true)
            {
                

                var option = ReadLine();
                
                if (option == "1"){
                        
                            NewGuestBook.CreateNewPost();}
                 else if (option == "2"){
                            NewGuestBook.DisplayAllPosts();}
                 else if (option == "3"){
                            NewGuestBook.DeletePost();}
                else if (option == "4"){
                            NewGuestBook.DeleteEverything();}
                else if (option == "X" ^ option == "x"){
                            Environment.Exit(0);
                            break;}
                
               
                else
                {
                    WriteLine("Du råkade göra fel knappaval. Försök igen!");

                }
               
            }
        }

       
    }
}
