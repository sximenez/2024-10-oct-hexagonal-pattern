using HexagonalPattern.LoadBalancer.CServer;

namespace HexagonalPattern.LoadBalancer.BCore.CallProcessing
{
    class Service : ICall
    {
        public List<IBalance> Balancers { get; set; }
        public Service(List<IBalance> balancers)
        {
            Balancers = balancers;
        }

        public void SendCall(List<int> calls)
        {
            foreach (int call in calls)
            {
                //int minLoad = int.MaxValue;
                IBalance? selectedBalancer = null;

                foreach (IBalance balancer in Balancers)
                {
                    if (balancer.Load < balancer.Capacity)
                    {
                        selectedBalancer = balancer;
                    }
                }
                    
                Console.WriteLine($"{selectedBalancer} is full.");

                if (selectedBalancer is not null)
                {
                    selectedBalancer.HandleCall();
                }
            }
        }
    }
}
