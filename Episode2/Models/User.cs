using System;
using System.Collections.Generic;

namespace Episode2.Models
{
    public class User
    {
        
        public User(string myName, string email)
        {
            this.MyName = myName;
            SetEmail(email);

        }

        private ISet<Order> _orders = new HashSet<Order>();
        public string MyName { get; private set; }
        public int MyAge { get; private set; }
        public string Email { get; private set; }

         public IEnumerable<Order> Orders {get { return _orders; }}

        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email zły!");
            }
        }

        internal void PurchaseOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}