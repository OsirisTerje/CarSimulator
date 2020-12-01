using System;

namespace CarSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Car Simulator");
            var wheel = new Wheel(18 * 2.54 / 2) {Pressure = 2.5};
            var engine = new Engine(200);
            var gearbox = new GearTransmissionBox(0.9);
            var car = new Car(2000, engine,gearbox,wheel);
            
        }
    }


    public interface IWheel
    {
        double Radius { get; }

        /// <summary>
        /// tire pressure (bar)
        /// </summary>
        double Pressure { get; set; }

        double Force(double torque);

        /// <summary>
        /// From https://www.engineeringtoolbox.com/rolling-friction-resistance-d_1303.html
        /// </summary>
        /// <param name="speed">velocity (km/h)</param>
        /// <returns></returns>
        double RollingResistanceCoefficient(double speed);

        double RollingResistanceForce(double speed,double weight);
    }

    public interface IEngine
    {
        double Torque(double rps, double power);
    }

    public interface IGearTransmissionBox
    {
        double Efficiency { get; set; }
        double OutputTorque(double engineTorque);
    }
}
