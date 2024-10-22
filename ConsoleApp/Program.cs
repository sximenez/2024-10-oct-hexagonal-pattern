using ConsoleApp.AUser;
using ConsoleApp.BCore.CardProcessing;
using ConsoleApp.CServer;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IReply replier = new Replier(GetFilePath(@"ConsoleApp\CServer\Files\pokemon-50-card-library.csv")); // Server-side.

            ICall service = new Service(replier); // Core.

            var caller = new Caller(service); // User-side.
            caller.Service.RequestCard();
        }

        public static string GetFilePath(string input)
        {
            string projectRootPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\.."));
            return Path.Combine(projectRootPath, input);
        }
    }
}
