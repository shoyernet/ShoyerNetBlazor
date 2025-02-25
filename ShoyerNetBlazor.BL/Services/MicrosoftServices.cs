using ShoyerNetBlazor.BL.Models;

namespace ShoyerNetBlazor.BL.Services
{
    public class MicrosoftServices : IMicrosoftService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly MicrosoftAuthentication _microsoftAuthentication;

        public MicrosoftServices(IServiceProvider serviceProvider)
        {
            serviceProvider = serviceProvider;
            _microsoftAuthentication = new MicrosoftAuthentication(serviceProvider);
        }

        public bool SendMail(string to, string subject, string body)
        {
            return true;
        }
    }
}
