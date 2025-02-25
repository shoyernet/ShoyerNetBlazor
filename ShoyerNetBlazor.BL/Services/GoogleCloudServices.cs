using Google.Cloud.SecretManager.V1;

namespace ShoyerNetBlazor.BL.Services
{
    public class GoogleCloudServices : IGoogleCloudServices
    {
        private readonly SecretManagerServiceClient _client;

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

            // The client picks up credentials from GOOGLE_APPLICATION_CREDENTIALS
            _client = SecretManagerServiceClient.Create();

        }

        public string GetSecret(string secretName)
        {  
            // Build the resource name for the secret version
            SecretVersionName secretVersionName = new SecretVersionName("we4u-blazor", secretName, "latest");

            // Access the secret version.
            AccessSecretVersionResponse result = _client.AccessSecretVersion(secretVersionName);

            // Extract the secret payload as a string.
            string secretPayload = result.Payload.Data.ToStringUtf8();

            return secretPayload;
        }

        public byte[] GetSecretFile(string secretName)
        {
            // Build the resource name of the secret version.
            SecretVersionName secretVersionName = new SecretVersionName("we4u-blazor", secretName, "latest");

            // Access the secret version.
            AccessSecretVersionResponse result = _client.AccessSecretVersion(secretVersionName);

            // Get the secret payload as a byte array.
            byte[] secretData = result.Payload.Data.ToByteArray();


            return secretData;
        }
    }
}
