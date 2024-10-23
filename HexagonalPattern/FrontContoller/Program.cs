using HexagonalPattern.FrontController.AUser;
using HexagonalPattern.FrontController.BCore.CardProcessing;
using HexagonalPattern.FrontController.CServer;

namespace HexagonalPattern.FrontController
{
    class Program
    {
        public static void FrontController()
        {
            IReply replier = new Replier(GetFilePath(@"HexagonalPattern\ConsoleApp\CServer\Files\pokemon-50-card-library.csv")); // Server-side.

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
