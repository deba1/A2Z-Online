using Application.Interfaces.EncyptionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
