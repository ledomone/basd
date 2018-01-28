using Episode7.Models;
using Moq;
using NUnit.Framework;

namespace Episode7.Tests
{
    public class OrderProcessorTests
    {
        public User User;
        public Order Order;
        public Mock<IDatabase> DatabaseMock;
        public Mock<IEmailSender> EmailSenderMock;
        // SUT - System Under Test
        public IOrderProcessor OrderProcessor;

        [SetUp]
        public void Setup()
        {
            User = new User("user1@email.com", "secret");
            Order = new Order(1, 10);
            DatabaseMock = new Mock<IDatabase>();
            EmailSenderMock = new Mock<IEmailSender>();
            DatabaseMock.Setup(x => x.GetUser(It.IsAny<string>()))
                        .Returns(User);
            DatabaseMock.Setup(x => x.GetOrder(It.IsAny<int>()))
                        .Returns(Order);
            OrderProcessor = new OrderProcessor(DatabaseMock.Object, EmailSenderMock.Object);
        }

        [Test]
        public void process_order_should_succeed()
        {
            // Arrange
            User.Activate();
            User.IncreaseFunds(100);

            // Act
            OrderProcessor.ProcessOrder(User.Email, Order.Id);

            // Assert
            DatabaseMock.Verify(x => x.GetUser(It.IsAny<string>()), Times.Once);
            DatabaseMock.Verify(x => x.GetOrder(It.IsAny<int>()), Times.Once);
            Assert.IsTrue(Order.IsPurchased);
        }
    }
}