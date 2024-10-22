namespace ConsoleApp.BCore.CardProcessing
{
    // What does the core need satisfy the user ? Find card info and return the results.
    interface IReply
    {
        Dictionary<string, Dictionary<string, string>> Cards { get; }

        public void ConvertCardData();

        public string FindCard(string input);

        public bool HandleResult(string input);
    }
}
