namespace Flutterwave.Core
{
 
        internal  class FlutterwaveCardResponse    {
               public string first_6digits { get; set; } 
               public string last_4digits { get; set; } 
               public string issuer { get; set; } 
               public string country { get; set; } 
               public string type { get; set; } 
               public string token { get; set; } 
               public string expiry { get; set; } 
           } 
    
   
}