using ConsoleApp.BCore.CardProcessing;

namespace ConsoleApp.AUser
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
