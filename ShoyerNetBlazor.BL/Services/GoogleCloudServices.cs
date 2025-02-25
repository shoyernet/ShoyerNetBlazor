namespace ShoyerNetBlazor.BL.Services
{
    public class GoogleCloudServices : IGoogleCloudServices
    {
        public string GetSecret(string secretName)
        {
            // The client picks up credentials from GOOGLE_APPLICATION_CREDENTIALS
            SecretManagerServiceClient client = SecretManagerServiceClient.Create();

            // Build the resource name for the secret version
            SecretVersionName secretVersionName = new SecretVersionName("we4u-blazor", "TenantId", "latest");

            // Access the secret version.
            AccessSecretVersionResponse result = client.AccessSecretVersion(secretVersionName);

            // Extract the secret payload as a string.
            string secretPayload = result.Payload.Data.ToStringUtf8();

            return secretPayload;
        }
    }
}
