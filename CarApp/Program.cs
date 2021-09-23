using System;
using System.Linq;
using CarApp.Cars;

namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CarService service = new CarService();
            Console.Write("Total cars: ");
            Console.WriteLine(service.GetAll().Count);
            Console.Write("Average MPG: ");
            Console.WriteLine(service.GetAverageMpg());
            Console.Write("Sort by displacement: ");
            service.SortByDisplacement().Select(car => car.Displacement).ToList().ForEach(Console.WriteLine);
        }
    }
}