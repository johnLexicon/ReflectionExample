using System;
namespace ReflectionExample
{
    public class Car : Vehicle
    {
        public Car(string regNr, string color, int nrOfWheels, string fuelType) : base(regNr, color, nrOfWheels) => FuelType = fuelType;
   
        public string FuelType { get; set; }
    }
}
