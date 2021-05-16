using System.Threading.Tasks;
using Classes;
using Tweetinvi;

namespace ConsoleApp.Classes
{
    public class Actions
    {
        public async Task Tweet(string text)
        {
            var userClient = new TwitterClient(Credentials.consumerKey, Credentials.consumerSecret, Credentials.accessToken, Credentials.accessSecret);
            var tweet = await userClient.Tweets.PublishTweetAsync(text);
            System.Console.WriteLine("You published the tweet : " + tweet);
        }

        public async Task Follow(string username)
        {
            var userClient = new TwitterClient(Credentials.consumerKey, Credentials.consumerSecret, Credentials.accessToken, Credentials.accessSecret);
            await userClient.Users.FollowUserAsync(username);
            System.Console.WriteLine("Follow");
        }

        public async Task viewTimeline(string username, int noOfTweets)
        // this function retrieves a certain number of tweets from the specified user timelime.
        {
            var userClient = new TwitterClient(Credentials.consumerKey, Credentials.consumerSecret, Credentials.accessToken, Credentials.accessSecret);
            var timelineTweets = await userClient.Timelines.GetUserTimelineAsync(username);

            foreach (var tweet in timelineTweets)
            {
                System.Console.WriteLine(tweet);
            }
        }
    }
}