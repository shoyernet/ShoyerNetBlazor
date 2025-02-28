using Microsoft.Graph.Models;

namespace ShoyerNetBlazor.BL.Models.Microsoft
{
    internal class MailMessage
    {
        public string Subject { get; private set; }

        public ItemBody Body { get; private set; }

        public List<Recipient> Recipients { get; private set; } = [];


        public MailMessage(string subject, string body, List<string> recipients)
        {
            Subject = subject;
            Body = new ItemBody
            {
                ContentType = BodyType.Html,
                Content = body
            };
            foreach (var recipient in recipients)
            {
                Recipients.Add(new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = recipient
                    }
                });
            }
        }

        public Message ToMicrosoftMessage()
        {
            return new Message
            {
                Subject = Subject,
                Body = Body,
                ToRecipients = Recipients
            };
        }
    }
}
