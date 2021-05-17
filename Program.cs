using Classes;
using ConsoleApp.Classes;
using System;
using System.Threading.Tasks;
using Tweetinvi;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Actions act = new Actions();      
            Menu menu = new Menu(); 
            await menu.displayMenu();
        }   
    }
}
