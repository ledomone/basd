using System;
using System.Collections.Generic;

namespace Episode2.Models
{
    public abstract class Car
    {
        public double Acceleration { get; protected set; } = 10;
        public double Speed { get; protected set;} = 100;
        public void Start() {
            Console.WriteLine("Turning on the engine...");
            Console.WriteLine($"Running at: {Speed.ToString()} km/h.");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping the car...");
        }

        public virtual void Accelerate()
        {
            Console.WriteLine("Accelerating...");
            Speed += Acceleration;
            Console.WriteLine($"Running at: {Speed} km/h.");
        }

        public abstract void Boost();
    }

    public class  Truck: Car 
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a truck...");
            Speed += Acceleration;
            Console.WriteLine($"Running the truck at: {Speed} km/h.");
        }

        public override void Boost()
        {
            throw new NotImplementedException();
        }
    }

    public class  SportCar: Car 
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a sport car...");
            base.Accelerate();
        }

        public override void Boost()
        {
            throw new NotImplementedException();
        }
    }

    public class Race
    {
        public void Begin() 
        {
            SportCar sportCar = new SportCar();
            Truck truck = new Truck();

            List<Car> cars = new List<Car>
            {
                sportCar, truck
            };
            
            foreach(Car car in cars)
            {
                car.Start();
                car.Accelerate();
            }
        }
    }
}