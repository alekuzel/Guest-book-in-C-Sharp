namespace Moment3CSharp
{
    public class Post
    {
        public string Author { get; set; }
        public string PostText { get; set; }

        public override string ToString()
        {
            return $"{Author}: {PostText}";
        }
    }
}
