using HexagonalPattern.ConsoleApp;
using HexagonalPattern.ConsoleApp.BCore.CardProcessing;
using HexagonalPattern.ConsoleApp.CServer;

namespace ConsoleApp.UnitTests
{
    [TestClass]
    public class ServiceTests
    {
        private static readonly string _validFile;

        static ServiceTests()
        {
            _validFile = Program.GetFilePath(@"HexagonalPattern\ConsoleApp\CServer\Files\pokemon-50-card-library.csv");
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