namespace ShoyerNetBlazor.BL.Services
{
    public class GoogleCloudServices : IGoogleCloudServices
    {
        public GoogleCloudServices(string apiJsonPath)
        {
            if(string.IsNullOrEmpty(apiJsonPath))
            {
                throw new ArgumentNullException(nameof(apiJsonPath));
            }

           if(File.Exists(apiJsonPath))
            {
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", apiJsonPath);
            }
            else
            {
                throw new FileNotFoundException("API Json file not found", apiJsonPath);
            }
        }

        public string GetSecret(string secretName)
        {
            // The client picks up credentials from GOOGLE_APPLICATION_CREDENTIALS
            SecretManagerServiceClient client = SecretManagerServiceClient.Create();

            // Build the resource name for the secret version
            SecretVersionName secretVersionName = new SecretVersionName("we4u-blazor", secretName, "latest");

            // Access the secret version.
            AccessSecretVersionResponse result = client.AccessSecretVersion(secretVersionName);

            // Extract the secret payload as a string.
            string secretPayload = result.Payload.Data.ToStringUtf8();

            return secretPayload;
        }
    }
}
