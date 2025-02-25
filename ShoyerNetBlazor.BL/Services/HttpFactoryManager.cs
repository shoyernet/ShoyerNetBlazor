namespace ShoyerNetBlazor.BL.Services
{
    public static class HttpFactoryManager
    {
        public static void AddHttpFactory(this IServiceCollection services, string name, string baseAddress)
        {
            services.AddHttpClient("Microsoft", client =>
            {
                client.BaseAddress = new Uri(baseAddress);
            });
        }
    }
}
