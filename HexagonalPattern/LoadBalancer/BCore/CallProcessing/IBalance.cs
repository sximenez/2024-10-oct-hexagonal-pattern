using HexagonalPattern.ConsoleApp.CServer;

namespace HexagonalPattern.LoadBalancer.BCore.CallProcessing
{
    interface IBalance
    {
        public int Load { get; }
        public int Capacity { get; set; }
        public int GetLoad();
        public void HandleCall();
    }
}
