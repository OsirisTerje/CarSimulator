using NUnit.Framework;

namespace CarSimulator.Tests
{
    public class WheelTestsWithSetup
    {
        private IWheel sut;

        [SetUp]
        public void Init()
        {
            // Assume
            sut = new Wheel(18 * 2.54 / 2) { Pressure = 2.0 };
        }

        [Test]
        public void CheckCoefficient_LowSpeed()
        {
            // Act
            var coef = sut.RollingResistanceCoefficient(20);

            // Assert
            Assert.That(coef, Is.GreaterThan(0.005).And.LessThan(0.015), "Coefficient wrong");
        }

        [Test]
        public void CheckCoefficient_HighSpeed()
        {
            // Act
            var coef = sut.RollingResistanceCoefficient(100);

            // Assert
            Assert.That(coef, Is.GreaterThan(0.01).And.LessThan(0.02), "Coefficient wrong");
        }
    }
}