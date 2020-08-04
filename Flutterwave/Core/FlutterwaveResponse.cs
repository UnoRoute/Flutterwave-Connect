namespace Flutterwave.Core
{
    public class FlutterwaveResponse<T>
    {
        public string status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}