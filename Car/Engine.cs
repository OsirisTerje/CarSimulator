using System;

namespace CarSimulator
{
    public class Engine : IEngine
    {
        private readonly double maxPower;

        public double MaxPower => maxPower / 1000;

        /// <summary>
        /// MaxPower in kW
        /// </summary>
        /// <param name="maxPower"></param>
        public Engine(double maxPower) => this.maxPower = maxPower * 1000;

        /// <summary>
        /// See Engine Torque in https://www.engineeringtoolbox.com/cars-power-torque-d_1784.html, power in kW
        /// </summary>
        /// <param name="rpm"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public double Torque(double rpm, double power)
        {
            double p;
            if (power > MaxPower)
            {
                p = MaxPower;
            }
            else
            {
                p = power;
            }

            return p * 1000 / (2 * Math.PI * rpm / 60);
        }


    }
}