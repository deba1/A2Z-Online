using Application.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services.EncryptionServices
{
    public class Sha256EncryptionService : ISha256EncryptionService
    {
        public string GenerateHash(string givenString)
        {
            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(givenString));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        public bool VerifyHash(string hashedString, string givenString)
        {
            return hashedString.Equals(GenerateHash(givenString));
        }
    }
}
