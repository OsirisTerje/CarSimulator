using System;
using System.Collections.Generic;
using System.Text;

namespace CarSimulator
{
    public class OldCar
    {
        public Wheel Wheel { get; }
        public Engine Engine { get; }
        public GearTransmissionBox GearBox { get; }

        public OldCar(double weigth)
        {
            Wheel = new Wheel(0.5);
            Engine = new Engine(200);
            GearBox = new GearTransmissionBox(2);
        }
    }
}
