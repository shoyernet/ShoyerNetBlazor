namespace ShoyerNetBlazor.BL.Interfaces
{
    public interface IMicrosoftService
    {
        bool SendMail(string to, string subject, string body);
    }
}
