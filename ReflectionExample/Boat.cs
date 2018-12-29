using System;
namespace ReflectionExample
{
    public class Boat : Vehicle
    {
        public Boat(string regNr, string color, int nrOfWheels, double length) : base(regNr, color, nrOfWheels) => Length = length;

        public double Length { get; set; } //Double
    }
}
