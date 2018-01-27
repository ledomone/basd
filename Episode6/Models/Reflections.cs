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
                // Console.WriteLine($"{method.Name}");
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

            var email = type.GetProperty("Email").GetValue(user);
            Console.WriteLine($"Email: {email}");

            var databaseTypes = Assembly.GetEntryAssembly()
                                        .GetTypes()
                                        .Where(x => x.Name.Contains("Database"));
            foreach(var databaseType in databaseTypes)
            {
                Console.WriteLine($"{databaseType}");
            }

            var user2 = (User)Activator.CreateInstance(typeof(User), new[]{"userXX@gmail.com", "secretPassword"});
            Console.WriteLine($"{user2.Email}");
        }
    }

    public class Dynamics
    {
        public void Test()
        {
            dynamic user = new User("user1@email.com","secret");
            Console.WriteLine($"{user.Email}");
            user.SetEmail("user2@email.com");
            Console.WriteLine($"{user.Email}");
        }
    }
}