using System;
//skip writing "Console" many times throughout the code
using static System.Console;
using System.Collections.Generic;
using System.IO;
//this namespace allows serialize and deserialize JSON
using System.Text.Json;

namespace Moment3CSharp
//change POST to something longer?
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

            //if field author is empty, show the following message
             if (string.IsNullOrWhiteSpace(author)) {
                WriteLine("Omöjligt att spara inlägg utan författarents namn!");
                WriteLine("Författares namn: ");
                author = ReadLine();}
            
            //if field post is empty, show the following message
            if (string.IsNullOrWhiteSpace(postText)){
                WriteLine("Omöjligt att spara tom inlägg!");
                WriteLine("Inlägg: ");
                postText = ReadLine();}
     
            //save post if both author's name and the text were detected
            posts.Add(new Post { Author = author, PostText = postText });
            SavePostToJson();
            WriteLine("Inlägg sparades!");
            
        }

        
        // show all the posts
        public void DisplayAllPosts()
        {
            Clear();
            WriteLine("Inlägg i gästboken:\n");
            

            // go through exsting posts and display each of them
            for (int i = 0; i < posts.Count; i++)
            {
                WriteLine($"{posts[i]}\n-----------------------");
                             
            }
            //show menu after all the posts
            ShowMenu();
        }


        // Delete a post by id
        public void DeletePost()
        {
            Clear();
            //show all the posts so that user may choose which one to delete
            WriteLine("Alla inlägg:");

            // go through existing posts and display post and its id each on new line
            for (int i = 0; i < posts.Count; i++)
            {
                WriteLine($"{i + 1}. {posts[i]}");
            }

            WriteLine("Skriv nummer av inlägg du vill radera (tänk att det går inte att ångra ditt val): ");
            //parse the user input, extract integer
            if (int.TryParse(ReadLine(), out int index) && index > 0 && index <= posts.Count)
            {
                //delete the post with chosen id. method RemoveAt is used to do that
                posts.RemoveAt(index - 1);
                //save the changes JSON file again, show confirmational message and the menu
                SavePostToJson();
                WriteLine("Inlägg raderad!");
                ShowMenu();
            }
            //if user gave unexistant post id, show the message
            else
            {
                WriteLine($"Inlägg med nummer {index} finns inte.");
            }
        }

        // Delete all the posts
        public void DeleteEverything()
        {
            Clear();
            //ask user for confirmation
            Write("Vill du verkligen radera alla inlägg? \n Ja - tryck Y \n Nej - tryck på valfri knapp");
            string answer = ReadLine();
             
            //of user really wants to delete everthing, do it and show the confirmatoin
            if (answer == "Y" || answer == "y")
            {
                posts.Clear();
                SavePostToJson();
                WriteLine("Alla inlägg var raderade.");
                ShowMenu();
            }
            //if user chose not to delete everything, show the main menu
            else
            {
                ShowMenu();
            }
        }

        // Save new posts to JSON file. Serialize
        public void SavePostToJson()
        {
            //convert posts to JSON
            string json = JsonSerializer.Serialize(posts);
            //write posts to file
            File.WriteAllText(jsonFile, json);
        }

        // Get post from JSON file. Deserialize
        private void GetPostsFromJson()
        {
                //read JSON
                string json = File.ReadAllText(jsonFile);
                //convert JSON contents to objects of class Post
                posts = JsonSerializer.Deserialize<List<Post>>(json);
            
        }
       
       
    }
}
