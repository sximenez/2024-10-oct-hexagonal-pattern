namespace HexagonalPattern.LoadBalancer.BCore.CallProcessing
{
    interface ICall
    {
        public List<IBalance> Balancers { get; set; }
        public void SendCall(List<int> calls);
    }
}
