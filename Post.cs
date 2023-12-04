namespace Moment3CSharp
{
    //create class Post which is the part of the guest book
    public class Post
    {
        //get value of the properties Author and PostText and assign values to them
        public string Author { get; set; }
        public string PostText { get; set; }
        
        //represent objects of class Post as strings
        public override string ToString()
        {
            return $"{PostText}.\n*\npublicerad av {Author}";
        }
    }
}
