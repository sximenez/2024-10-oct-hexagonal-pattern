using HexagonalPattern.LoadBalancer.BCore.CallProcessing;

namespace HexagonalPattern.LoadBalancer.AUser
{
    class Caller
    {
        public ICall Service { get; set; }

        public Caller(ICall service)
        {
            Service = service;
        }

        internal List<int> InitiateCall(int n)
        {
            return Enumerable.Range(0, n).ToList();
        }
    }
}
