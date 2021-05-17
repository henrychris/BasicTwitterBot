using System;
using System.Threading.Tasks;
using Classes;
using Tweetinvi;

namespace ConsoleApp.Classes
{
    public class Actions
    {
        public async Task Tweet(string text)
        {
            // This function lets you publish tweets

            text = getTweet();
            
            var userClient = new TwitterClient(Credentials.consumerKey, Credentials.consumerSecret,
            Credentials.accessToken, Credentials.accessSecret);
            var tweet = await userClient.Tweets.PublishTweetAsync(text);
            System.Console.WriteLine("You published the tweet : " + tweet);
        }

        public async Task Follow(string username)
        {
            // This lets you follow specified users

            var userClient = new TwitterClient(Credentials.consumerKey, Credentials.consumerSecret,
            Credentials.accessToken, Credentials.accessSecret);
            await userClient.Users.FollowUserAsync(username);
            System.Console.WriteLine($"Followed {username}");
        }

        public async Task viewTimeline(string username, int noOfTweets)
        {
            // This function retrieves a certain number of tweets from the specified user timelime.

            var userClient = new TwitterClient(Credentials.consumerKey, Credentials.consumerSecret,
            Credentials.accessToken, Credentials.accessSecret);
            var timelineTweets = await userClient.Timelines.GetUserTimelineAsync(username);
            int count = 1;

            while (count <= noOfTweets)
            {
                System.Console.WriteLine($"{count}. {timelineTweets[count]}\n");
                count++;
            }
        }
        public string getTweet()
        {
            string tweet = "";
            bool valid = false;
            System.Console.WriteLine("Write your tweet: ");
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
    }
}