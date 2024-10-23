namespace HexagonalPattern.ConsoleApp.BCore.CardProcessing
{
    // What has value for the user? Retriving cards.
    class Service : ICall
    {
        public IReply Replier { get; set; }

        public Service(IReply replier)
        {
            Replier = replier;
        }

        public bool ProcessCard(string input)
        {
            Replier.ConvertCardData();
            bool result = Replier.HandleResult(Replier.FindCard(input));

            if (!result)
            {
                RequestCard();
            }

            return true;
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
