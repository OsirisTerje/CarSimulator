using System;

namespace Car
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var car = new Car(1000, 200);
            
        }
    }



    public class Car
    {
        private readonly double weight;
        private readonly double power;

        private const double RollingResistanceForce = 400;  // N
        private const double AerodynamicResistanceForce = 250;  // N
        private const double Efficiency = 0.95;

        public Car(double weight, double power)
        {
            this.weight = weight;
            this.power = power;
        }

        public double PowerRequiredForConstantSpeed(double speed)
        {
            return (RollingResistanceForce + AerodynamicResistanceForce) * speed / Efficiency;
        }

        public void Start()
        {

        }

        public void Stop()
        {

        }

        public void AccelerateTo(double speed)
        {

        }

        public double CurrentSpeed { get; private set; }
    }

    public class Wheel
    {
        private readonly double radius;

        public Wheel(double radius)
        {
            this.radius = radius;
        }

        public double Force(double torque)
        {
            return torque / radius;
        }
        
    }

    public class Engine
    {
        private readonly double power;

        public Engine(double power)
        {
            this.power = power;
        }

                
    }

    public class GearTransmissionBox
    {
        private readonly double gearRatio;

        public GearTransmissionBox(double gearRatio)
        {
            this.gearRatio = gearRatio;
        }

        public double OutputTorque(double engineTorque)
        {
            return engineTorque / gearRatio;
        }
    }
}
