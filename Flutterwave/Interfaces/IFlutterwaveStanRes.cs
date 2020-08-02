namespace Flutterwave.Interfaces
{
    public class IFlutterwaveStanRes
    {
        public string status { get; set; }
        public string massage { get; set; }
        public IDataFlutterwaveStanRes DataFlutterwaveStanRes { get; set; }
    }

    public interface IDataFlutterwaveStanRes
    {
        public string link { get; set; }
    }
}