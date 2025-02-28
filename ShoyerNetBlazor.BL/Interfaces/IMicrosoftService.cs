namespace ShoyerNetBlazor.BL.Interfaces
{
    public interface IMicrosoftService
    {
        Task<bool> SendMail(string subject, string body, List<string> to);
    }
}
