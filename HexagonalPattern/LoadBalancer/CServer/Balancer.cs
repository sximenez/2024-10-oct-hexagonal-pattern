using HexagonalPattern.LoadBalancer.BCore.CallProcessing;

namespace HexagonalPattern.LoadBalancer.CServer
{
    class Balancer : IBalance
    {
        public int Load { get; internal set; }
        public int Capacity { get; set; }

        public Balancer(int capacity)
        {
            Load = 0;
            Capacity = capacity;
        }
        
        public int GetLoad()
        {
            return Load;
        }
        public void HandleCall()
        {
            Load++;
        }
    }
}
