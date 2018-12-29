using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace ReflectionExample
{
    class Program
    {
        /// <summary>
        /// Finds the vehicles which contain all the property/value pairs 
        /// </summary>
        /// <param name="propValuePairs">Property value pairs.</param>
        /// <param name="vehicles">Vehicles.</param>
        static List<Vehicle> FindPropertiesInVehicleType(List<Tuple<string, string>> propValuePairs, Vehicle[] vehicles)
        {

            List<Vehicle> vehiclesWhichContainProps = new List<Vehicle>();
            foreach (var vehicle in vehicles)
            {
                string[] propertiesInVehicle = vehicle.GetType().GetProperties().Select(pi => pi.Name).ToArray();
                bool allIncluded = propValuePairs.Select(pvp => pvp.Item1).All(propertiesInVehicle.Contains);
                if (allIncluded)
                {
                    bool sameValues = propValuePairs.All((pvp) =>
                    {
                        var value = vehicle.GetType().GetProperty(pvp.Item1).GetValue(vehicle);
                        return value.ToString().Equals(pvp.Item2);
                    });
                    if (sameValues)
                    {
                        vehiclesWhichContainProps.Add(vehicle);
                    }
                }
            }

            return vehiclesWhichContainProps;

        }

        static void Main(string[] args)
        {

            List<Tuple<string, string>> PropValuePairs = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("NrOfWheels", "4"),
                new Tuple<string, string>("Color", "Red"),
                //new Tuple<string, string>("Length", "150,25")
                new Tuple<string, string>("FuelType", "Diesel")
            };

            Vehicle[] vehicles =
            {
                new Boat("ABC123", "Red", nrOfWheels: 4, length: 150.25),
                new Boat("BBB123", "Green", nrOfWheels: 0, length: 150.25),
                new Boat("CCC123", "Blue", nrOfWheels: 1, length: 150.25),
                new Car("DDD123", "Red", nrOfWheels: 4, fuelType: "Diesel")
            };

            List<Vehicle> result = FindPropertiesInVehicleType(PropValuePairs, vehicles);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            //var v = new Boat("ABC123", "Red", nrOfWheels: 4, length: 150.25);
            //Type vehicleType = v.GetType();
            //PropertyInfo[] propsInfo = vehicleType.GetProperties();
            //foreach (var prop in propsInfo)
            //{
            //    //prop.Name e.g 
            //    //prop.PropertyType.Name
            //    Console.WriteLine($"Property name: {prop.Name}, Property type: {prop.PropertyType.Name}");
            //}
        }
    }
}
