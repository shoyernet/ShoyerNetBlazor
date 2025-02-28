using System.Security.Cryptography.X509Certificates;
using Azure.Identity;

namespace ShoyerNetBlazor.BL.Models.Microsoft
{
    public class MicrosoftAuthentication
    {
        private IServiceProvider _serviceProvider;

        private readonly string _tenantId;

        private readonly string _clientId;

        private readonly X509Certificate2 _authenticationCertificate;

        public ClientCertificateCredential ClientCertificateCredential { get; private set; }


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


            _tenantId = googleCloudServices.GetSecret("TenantId");
            _clientId = googleCloudServices.GetSecret("ClientId");

            var pfxPassword = googleCloudServices.GetSecret("MicrosoftPassword");

            byte[] certData = googleCloudServices.GetSecretFile("WE4U-PFX");

            // Load the certificate with optional storage flags.
            _authenticationCertificate = new X509Certificate2(
               certData,
               pfxPassword,
               X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);


            ClientCertificateCredential = new ClientCertificateCredential(_tenantId, _clientId, _authenticationCertificate);

        }
    }
}
