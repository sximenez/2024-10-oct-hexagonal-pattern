using ConsoleApp.AUser;
using ConsoleApp.BCore.CardProcessing;
using ConsoleApp.CServer;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IReply replier = new Replier(@"C:\Users\steven.jimenez\source\repos\2024-10-oct-hexagonal-pattern\ConsoleApp\CServer\pokemon-50-card-library.csv"); // Server-side; consumes a connection string.

            ICall service = new Service(replier); // Core; consumers a replier.

            var caller = new Caller(service); // User-side; consumes the core.
            string result = caller.Service.AskForCard();
            
            Console.WriteLine(result);
        }
    }
}
