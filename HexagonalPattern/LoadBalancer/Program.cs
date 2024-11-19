using HexagonalPattern.LoadBalancer.AUser;
using HexagonalPattern.LoadBalancer.BCore.CallProcessing;
using HexagonalPattern.LoadBalancer.CServer;

namespace HexagonalPattern.LoadBalancer
{
    class Program
    {
        public static void LoadBalancer()
        {
            int capacity = 10;
            List<IBalance> balancers = Enumerable.Range(0, 5)
                .Select(e => (IBalance) new Balancer(capacity))
                .ToList();

            ICall service = new Service(balancers);

            var caller = new Caller(service);
            caller.Service.SendCall(caller.InitiateCall(50));
        }
    }
}
