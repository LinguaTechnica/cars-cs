using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarApp.Cars
{
    public class CarService
    {
        private List<Car> Cars;
        private string carFilePath = "/Users/owner/RiderProjects/cars-cs/CarApp/Cars/auto-mpg.csv";

        public CarService()
        {
            Cars = new List<Car>();
            Initialize();
        }

        private void Initialize()
        {
            Console.WriteLine("Initializing Car Service...");

            string[] rows = File.ReadAllLines(carFilePath);
            var queryList =
                from row in rows
                let elements = row.Split(',')
                select elements;

            foreach (var carItem in queryList)
            {
                // Skip header line
                if (carItem.Contains("mpg"))
                {
                    continue;
                }
                Cars.Add(Car.Builder(carItem.ToList()));
                
            }
        }
        
        public List<Car> GetAll()
        {
            return Cars;
        }

        public List<Car> FindByName(string carName)
        {
            return Cars.Where(car => car.Name == carName).ToList();
        }

        public List<Car> FindBySpecs(decimal query)
        {
            return Cars.Where(car =>
                car.MPG == query | car.Acceleration == query | car.Cylinders == query | car.Weight == query |
                car.Displacement == query | car.HorsePower == query).ToList();
        }

        public List<Car> FindByYear(int year)
        {
            return Cars.Where(car => car.Year == year).ToList();
        }

        public decimal GetAverageMpg()
        {
            decimal total = 0;
            foreach (var car in Cars)
            {
                total += car.MPG;
            }

            return decimal.Round(total / Cars.Count, 3);
        }

        public List<Car> SortByDisplacement()
        {
            return Cars.OrderBy(car => car.Displacement).ToList();
        }
    }
}