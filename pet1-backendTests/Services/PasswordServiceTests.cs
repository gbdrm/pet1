using Microsoft.VisualStudio.TestTools.UnitTesting;
using pet1_backend.Data.Models;
using pet1_backend.Dtos.Account.Client;
using pet1_backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet1_backend.Services.Tests
{
    [TestClass()]
    public class PasswordServiceTests
    {
        [TestMethod()]
        public void VerifyPasswordHashTest()
        {
            PasswordService passwordService = new PasswordService();
            var user = new User
            {
                Username = "Username",
                Email = "test@test.com",
                PasswordHash = "",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            HashedDataDto hashedStr = passwordService.HashPassword("Password", null);
            user.PasswordHash = hashedStr.Value;
            user.Salt = hashedStr.Salt;

            var wrongPasswordVerification = passwordService.VerifyPasswordHash("test", user);
            Assert.IsFalse(wrongPasswordVerification);

            var correctPasswordVerification = passwordService.VerifyPasswordHash("Password", user);
            Assert.IsTrue(correctPasswordVerification);
        }
    }
}