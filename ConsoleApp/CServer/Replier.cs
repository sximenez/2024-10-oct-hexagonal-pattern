using ConsoleApp.BCore.CardProcessing;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleApp.CServer
{
    internal class Replier : IReplyCardData
    {
        public string FilePath { get; set; }
        public Dictionary<string, Dictionary<string, string>> Cards { get; set; }
        public Replier(string filePath)
        {
            FilePath = filePath;
            Cards = new Dictionary<string, Dictionary<string, string>>();
        }

        public void ConvertCardCsvIntoHashSet()
        {
            using (TextFieldParser parser = new TextFieldParser(FilePath))
            {
                string[] delimiters = [","];
                parser.SetDelimiters(delimiters);

                bool hasHeaders = true;
                IEnumerable<string>? headers = null;

                while (!parser.EndOfData)
                {
                    string[]? fields = parser.ReadFields();

                    if (fields is null)
                    {
                        return;
                    }

                    if (hasHeaders)
                    {
                        headers = fields;
                        hasHeaders = false;
                        continue;
                    }

                    Cards.TryAdd(fields[0], headers.Select(e => e));
                }
            }
        }

        public void FindCard(string input)
        {
            
        }
    }
}
