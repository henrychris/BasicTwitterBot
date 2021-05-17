using System;
using System.Threading.Tasks;
using Classes;
using Tweetinvi;

namespace ConsoleApp.Classes
{
    public class Menu
    {
        public async Task openMenu()
        {
            var userClient = new TwitterClient(Credentials.consumerKey, Credentials.consumerSecret,
            Credentials.accessToken, Credentials.accessSecret);
            var user = await userClient.Users.GetAuthenticatedUserAsync();
            Console.WriteLine($"Welcome, {user}");
            Console.ReadKey();
        }

        public async Task displayMenu()
        {
            string input = "";
            System.Console.WriteLine("What whould you like to do today?");
            while (input.ToUpper() != "Q")
            {
                System.Console.WriteLine("  1. Tweet\n  2. Follow a user\n  3. View a users timeline\n  Use Q to Quit");
                System.Console.WriteLine("Make a selection using 1-3: ");
                input = (string) Console.ReadLine();

            }

        }
    }
}