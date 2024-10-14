using ConsoleApp.BCore.CardProcessing;

namespace ConsoleApp.AUser
{
    internal class Caller
    {
        public ICallCardData Service { get; set; }
        public Caller(ICallCardData service)
        {
            Service = service;
        }
    }
}
