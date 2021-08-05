namespace Application.Interfaces
{
    public interface IEncryptionService
    {
        string GenerateHash(string plainText);
        bool VerifyHash(string hashedString, string plainText);
    }
}
