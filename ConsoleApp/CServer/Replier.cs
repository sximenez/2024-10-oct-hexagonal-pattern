using ConsoleApp.BCore.CardProcessing;
using Microsoft.VisualBasic.FileIO;
using System.Text;

namespace ConsoleApp.CServer
{
    class Replier : IReply
    {
        private string FilePath { get; set; }
        public Dictionary<string, Dictionary<string, string>> Cards { get; internal set; }

        internal Replier(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");
            }
            else
            {
                FilePath = filePath;
            }

            Cards = new Dictionary<string, Dictionary<string, string>>();
        }

        public void ConvertCardData()
        {
            try
            {
                ParseFile(FilePath);
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Parsing error occurred.", e);
            }
        }

        internal void ParseFile(string filePath)
        {
            using (TextFieldParser parser = new TextFieldParser(FilePath))
            {
                parser.SetDelimiters([","]);

                List<string> headers = ParseHeaders(parser);

                while (!parser.EndOfData)
                {
                    string[]? fields = parser.ReadFields();

                    if (fields is null)
                    {
                        continue;
                    }

                    var values = ParseFields(headers, fields);

                    Cards.TryAdd(fields[0].ToLower(), values);
                }
            }
        }

        private List<string> ParseHeaders(TextFieldParser parser)
        {
            List<string>? headers = parser.ReadFields()?.ToList();

            if (headers is null)
            {
                throw new ArgumentNullException("Headers cannot be null.");
            }

            return headers;
        }

        private Dictionary<string, string> ParseFields(List<string> headers, string[] fields)
        {
            Dictionary<string, string>? values = new Dictionary<string, string>();

            for (int i = 1; i < fields.Length; i++)
            {
                values.TryAdd(headers[i], fields[i]);
            }

            return values;
        }

        public string FindCard(string input)
        {
            if (Cards.ContainsKey(input.ToLower()))
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine();
                sb.Append($"Pokémon: {input.ToUpper()}");
                sb.AppendLine();

                foreach (var kvp in Cards[input.ToLower()])
                {
                    sb.AppendLine();
                    sb.Append($"{kvp.Key}: {kvp.Value}");
                }

                return sb.ToString();
            }
            else
            {
                return "Card not found.";
            }
        }

        public bool HandleResult(string input)
        {
            if (input == "Card not found.")
            {
                Console.WriteLine(input);
                Console.WriteLine();
                return false;
            }
            else
            {
                Console.WriteLine(input);
                return true;
            }
        }
    }
}
