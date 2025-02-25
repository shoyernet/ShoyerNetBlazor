namespace ShoyerNetBlazor.BL.HostApplicationExtensions
{
    public static class We4uGoogleServices
    {
        public static IHostApplicationBuilder AddWE4UGoogleServices(this IHostApplicationBuilder builder, string jsonPath)
        {
            if(string.IsNullOrEmpty(jsonPath))
            {
                throw new ArgumentNullException(nameof(jsonPath));
            }

            // Register the service using a factory method to pass in the custom parameter.
            builder.Services.AddScoped<IGoogleCloudServices>(sp => new GoogleCloudServices(jsonPath));
            
            return builder;
        }
    }
}
