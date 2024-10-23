using HexagonalPattern.ConsoleApp.BCore.CardProcessing;

namespace HexagonalPattern.ConsoleApp.AUser
{
    class Caller
    {
        public ICall Service { get; set; }
        
        public Caller(ICall service)
        {
            Service = service;
        }
    }
}
