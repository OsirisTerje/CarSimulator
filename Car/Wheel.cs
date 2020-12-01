using System;

namespace CarSimulator
{
    public class Wheel : IWheel
    {
        private const double g = 9.81;
        public Wheel(double radius)
        {
            Radius = radius;
        }
        /// <summary>
        /// tire pressure (bar)
        /// </summary>
        public double Pressure { get; set; } = 1.0;

        public double Radius { get; }

        public double Force(double torque)
        {
            return torque / Radius;
        }

        /// <summary>
        /// Speed, in km/h,  From https://www.engineeringtoolbox.com/rolling-friction-resistance-d_1303.html
        /// </summary>
        /// <param name="speed">velocity (km/h)</param>
        /// <returns></returns>
        public double RollingResistanceCoefficient(double speed)
        {
            CurrentSpeed = speed;
            return 0.005 + 1 / Pressure * (0.01 + 0.0095 * Math.Pow(speed / 100, 2));
        }

        public double CurrentSpeed { get; private set; }

        /// <summary>
        /// Speed, in km/h
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public double RollingResistanceForce(double speed,double weight) => RollingResistanceCoefficient(speed) * weight * g;

    }
}