namespace ShoyerNetBlazor.BL.Interfaces
{
    public interface IGoogleCloudServices
    {
        string GetSecret(string secretName);

        byte[] GetSecretFile(string secretName);
    }
}
