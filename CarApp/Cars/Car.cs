using System;
using System.Collections.Generic;

namespace CarApp.Cars
{
    public record Car 
    {
        public string Name;
        public int Year;
        public CountryOfOrigin Origin;
        public decimal MPG;
        public int Cylinders;
        public int Displacement;
        public int HorsePower;
        public decimal Weight;
        public decimal Acceleration;
        
        public static Car Builder(List<string> propertiesList)
        {
            // TODO: Bad idea and error prone to use a list for this. Best to use CsvReader from NuGet!
            try
            {
                return new Car()
                {
                    MPG = Convert.ToDecimal(propertiesList[0]),
                    Cylinders = Convert.ToInt32(propertiesList[1]),
                    Displacement = Convert.ToInt32(propertiesList[2]),
                    HorsePower = Convert.ToInt32(propertiesList[3]),
                    Weight = Convert.ToDecimal(propertiesList[4]),
                    Acceleration = Convert.ToDecimal(propertiesList[5]),
                    Year = Convert.ToInt32(propertiesList[6]),
                    Origin = GetOrigin(Convert.ToInt32(propertiesList[7])),
                    Name = propertiesList[8]
                };
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
            }

            return new Car();
        }

        private static CountryOfOrigin GetOrigin(int origin)
        {
            switch (origin)
            {
                case 1:
                    return CountryOfOrigin.UnitedStates;
                case 2:
                    return CountryOfOrigin.Mexico;
                case 3:
                    return CountryOfOrigin.Canada;
                default:
                    return CountryOfOrigin.UnitedStates;
            }   
        }
    }
}