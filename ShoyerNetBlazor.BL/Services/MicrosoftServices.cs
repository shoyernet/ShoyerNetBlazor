using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Users.Item.SendMail;
using ShoyerNetBlazor.BL.Models.Microsoft;

namespace ShoyerNetBlazor.BL.Services
{
    public class MicrosoftServices : IMicrosoftService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly MicrosoftAuthentication _microsoftAuthentication;
        private readonly GraphServiceClient _graphServiceClient;

        public MicrosoftServices(IServiceProvider serviceProvider)
        {
            serviceProvider = serviceProvider;
            _microsoftAuthentication = new MicrosoftAuthentication(serviceProvider);
            _graphServiceClient = new GraphServiceClient(_microsoftAuthentication.ClientCertificateCredential);
        }

        public async Task<bool> SendMail(string subject, string body, List<string> to)
        {
            var message = new MailMessage(subject, body, to);

            await _graphServiceClient.Users["roy@shoyer.net"]
             .SendMail.PostAsync(new SendMailPostRequestBody
             {
                 Message = message.ToMicrosoftMessage(),
                 SaveToSentItems = true
             });

            return true;
        }
    }
}
