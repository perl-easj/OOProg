namespace GenericCatalog
{
    public class Computer
    {
        public Computer(string serialNo, string networkName)
        {
            SerialNo = serialNo;
            NetworkName = networkName;
        }

        public string SerialNo { get; set; }
        public string NetworkName { get; set; }

        public override string ToString()
        {
            return $"{SerialNo}, called {NetworkName} on network";
        }
    }
}