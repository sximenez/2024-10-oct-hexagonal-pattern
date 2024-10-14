using ConsoleApp.AUser;
using ConsoleApp.BCore.CardProcessing;
using ConsoleApp.CServer;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IReplyCardData replier = new Replier(@"CServer/pokemon-50-card-library.csv"); // Server-side; consumes a connection string.

            ICallCardData service = new Service(replier); // Core; consumers a replier.

            var caller = new Caller(service); // User-side; consumes the core.
            caller.Service.AskForCard();
        }
    }
}
