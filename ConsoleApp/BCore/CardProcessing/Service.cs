using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp.BCore.CardProcessing
{
    // What has value for the user? Retriving cards.
    internal class Service : ICallCardData
    {
        public IReplyCardData Replier { get; set; }

        public Service(IReplyCardData replier)
        {
            Replier = replier;
        }

        public void AskForCard()
        {
            string? input;
            do
            {
                Console.Write("Please enter a Pokémon: ");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));

            Replier.FindCard(input);
        }
    }
}
