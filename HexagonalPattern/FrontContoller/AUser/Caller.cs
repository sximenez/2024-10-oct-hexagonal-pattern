using HexagonalPattern.FrontController.BCore.CardProcessing;

namespace HexagonalPattern.FrontController.AUser
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
