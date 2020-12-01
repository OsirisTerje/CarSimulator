using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CarSimulator.Tests
{
    public class WheelTestParametrized
    {
        [TestCase(100, 4, 0.008, 0.012)]
        [TestCase(20, 4, 0.005, 0.01)]
        [TestCase(100, 2, 0.01, 0.02)]
        [TestCase(20, 2, 0.005, 0.015)]
        public void CheckCoefficient(double speed, double pressure, double expectedLow, double expectedHigh)
        {
            // Assume
            var sut = new Wheel(18 * 2.54 / 2) { Pressure = pressure };

            // Act
            var coef = sut.RollingResistanceCoefficient(speed);

            // Assert
            Assert.That(coef, Is.GreaterThan(expectedLow).And.LessThan(expectedHigh), "Coefficient wrong");
        }

        [TestCaseSource(typeof(WheelDataSource),nameof(WheelDataSource.Loopit))]
        public void CheckManyCoefficients(double pressure, int speed)
        {
            const double expectedLow = 0.005;
            const double expectedHigh = 0.035;
            // Assume
            var sut = new Wheel(18 * 2.54 / 2) { Pressure = pressure };
            // Act
            var coef = sut.RollingResistanceCoefficient(speed);
            // Assert
            Assert.That(coef, Is.GreaterThan(expectedLow).And.LessThan(expectedHigh), "Coefficient wrong");
        }
    }


    public class WheelDataSource
    {
        public static IEnumerable<TestCaseData> Loopit()
        {
            var pressures = new[] {1.0, 1.5, 2.0, 3.0, 4.0};
            var speeds = new[] {20, 40, 60, 80, 100, 140};
            foreach (double pressure in pressures)
            {
                foreach (int speed in speeds)
                {
                    yield return new TestCaseData(pressure, speed);
                }
            }
        }
    }

}