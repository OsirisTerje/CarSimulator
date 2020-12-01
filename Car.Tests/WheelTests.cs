using NUnit.Framework;

namespace CarSimulator.Tests
{
    /// <summary>
    /// https://www.engineeringtoolbox.com/rolling-friction-resistance-d_1303.html
    /// </summary>
    public class WheelTests
    {
       

        [Test]
        public void CheckCoefficient_LowSpeed()
        {
            // Assume
            var sut = new Wheel(18 * 2.54 / 2) {Pressure = 2.0};
            
            // Act
            var coef = sut.RollingResistanceCoefficient(20);

            // Assert
            Assert.That(coef, Is.GreaterThan(0.005).And.LessThan(0.015), "Coefficient wrong");
        }

        [Test]
        public void CheckCoefficient_HighSpeed()
        {
            // Assume
            var sut = new Wheel(18 * 2.54 / 2) { Pressure = 2.0 };

            // Act
            var coef = sut.RollingResistanceCoefficient(100);

            // Assert
            Assert.That(coef, Is.GreaterThan(0.01).And.LessThan(0.02), "Coefficient wrong");
        }

        

    }
}