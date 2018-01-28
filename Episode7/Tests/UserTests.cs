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
            var user = new User("user1@email.com", "secret");

            // Act
            user.SetEmail("user2@email.com");

            // Assert
            Assert.AreEqual("user2@email.com", user.Email);
        }
    }
}