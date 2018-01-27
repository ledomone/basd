using System;

namespace Episode6.Models
{
    public class Reflections
    {
        public void Test() 
        {
            var user = new User("user1@email.com","secret");
            var type = user.GetType();
            Console.WriteLine($"{type.Name} {type.Namespace} {type.FullName}");
        }
    }
}