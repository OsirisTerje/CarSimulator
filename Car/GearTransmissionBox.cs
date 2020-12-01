namespace CarSimulator
{
    public class GearTransmissionBox : IGearTransmissionBox
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

        public double Efficiency { get; set; } = 0.90;
    }
}