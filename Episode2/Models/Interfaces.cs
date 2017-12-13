using System;

namespace Episode2.Models
{
    public interface IEmailSender
    {
        bool IsSent{ get; }
        void SendMessage(string receiver, string title, string message);
    }

    public class EmailSender : IEmailSender
    {
        public bool IsSent => throw new NotImplementedException();

        public void SendMessage(string receiver, string title, string message)
        {
            throw new NotImplementedException();
        }
    }

    public interface IDatabase
    {
        bool IsConnected { get; }
        void Connect();
        User GetUser(string email);
        Order GetOrder(int id);
        void SaveChanges();
    }

    public class Database : IDatabase
    {
        bool IDatabase.IsConnected => throw new NotImplementedException();

        void IDatabase.Connect()
        {
            throw new NotImplementedException();
        }

        Order IDatabase.GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        User IDatabase.GetUser(string email)
        {
            throw new NotImplementedException();
        }

        void IDatabase.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

    public interface IOrderProcessor 
    {
        void ProcessOrder(string email, int orderId);
    }

    public class OrderProcessor : IOrderProcessor
    {
        private readonly IDatabase _database;
        private readonly IEmailSender _emailSender;
  
        public OrderProcessor(IDatabase database, IEmailSender emailSender)
        {
            _database = database;
            _emailSender = emailSender;
        }       
        
        void IOrderProcessor.ProcessOrder(string email, int orderId)
        {
            User user = _database.GetUser(email);
            Order order = _database.GetOrder(orderId);

            user.PurchaseOrder(order);
            _database.SaveChanges();
            _emailSender.SendMessage(email, "Order purchased", "You've purchased an order");
        }
 
    }

    public class FakeEmailSender : IEmailSender
    {
        bool IEmailSender.IsSent => throw new NotImplementedException();

        void IEmailSender.SendMessage(string receiver, string title, string message)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeDatabase : IDatabase
    {
        bool IDatabase.IsConnected => throw new NotImplementedException();

        void IDatabase.Connect()
        {
            throw new NotImplementedException();
        }

        Order IDatabase.GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        User IDatabase.GetUser(string email)
        {
            throw new NotImplementedException();
        }

        void IDatabase.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

    public class Shop
    {
        public void CompleteOrder() 
        {
            IDatabase database = new Database();
            IEmailSender emailSender = new EmailSender();
            IOrderProcessor OrderProcessor = new OrderProcessor(database, emailSender);
        }

        public void CompleteFakeOrder() 
        {
            IDatabase database = new FakeDatabase();
            IEmailSender emailSender = new FakeEmailSender();
            IOrderProcessor OrderProcessor = new OrderProcessor(database, emailSender);
        }
    }
}