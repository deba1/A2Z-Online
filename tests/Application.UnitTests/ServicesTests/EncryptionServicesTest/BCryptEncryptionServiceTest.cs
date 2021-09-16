using Application.Interfaces.EncyptionInterfaces;
using Application.Services.EncryptionServices;
using System;
using Xunit;

namespace Application.UnitTests.ServicesTests.EncryptionServicesTest
{
    public class BCryptEncryptionServiceTest
    {
        [Theory]
        [InlineData("$2a$11$8tWsFJCQyU9YQKFngxCwAOnzKHASC5q0UfuuvAGinmomdj5yhO0cK", "string", true)]
        [InlineData("$2a$11$8tWsFJCQyU9YQKFngxCuAOnzKHASC5q0UfuuvAGinmomdj5yhO0cK", "string", false)]
        public void ShouldVerifyHash(string hashedString, string plainText, bool expected)
        {
            // Arrange
            IEncryptionService encryptionService = new BCryptEncryptionService();

            // Act
            var actual = encryptionService.VerifyHash(hashedString, plainText);

            ///Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("testValue")]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldGenerateHash(string plainText)
        {
            // Arrange
            IEncryptionService encryptionService = new BCryptEncryptionService();

            // Act
            string actual;
            if (plainText != null)
            {
                actual = encryptionService.GenerateHash(plainText);
                Assert.IsType<string>(actual);
            }
            else
            {
                Assert.Throws<ArgumentNullException>(() => encryptionService.GenerateHash(plainText));
            } 
        }
    }
}
