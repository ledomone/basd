using System;
using System.Linq;
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

            user.Activate();
            Console.WriteLine($"Is active: {user.IsActive}.");

            var deactivateMethod = methods.First(x => x.Name == "Deactivate");
            deactivateMethod.Invoke(user, null);
            Console.WriteLine($"Is active: {user.IsActive}.");

            Console.WriteLine($"Email: {user.Email}");
            var setEmailMethod = type.GetMethod("SetEmail");
            setEmailMethod.Invoke(user, new[]{"newMail@op.pl"});
            Console.WriteLine($"Email: {user.Email}");
            
        }
    }
}