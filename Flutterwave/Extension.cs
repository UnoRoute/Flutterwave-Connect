using Microsoft.Extensions.DependencyInjection;

namespace Flutterwave
{
    public static class Extension
    {
        public static IServiceCollection AddFlutterwaveConnect(
            this IServiceCollection services,
            string SecKey)
        {
            services.AddSingleton(new FLW(SecKey));
            return services;
        }
    }
}