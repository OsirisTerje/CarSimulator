namespace CarSimulator
{
    public class Car
    {
        private const double g = 9.81;
        public IWheel Wheel { get; }
        public double Weight { get; }
        private readonly IEngine engine;
        private readonly IGearTransmissionBox gearbox;

        private const double AerodynamicResistanceForce = 250;  // N
       

        public Car(double weight, IEngine engine, IGearTransmissionBox gearbox,  IWheel wheel)
        {
            Wheel = wheel;
            Weight = weight;
            this.engine = engine;
            this.gearbox = gearbox;
        }

        /// <summary>
        /// See https://www.engineeringtoolbox.com/cars-power-torque-d_1784.html
        /// </summary>
        /// <param name="speed">km/t</param>
        /// <returns></returns>
        public double PowerRequiredForConstantSpeed(double speed)
        {
            var metricSpeed = ConvertKmHToSi(speed);
            return (Wheel.RollingResistanceForce(speed,Weight) + AerodynamicResistanceForce) * metricSpeed / gearbox.Efficiency;
        }

        public double ConvertKmHToSi(double speedInKmPerH) => speedInKmPerH / 3.6;

        public void Start()
        {

        }

        public void Stop()
        {

        }

        public void AccelerateTo(double speed)
        {

        }

        public double CurrentSpeed { get; set; }
    }
}