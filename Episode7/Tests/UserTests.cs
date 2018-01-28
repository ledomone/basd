using Episode7.Models;
using NUnit.Framework;

namespace Episode7.Tests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void  changing_email_should_succeed()
        {
            // Arrange
            var expectedEmail = "user2@email.com";
            var user = new User("user1@email.com", "secret");

            // Act
            user.SetEmail(expectedEmail);

            // Assert
            Assert.AreEqual(expectedEmail, user.Email);
        }
    }
}