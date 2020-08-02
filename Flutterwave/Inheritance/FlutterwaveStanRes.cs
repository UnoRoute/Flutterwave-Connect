namespace Flutterwave.Interfaces
{
    public class FlutterwaveStanRes
    {
        public string status { get; set; }
        public string massage { get; set; }
        public IDataFlutterwaveStanRes data { get; set; }
    }

    public class IDataFlutterwaveStanRes
    {
        public string link { get; set; }
    }
}