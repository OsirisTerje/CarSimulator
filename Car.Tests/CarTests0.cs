using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NUnit.Framework;

namespace CarSimulator.Tests
{
    public class CarTests0
    {
        [Test]
        public void ThatWeightIsCorrect1()
        {
            var sut = new Car(1000, null, null,null);
            Assert.That(sut.Weight, Is.EqualTo(1000).Within(1));
        }


        [Test]
        public void ThatWeightIsCorrect2()
        {
            var engine = Substitute.For<IEngine>();
            var gearbox = Substitute.For<IGearTransmissionBox>();
            var wheel = Substitute.For<IWheel>();

            var sut = new Car(1000, engine, gearbox, wheel);
            Assert.That(sut.Weight, Is.EqualTo(1000).Within(1));
        }
    }
}
