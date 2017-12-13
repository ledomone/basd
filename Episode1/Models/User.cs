using System;

namespace Episode1.Models
{
    public class User
    {
        
        public User(string myName, string email)
        {
            this.MyName = myName;
            SetEmail(email);

        }
        public string MyName { get; private set; }
        public int MyAge { get; private set; }
        public string Email { get; private set; }

        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email zły!");
            }
        }
    }
}