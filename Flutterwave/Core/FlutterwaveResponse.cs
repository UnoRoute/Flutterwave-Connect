namespace Flutterwave.Core
{
   
       public class FlutterwaveResponse<T>
          {
              public string status { get; set; }
              public string massage { get; set; }
              public T data { get; set; }
          }  
    
   
}