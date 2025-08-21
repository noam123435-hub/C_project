using System.Runtime.InteropServices;

namespace ObjectCar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car kia;
            kia = Car.newCar("Kia Rio",5355079,"white");
            Car.print(kia);
        }
    }
    class Car
    {
        public static Car newCar(string model,int id,string color)
        {
            Car car;
            car = new Car();
            car.model = model;
            car.id = id;
            car.color = color;
            return car;
        }
        public static void print(Car car)
        {
            Console.WriteLine("the car "+car.id+" is a "+car.model+" and in "+car.color+" color");
        }
        public string model;
        public int id;
        public string color;
    }
}
