using Application.Interfaces.EncyptionInterfaces;

namespace Application.Services.EncryptionServices
{
    class BCryptEncryptionService : IEncryptionService
    {
        public string GenerateHash(string plainText)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainText);
        }

        public bool VerifyHash(string hashedString, string plainText)
        {
            return BCrypt.Net.BCrypt.Verify(plainText, hashedString);
        }
    }
}
