using System;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Episode8.Models
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

            dynamic anything = new ExpandoObject();
            anything.id = 1;
            anything.name = "me";
            Console.WriteLine($"{anything.id} {anything.name}");

            foreach(var property in anything)
            {
                Console.WriteLine($"{property.Key} {property.Value}");
            }
        }
    }

    public class Attributes 
    {
        public void Test()
        {
            var user = new User("a@b.pl", "secret");
            var passwordAttribute = (UserPasswordAttribute)user.GetType()
                                        .GetTypeInfo()
                                        .GetProperty("Password")
                                        .GetCustomAttribute(typeof(UserPasswordAttribute));
            var isPasswordValid = user.Password.Length == passwordAttribute.Length;
            Console.WriteLine($"Is valid: {isPasswordValid}");                                        
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class UserPasswordAttribute : Attribute
    {
         public int Length { get; }

         public UserPasswordAttribute(int length = 4)
         {
             Length = length;
         }
    }

    public class Asynchronous
    {
        public async Task Test()
        {
            var content = await GetContentAsync();
            Console.WriteLine(content);
        }

        public async Task<string> GetContentAsync()
        {
            var httpClient = new HttpClient();
            var task = httpClient.GetAsync("https://jsonplaceholder.typicode.com/photos");
            Console.WriteLine("No wait...");
            var response = await task;
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }

    public class Parallelism
    {
        public void Test()
        {
            var numbers = Enumerable.Range(1, 100);
            Parallel.ForEach(numbers, number =>
            {
                Console.WriteLine($"Number {number} on thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100);
            });
        }
    }
}