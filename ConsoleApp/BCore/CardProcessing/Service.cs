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

        public void ProcessCard(string input)
        {
            Replier.ConvertCardData();
            bool result = Replier.HandleResult(Replier.FindCard(input));

            if (!result)
            {
                RequestCard();
            }
        }

        public void RequestCard()
        {
            string? input;
            do
            {
                Console.Write("Please enter a Pokémon: ");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));

            ProcessCard(input);
        }
    }
}
