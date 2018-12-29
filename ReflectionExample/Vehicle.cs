using System;
namespace ReflectionExample
{
    public class Vehicle
    {
        public Vehicle(string regNr, string color, int nrOfWheels)
        {
            RegNr = regNr;
            Color = color;
            NrOfWheels = nrOfWheels;
        }

        public string RegNr { get; set; } //String
        public string Color { get; set; } //String
        public int NrOfWheels { get; set; } //Int32

    }
}
