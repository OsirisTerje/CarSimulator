using NUnit.Framework;
using CarSimulator;
using System;
using System.Collections.Generic;
using System.Text;
// using Extensions;
// using Is = Extensions.Is;

namespace CarSimulator.Tests
{
    /// <summary>
    ///  See Engine Torque in https://www.engineeringtoolbox.com/cars-power-torque-d_1784.html
    /// </summary>
    public class EngineTests
    {

        [Test]
        public void ThatTorqueCanBeCalculated()
        {
            var sut = new Engine(200);

            var result = sut.Torque(1500, 19.118);

            Assert.That(result, Is.EqualTo(121).Within(1.0));
           

        }

        
        [Test]
        public void ThatTorqueVariesWithRpm()
        {
            var sut = new Engine(200);
            var t1 = sut.Torque(100, 100);
            var t2 = sut.Torque(200, 100);
            var diff = t1 / t2;
            Assert.That(diff, Is.EqualTo(2).Within(0.1));
            
        }

        /// <summary>
        /// Happy Path
        /// </summary>
        [Test]
        public void ThatTorqueVariesWithPower()
        {
            var sut = new Engine(200);
            var t1 = sut.Torque(100, 50);
            var t2 = sut.Torque(100, 100);
            var diff = t2 / t1;
            Assert.That(diff, Is.EqualTo(2).Within(0.1));

        }

        /// <summary>
        /// Alternate path
        /// </summary>
        [Test]
        public void ThatTorqueIsFixedForHighPower()
        {
            var sut = new Engine(200);
            var t1 = sut.Torque(100, 250);
            var t2 = sut.Torque(100, 500);
            var diff = t1 / t2;
            Assert.That(diff, Is.EqualTo(1).Within(0.1));
        }
    }
}