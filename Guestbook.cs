using System;
//skip writing "Console" many times throughout the code
using static System.Console;
using System.Collections.Generic;
using System.IO;
//this namespace allows serialize and deserialize JSON
using System.Text.Json;

namespace Moment3CSharp
{
  //create the GuestBook class
    public class GuestBook
    {
        //list of the objects of the class Post. the access modifier "private" makes it inaccessible from the other classes
        private List<Post> posts;

        //variable which contains the name of the JSON file where the posts will be saved
        //it is of type consts as it is unlikely to be changed
        private const string jsonFile = "posts.json";

        // activate the guest book and get the posts from the JSON file, if there are any
        public GuestBook()
        {
            posts = new List<Post>();
            GetPostsFromJson();
        }
         
         //show the menu
         public void ShowMenu(){
               WriteLine("Hej och välkommen till gästbok! Vad vill du göra:");
                WriteLine("-------------------------------------------------");
                WriteLine("1 - Skapa ny inlägg");
                WriteLine("2 - Visa alla inlägg");
                WriteLine("3 - Radera en inlägg");
                WriteLine("4 - Radera alla inlägg");
                WriteLine("X - Avsluta");
                WriteLine("-------------------------------------------------");
        }

        // create new post in the guest book
        public void CreateNewPost()
        {
           
            WriteLine("Författares namn: ");    //ask user to write name
           
            string author = ReadLine();      //save input as the variable author
           
            WriteLine("Inlägg: ");     //ask user to write name
            string postText = ReadLine();    //save input as variable postText

            //Make sure author and post fields are not empty
             if (string.IsNullOrWhiteSpace(author)) {
                WriteLine("Omöjligt att spara inlägg utan författarents namn!");
                WriteLine("Författares namn: ");
                author = ReadLine();}

            if (string.IsNullOrWhiteSpace(postText)){
                Write("Write your post: ");
                WriteLine("Omöjligt att spara tom inlägg!");
                WriteLine("Inlägg: ");
                postText = ReadLine();}
     

            posts.Add(new Post { Author = author, PostText = postText });
            SavePostToJson();
            WriteLine("Inlägg sparades!");
            
        }

        // Delete a post with specified id
        public void DeletePost()
        {
            Clear();
            WriteLine("Alla inlägg:");

            // Display entries with index
            for (int i = 0; i < posts.Count; i++)
            {
                WriteLine($"{i + 1}. {posts[i]}");
            }

            WriteLine("Skriv nummer av inlägg du vill radera (tänk att det går inte att ångra ditt val): ");
            if (int.TryParse(ReadLine(), out int index) && index > 0 && index <= posts.Count)
            {
                posts.RemoveAt(index - 1);
                SavePostToJson();
                WriteLine("Inlägg raderad!");
                ShowMenu();
            }
            else
            {
                WriteLine($"Inlägg med nummer {index} finns inte.");
            }
        }

        // Delete all the posts
        public void DeleteEverything()
        {
            Clear();
            Write("Vill du verkligen radera alla inlägg? \n Ja - tryck Y \n Nej - tryck N ");
            string answer = ReadLine();

            if (answer == "Y")
            {
                posts.Clear();
                SavePostToJson();
                WriteLine("Alla inlägg var raderade.");
                ShowMenu();
            }
            else
            {
                ShowMenu();
            }
        }

        // show all the posts
        public void DisplayAllPosts()
        {
            Clear();
            WriteLine("Inlägg i gästboken:");

            // Display entries with index
            for (int i = 0; i < posts.Count; i++)
            {
                WriteLine($"{i + 1}. {posts[i]}");
                WriteLine("-----------------------");                
            }
            ShowMenu();
        }

        // Save new posts to JSON file. Serialize
        public void SavePostToJson()
        {
            string json = JsonSerializer.Serialize(posts);
            File.WriteAllText(jsonFile, json);
        }

        // Get post from JSON file. Deserialize
        private void GetPostsFromJson()
        {
            if (File.Exists(jsonFile))
            {
                string json = File.ReadAllText(jsonFile);
                posts = JsonSerializer.Deserialize<List<Post>>(json);
            }
        }
       
       
    }
}
