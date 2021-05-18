using ConsoleApp.Classes;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {      
            Menu menu = new Menu(); 
            await menu.openMenu();
        }   
    }
}
