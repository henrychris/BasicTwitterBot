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
            Console.WriteLine($"Welcome, {user}.");
            Console.WriteLine();
            await displayMenu();
        }

        public async Task displayMenu()
        {
            Actions act = new Actions();
            string input = "";


            while (input.ToUpper() != "Q")
            {
                System.Console.WriteLine("  MENU    ");
                System.Console.WriteLine("  1. Tweet\n  2. Follow a user\n  3. View a users timeline\n  Use Q or another key to display menu");
                System.Console.Write("  Make a selection using 1-3: ");
                input = (string)Console.ReadLine();
                System.Console.WriteLine();

                if (input == "1")
                {
                    await act.Tweet();
                }
                if (input == "2")
                {

                }
                if (input == "3")
                {

                }

            }

        }
    }
}