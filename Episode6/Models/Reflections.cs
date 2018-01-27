using System;
using System.Reflection;

namespace Episode6.Models
{
    public class Reflections
    {
        public void Test() 
        {
            var user = new User("user1@email.com","secret");
            var type = user.GetType().GetTypeInfo();
            Console.WriteLine($"{type.Name} {type.Namespace} {type.FullName}");

            var methods = type.GetMethods();
            foreach(var method in methods)
            {
                Console.WriteLine($"{method.Name}");
            }
        }
    }
}