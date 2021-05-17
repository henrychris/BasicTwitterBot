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
            /* This method lets you publish tweets.
            line 18/19 authenticates the user.
            line 20 publishes the tweet.
            */
            string text = getTweet();

            var userClient = new TwitterClient(Credentials.consumerKey, Credentials.consumerSecret,
            Credentials.accessToken, Credentials.accessSecret);
            var tweet = await userClient.Tweets.PublishTweetAsync(text);
            System.Console.WriteLine($"  You tweeted: '{tweet}'\n");
        }

        public async Task Follow()
        {
            /*
                this method follows a specified user.
                line 30 uses another method to retrieve the username.
            */
            string username = getUsername();

            var userClient = new TwitterClient(Credentials.consumerKey, Credentials.consumerSecret,
            Credentials.accessToken, Credentials.accessSecret);
            await userClient.Users.FollowUserAsync(username);
            System.Console.WriteLine($"  Followed {username}.\n");
        }

        public async Task viewTimeline()
        {
            /* 
                This function retrieves a certain number of tweets from the specified user timelime.
            */
            Menu menu = new Menu(); // create menu object
            string username = getUsername();
            int noOfTweets = getNoOfTweets();

            var userClient = new TwitterClient(Credentials.consumerKey, Credentials.consumerSecret,
            Credentials.accessToken, Credentials.accessSecret);

            var timelineTweets = await userClient.Timelines.GetUserTimelineAsync(username);
            // GetUserTimelineAsync() stores tweets on the timeline in an array.
            int count = 1;

            try
            {
                while (count <= noOfTweets)
                {
                    System.Console.WriteLine($"   {count}. {timelineTweets[count]}");
                    count++;
                    // this prints each element of the timeline array (which is a tweet)
                }
            }
            catch (TimeoutException e) // sometimes the request times out.
            {
                Console.WriteLine(e.ToString());
            }
            await menu.displayMenu();
            // there was a bug that caused getUsername() to run infinitely.
            // The line above opens the menu and stops that.
        }
        public string getTweet()
        {
            string tweet = "";
            bool valid = false;
            System.Console.Write("  Write your tweet: ");
            while (!valid)
            {
                tweet = Console.ReadLine();
                if (tweet.Length > 140) // keeps tweets within twitter limits
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
            /* 
                this makes it cleaner to get usernames. Improves readability.
            */
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
            /* 
                this also improves readability in code. 
                gets the number of tweets to be retrieved from the timeline.
             */
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