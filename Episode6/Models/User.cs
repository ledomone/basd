using System;
using System.Collections.Generic;

namespace Episode6.Models
{
    public class User
    {
        private readonly ISet<Order> _orders = new HashSet<Order>();
        public string Email { get; private set; }
        [UserPassword]
        public string Password { get; private set; }
        
        //Let's assume that we don't care about the value here.
        public string FirstName { get; set; } 
        
        //And the same way of thinking does apply here.
        public string LastName { get; set; }  

        public int Age { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public decimal Funds { get; private set; }
        public IEnumerable<Order> Order { get { return _orders; }}

        public User(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
        }

        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email is incorrect.");
            }
            if(Email == email)
            {
                return;
            }

            Email = email;
            MarkAsUpdated();
        }

        public void SetPassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is incorrect.");
            }
            if(Password == password)
            {
                return;
            }

            Password = password;
            MarkAsUpdated();
        }

        public void SetAge(int age)
        {
            if(age < 13)
            {
                throw new Exception("Age must be greater or equal to 13");
            }
            if(Age == age)
            {
                return;
            }
            
            Age = age;
            MarkAsUpdated();
        }

        public void Activate()
        {
            if(IsActive)
            {
                return;
            }

            IsActive = true;
            MarkAsUpdated();
        }

        public void Deactivate()
        {
            if(!IsActive)
            {
                return;
            }

            IsActive = false;
            MarkAsUpdated();
        }

        public void IncreaseFunds(decimal funds)
        {
            if(funds <= 0)
            {
                throw new Exception("Funds must be greater than 0.");
            }

            Funds += funds;
            MarkAsUpdated();
        }

        public void PurchaseOrder(Order order)
        {
            if(!IsActive)
            {
                throw new Exception("Only active user can purchase an order.");
            }

            decimal orderPrice = order.TotalPrice;
            if(Funds - orderPrice < 0)
            {
                throw new Exception("You don't have enough money.");
            }

            order.Purchase();
            Funds -= orderPrice;
            _orders.Add(order);
            MarkAsUpdated();
        }

        private void MarkAsUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}