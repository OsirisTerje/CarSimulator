using NSubstitute;
using NUnit.Framework;

namespace CarSimulator.Tests
{
    public class CarTests
    {
        /// <summary>
        /// See https://www.engineeringtoolbox.com/cars-power-torque-d_1784.html  Car and Required Power
        /// </summary>
        [Test]
        public void ThatRequiredPowerCalculationIsCorrect()
        {
            var engine = Substitute.For<IEngine>();
            var gearbox = Substitute.For<IGearTransmissionBox>();
            gearbox.Efficiency.Returns(0.85);
            var wheel = Substitute.For<IWheel>();
            wheel.RollingResistanceForce(Arg.Any<double>(), Arg.Any<double>()).Returns(400);

            var sut = new Car(1000, engine, gearbox, wheel);
            var result = sut.PowerRequiredForConstantSpeed(90);

            Assert.That(result, Is.EqualTo(19118).Within(100), "Calculated wrong power");

        }


        [Test]
        public void ThatWheelRollingResistanceForceHaveBeenCalled()
        {
            var engine = Substitute.For<IEngine>();
            var gearbox = Substitute.For<IGearTransmissionBox>();
            var wheel = Substitute.For<IWheel>();
            
            var sut = new Car(1000, engine, gearbox, wheel);
            sut.PowerRequiredForConstantSpeed(90);

            wheel.Received().RollingResistanceForce(Arg.Any<double>(), Arg.Any<double>());
            
        }


    }







    // sut.Received().ConvertToSi(Arg.Any<double>());
    // wheel.Received().RollingResistanceCoefficient(Arg.Any<double>());
    // wheel.DidNotReceive().RollingResistanceForce(Arg.Any<double>(), Arg.Any<double>());



}
