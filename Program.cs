using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pr8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Police police = new Police(car);

            for(int i = 0; i < 20; i++)
            {
                Thread.Sleep(1000);
                car.AddSpeed(10);
            }
        }
    }

    class Police
    {
        public Car Car { get; set; }

        public Police(Car car)
        {
            Car = car;
            Car.CarSpeedEvents += speedCheck;
        }

        public static bool speedCheck(Car car)
        {
            if (car.Speed >= 80 && car.Speed <120)
            {
                Console.WriteLine("снизьте скорость");
            }

            if (car.Speed >= 120)
            {
                Console.WriteLine("вы задержаны");
                return false;
            }
            
            if (car.Speed == 100)
            {
                Console.WriteLine("брат, куда гонишь?");
            }
            return true;
        }
    }


    class Car
    {
        public int Speed { get; set; }

        public delegate bool CarSpeedDelegate(Car car);

        public event CarSpeedDelegate CarSpeedEvents;

        public Car()
        {
            Speed = 0;
        }

        public void AddSpeed(int speed)
        {
            if (CarSpeedEvents(this))
            {
                Speed += speed;
                Console.WriteLine(Speed);
            }
        }

    }
}
