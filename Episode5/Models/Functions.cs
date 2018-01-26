using System;
using System.Threading;

namespace Episode5.Models
{
    public class Delegates
    {
        public delegate void Write(string message);
        public delegate int Add(int x, int y);
        public delegate void Alert(int change);

        public void Test()
        {
            Write writer = WriteMessage;
            Add adder = AddTwoNumbers;
            writer("Piotr");
            var sum = adder(1,2);
            Console.WriteLine(sum);
            CheckTemperature(TooLowAlert,OptimalAlert,TooHighAlert);
        }

        public static void TooLowAlert(int change)
        {
            Console.WriteLine($"Temperature is too low (changed by {change}).");
        }

        public static void OptimalAlert(int change)
        {
            Console.WriteLine($"Temperature is optimal (changed by {change}).");
        }

        public static void TooHighAlert(int change)
        {
            Console.WriteLine($"Temperature is too high (changed by {change}).");
        }

        public static void CheckTemperature(Alert tooLow, Alert optimal, Alert tooHigh)
        {
            var temperature = 10;
            var random = new Random();

            while(true)
            {
                var change = random.Next(-5,5);
                temperature += change;
                Console.WriteLine($"Temperature is at: {temperature} C.");
                if(temperature <= 0)
                {
                    tooLow(change);
                }
                else if(temperature > 0 && temperature <= 10)
                {
                    optimal(change);
                }
                else
                {
                    tooHigh(change);
                }
                Thread.Sleep(500);
            }
        }

        public static int AddTwoNumbers(int x, int y)
        {
            return x + y;
        }

        public static void WriteMessage(string message)
        {
            Console.WriteLine($"Hello {message}!");
        }
    }

    public class LambdaExpressions
    {
        public void Test()
        {
            Action writer = () => Console.WriteLine("Writing...");
            Action<string, int> advancedWriter = (message, number) => 
                                Console.WriteLine($"{message}, {number}");
            writer();
            Func<int,int,int> adder = (x,y) => { return x + y; };
            advancedWriter("Hello", 5);
            var sum = adder(1,2);
            advancedWriter("Sum", sum);

            Action<int, string> logger = (temperature, message) => 
            {
                Console.WriteLine($"Temperature is at: {temperature} C. {message}");
            };

            CheckTemperature(t => logger(t, "Too low!"), t => logger(t, "Optimal."),
                t => logger(t, "Too high!"));
        }

        public static void CheckTemperature(Action<int> tooLow, Action<int> optimal, Action<int> tooHigh)
        {
            var temperature = 10;
            var random = new Random();

            while(true)
            {
                var change = random.Next(-5,5);
                temperature += change;
                Console.WriteLine($"Temperature is at: {temperature} C.");
                if(temperature <= 0)
                {
                    tooLow(temperature);
                }
                else if(temperature > 0 && temperature <= 10)
                {
                    optimal(temperature);
                }
                else
                {
                    tooHigh(temperature);
                }
                Thread.Sleep(500);
            }
        }
    }

    public class StatusEventArgs : EventArgs
    {
        public string Status { get; }
        public StatusEventArgs(string status)
        {
            Status = status;
        }
    }

    public class Events
    {
        public delegate void UpdateStatus(string status);
        public event UpdateStatus StatusUpdated;
        public EventHandler<StatusEventArgs> StatusUpdatedAgain;

        public void StartUpdatingStatus()
        {
            while(true)
            {
                var message = $"status, ticks {DateTime.UtcNow.Ticks}";
                StatusUpdated?.Invoke(message);
                StatusUpdatedAgain?.Invoke(this, new StatusEventArgs(message));
                Thread.Sleep(500);
            }
        }
    }

    public class EventSandbox
    {
        public void Test()
        {
            var events = new Events();
            events.StatusUpdated += DisplayStatus;
            events.StatusUpdatedAgain += (sender, eventArgs) => 
            {
                Console.WriteLine(eventArgs.Status);
            };
            events.StartUpdatingStatus(); 
        }

        public void DisplayStatus(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayStatus2(string message)
        {
            Console.WriteLine($"2 {message}");
        }        
    }
}