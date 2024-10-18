using ConsoleApp.AUser;
using ConsoleApp.BCore.CardProcessing;
using ConsoleApp.CServer;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Server-side; consumes a connection string.
            IReply replier = new Replier(@"C:\Users\steven.jimenez\source\repos\2024-10-oct-hexagonal-pattern\ConsoleApp\CServer\pokemon-50-card-library.csv");

            // Core; consumers a replier.
            ICall service = new Service(replier);

            // User-side; consumes the service or core.
            var caller = new Caller(service);
            caller.Service.RequestCard();
        }
    }
}
