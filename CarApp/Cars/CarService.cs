using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarApp.Cars
{
    public class CarService
    {
        private List<Car> Cars;
        private string carFilePath = "/Users/kayhudson/RiderProjects/CarApp/CarApp/Cars/auto-mpg.csv";

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
                Console.WriteLine(carItem[0]);
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
            var queryResult =
                from car in Cars
                where car.Name == carName
                select car;

            return queryResult.ToList();
        }

        public List<Car> FindBySpecs(decimal query)
        {
            var queryResult =
                from car in Cars
                where car.MPG == query | car.Acceleration == query | car.Cylinders == query | car.Weight == query | car.Displacement == query | car.HorsePower == query
                select car;
            
            return queryResult.ToList();
        }

        public List<Car> FindByYear(int year)
        {
            var queryResult =
                from car in Cars
                where car.Year == year
                select car;

            return queryResult.ToList();
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
            var queryResults =
                from car in Cars
                orderby car.Displacement
                select car;

            return queryResults.ToList();
        }
    }
}