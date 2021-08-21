using Application.Interfaces.EncyptionInterfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services.EncryptionServices
{
    public class Sha256EncryptionService : IEncryptionService
    {
        public string GenerateHash(string plainText)
        {
            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        public bool VerifyHash(string hashedString, string plainText)
        {
            return hashedString.Equals(GenerateHash(plainText));
        }
    }
}
