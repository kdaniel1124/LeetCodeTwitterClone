using TwitterJunior;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Twitter twit = new Twitter();
        twit.PostTweet(1, 2);
        twit.PostTweet(1, 4);
        twit.PostTweet(2, 6);
        twit.PostTweet(2, 8);
        twit.PostTweet(3, 10);
        twit.PostTweet(3, 12);
        twit.PostTweet(4, 14);
        twit.PostTweet(4, 16);

        IList<int> feed = twit.GetNewsFeed(1);

        foreach(int tweet in feed)
        {
            Console.WriteLine(tweet);
        }
        Console.WriteLine(twit.Tweets[0]);

    }
}