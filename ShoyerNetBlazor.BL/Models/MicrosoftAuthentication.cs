using System.Security.Cryptography.X509Certificates;

namespace ShoyerNetBlazor.BL.Models
{
    public class MicrosoftAuthentication
    {
        private IServiceProvider _serviceProvider;

        public string TenantId { get; private set; }

        public string ClientId { get; private set; }

        public X509Certificate2 AuthenticationCertificate { get; private set; }

        /// <summary>
        ///     Microsoft Graph is using a certificate for authentication.
        ///     The certificate is stored in Google Cloud Secret Manager.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public MicrosoftAuthentication(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            // Create a scope to resolve the scoped service.
            using var scope = _serviceProvider.CreateScope();
            var googleCloudServices = scope.ServiceProvider.GetRequiredService<IGoogleCloudServices>();


            TenantId = googleCloudServices.GetSecret("TenantId");
            ClientId = googleCloudServices.GetSecret("ClientId");

            var pfxPassword = googleCloudServices.GetSecret("MicrosoftPassword");

            byte[] certData = googleCloudServices.GetSecretFile("WE4U-PFX");

            // Load the certificate with optional storage flags.
            AuthenticationCertificate = new X509Certificate2(
               certData,
               pfxPassword,
               X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet
           );
        }
    }
}
