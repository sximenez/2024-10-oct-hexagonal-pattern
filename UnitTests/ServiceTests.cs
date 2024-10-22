using ConsoleApp.BCore.CardProcessing;
using ConsoleApp.CServer;

namespace UnitTests
{
    [TestClass]
    public class ServiceTests
    {
        private static readonly string _validFile;

        static ServiceTests()
        {
            _validFile = ConsoleApp.Program.GetFilePath(@"ConsoleApp\CServer\Files\pokemon-50-card-library.csv");
        }

        [TestMethod]
        public void ProcessCard_ValidInput_True()
        {
            IReply _replier = new Replier(_validFile)
            {
                Cards = new Dictionary<string, Dictionary<string, string>>
                {
                    { "helloworld", new Dictionary<string, string> { { "hello", "world" } } }
                }
            };

            ICall _service = new Service(_replier);

            bool result = _service.ProcessCard("HelloWorld");

            Assert.IsTrue(result);
        }
    }
}