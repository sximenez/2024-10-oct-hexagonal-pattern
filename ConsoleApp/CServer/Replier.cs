using ConsoleApp.BCore.CardProcessing;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleApp.CServer
{
    internal class Replier : IReplyCardData
    {
        public string FilePath { get; set; }
        public Replier(string filePath)
        {
            FilePath = filePath;
        }

        public void FindCard(string input)
        {
            using (TextFieldParser parser = new TextFieldParser(FilePath))
            {
                parser.SetDelimiters(";");

                while(!parser.EndOfData)
                {

                }
            }
        }
    }
}
