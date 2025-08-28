using EF_Core_Configuration.Data;

namespace EF_Core_Configuration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("-------- Users -----------");
                Console.WriteLine();
                foreach (var user in context.tblUsers)
                {
                    Console.WriteLine(user.Username);
                }
                Console.WriteLine();
                Console.WriteLine("-------- Tweets -----------");
                Console.WriteLine();
                foreach (var tweet in context.Tweets)
                {
                    Console.WriteLine(tweet.TweetText);
                }
                Console.WriteLine();
                Console.WriteLine("-------- Comments -----------");
                Console.WriteLine();
                foreach (var comment in context.Comments)
                {
                    Console.WriteLine(comment.CommentText);
                }
            }
            Console.ReadKey();
        }
    }
}
