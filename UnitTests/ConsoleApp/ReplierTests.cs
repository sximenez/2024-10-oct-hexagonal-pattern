using HexagonalPattern.ConsoleApp;
using HexagonalPattern.ConsoleApp.BCore.CardProcessing;
using HexagonalPattern.ConsoleApp.CServer;

namespace ConsoleApp.UnitTests
{
    [TestClass]
    public class ReplierTests
    {
        private static readonly string _validFile;
        private static readonly string _invalidFile;

        static ReplierTests()
        {
            _validFile = Program.GetFilePath(@"HexagonalPattern\ConsoleApp\CServer\Files\pokemon-50-card-library.csv");
            _invalidFile = Program.GetFilePath(@"HexagonalPattern\ConsoleApp\CServer\Files\test-empty-file.csv");
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Null_Or_Empty_FilePath_ArgumentNullException(string input)
        {
            new Replier(input);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ConvertCardData_Invalid_FilePath_FileNotFoundException()
        {
            IReply _replier = new Replier("test");
            _replier.ConvertCardData();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertCardData_Null_Headers_ArgumentNullException()
        {
            IReply _replier = new Replier(_invalidFile);
            _replier.ConvertCardData();
        }

        [TestMethod]
        [DataRow("test", "Card not found.")]
        [DataRow("Helloworld", "\r\nPokémon: HELLOWORLD\r\n\r\nhello: world")]
        public void FindCard_Key_Values(string input, string output)
        {
            IReply _replier = new Replier(_validFile)
            {
                Cards = new Dictionary<string, Dictionary<string, string>>
                {
                    { "helloworld", new Dictionary<string, string> { { "hello", "world" } } }
                }
            };

            string result = _replier.FindCard(input);

            Assert.AreEqual(result, output);
        }

        [TestMethod]
        [DataRow("Card not found.", false)]
        [DataRow("Hello world", true)]
        public void HandleResult_Input_Bool(string input, bool output)
        {
            IReply _replier = new Replier(_validFile);

            bool result = _replier.HandleResult(input);

            Assert.AreEqual(result, output);
        }
    }
}