using System;
using System.Threading.Tasks;
using Classes;
using Tweetinvi;

namespace ConsoleApp.Classes
{
    public class Actions
    {
        public async Task Tweet()
        {
            // This function lets you publish tweets

            string text = getTweet();

            var userClient = new TwitterClient(Credentials.consumerKey, Credentials.consumerSecret,
            Credentials.accessToken, Credentials.accessSecret);
            var tweet = await userClient.Tweets.PublishTweetAsync(text);
            System.Console.WriteLine($"  You tweeted: '{tweet}'\n");
        }

        public async Task Follow()
        {
            // This lets you follow specified users
            string username = getUsername();

            var userClient = new TwitterClient(Credentials.consumerKey, Credentials.consumerSecret,
            Credentials.accessToken, Credentials.accessSecret);
            await userClient.Users.FollowUserAsync(username);
            System.Console.WriteLine($"  Followed {username}.\n");
        }

        public async Task viewTimeline()
        {
            // This function retrieves a certain number of tweets from the specified user timelime.
            Menu menu = new Menu();
            string username = getUsername();
            int noOfTweets = getNoOfTweets();

            var userClient = new TwitterClient(Credentials.consumerKey, Credentials.consumerSecret,
            Credentials.accessToken, Credentials.accessSecret);

            var timelineTweets = await userClient.Timelines.GetUserTimelineAsync(username);
            int count = 1;

            try
            {
                while (count <= noOfTweets)
                {
                    System.Console.WriteLine($"   {count}. {timelineTweets[count]}");
                    count++;
                }
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e.ToString());
            }
            await menu.displayMenu();
        }
        public string getTweet()
        {
            string tweet = "";
            bool valid = false;
            System.Console.Write("  Write your tweet: ");
            while (!valid)
            {
                tweet = Console.ReadLine();
                if (tweet.Length > 140)
                {
                    System.Console.WriteLine("Tweet too long.");
                    System.Console.WriteLine("Write your tweet: ");
                }
                else
                {
                    valid = true;
                }
            }
            return tweet;
        }

        public string getUsername()
        {
            string username = "";
            bool valid = false;
            System.Console.Write("  Username: ");
            while (!valid)
            {
                try
                {
                    username = Console.ReadLine();
                    valid = true;
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("  You have to input a name.");
                    System.Console.Write("  Username: ");
                }
            }

            return username;
        }

        public int getNoOfTweets()
        {
            bool valid = false;
            int noOfTweets = 1;
            int limit = 100;

            System.Console.Write("  How many tweets do you need: ");
            while (!valid)
            {

                try
                {
                    noOfTweets = int.Parse(Console.ReadLine());
                    valid = true;
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("  You ought to input a number.");
                }
                if (noOfTweets > limit)
                {
                    System.Console.WriteLine($" You can't retrieve more than {limit} tweets.");
                    valid = false;
                    System.Console.Write("  How many tweets do you need: ");
                }
            }
            return noOfTweets;
        }
    }
}