using ConsoleApp.BCore.CardProcessing;
using Microsoft.VisualBasic.FileIO;
using System.Text;

namespace ConsoleApp.CServer
{
    internal class Replier : IReply
    {
        public string FilePath { get; set; }
        public Dictionary<string, Dictionary<string, string>> Cards { get; set; }

        public Replier(string filePath)
        {
            FilePath = filePath;
            Cards = new Dictionary<string, Dictionary<string, string>>();
        }

        public void ConvertCardData()
        {
            using (TextFieldParser parser = new TextFieldParser(FilePath))
            {
                parser.SetDelimiters([","]);

                bool hasHeaders = true;
                List<string> headers = new List<string>();

                while (!parser.EndOfData)
                {
                    try
                    {
                        string[]? fields = parser.ReadFields();

                        if (fields is null)
                        {
                            throw new ArgumentNullException("The file path provided points to an empty database.");
                        }

                        if (hasHeaders)
                        {
                            headers = fields.ToList();
                            hasHeaders = false;
                            continue;
                        }

                        Dictionary<string, string>? values = new Dictionary<string, string>();
                        for (int i = 1; i < fields.Length; i++)
                        {
                            values.TryAdd(headers[i], fields[i]);
                        }

                        Cards.TryAdd(fields[0].ToLower(), values);
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
            }
        }

        public string FindCard(string input)
        {
            if (Cards.ContainsKey(input.ToLower()))
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine();
                sb.Append($"Pokémon: {input.Substring(0, 1).ToUpper()}{input.Substring(1)}");
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
