using System;
using static System.Console;

namespace Moment3CSharp
{
    class Program
    {
        
        static void Main(string[] args)
        {
           //create a new object of class guest book
         GuestBook NewGuestBook = new GuestBook();
         Clear();
         //call method which shows the menu
        NewGuestBook.ShowMenu();
            while (true)
            {
                //variable which stores the number or X chosen by the user
                var option = ReadLine();
                
                //call different methods based on users choice
                if (option == "1"){
                            NewGuestBook.CreateNewPost();}
                else if (option == "2"){
                            NewGuestBook.DisplayAllPosts();}
                else if (option == "3"){
                            NewGuestBook.DeletePost();}
                else if (option == "4"){
                            NewGuestBook.DeleteEverything();}
                else if (option == "X" ^ option == "x"){
                            break;}
                else
                {   
                    WriteLine("Du råkade göra fel knappaval. Försök igen!");//show this message if user clicks for a button outside the menu range

                }
               
            }
        }

       
    }
}
