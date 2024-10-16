using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp.BCore.CardProcessing
{
    // What has value for the user? Retriving cards.
    internal class Service : ICall
    {
        public IReply Replier { get; set; }

        public Service(IReply replier)
        {
            Replier = replier;
        }

        public string ProcessCard(string input)
        {
            Replier.ConvertCardCsvIntoHashSet();
            return Replier.FindCard(input);
        }

        public string AskForCard()
        {
            string? input;
            do
            {
                Console.Write("Please enter a Pokémon: ");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));

            return ProcessCard(input);
        }
    }
}
