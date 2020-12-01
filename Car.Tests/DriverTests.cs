using NUnit.Framework;
using CarSimulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSimulator.Tests
{
    
    public class DriverTests
    {
        [Test]
        public void CreateDriverTest()
        {
            var sut = Driver.CreateDriver("01020398767", "John", "Doe");
            
            Assert.That(sut, Is.Not.Null, "Could not create driver");

            Assert.Multiple(() =>
            {
                Assert.That(sut.GivenName, Is.EqualTo("John"));
                Assert.That(sut.LastName, Is.EqualTo("Doe"));
                Assert.That(sut.Pid, Is.EqualTo("01020398767"));
                Assert.That(sut.StartDrivingYear, Is.EqualTo(DateTime.Now.Year));

                Assert.That(sut.FullName, Is.EqualTo("John Doe"));
                Assert.That(sut.NoOfYearsDrivingExperience, Is.EqualTo(0));
            });

        }

        [Test]
        public void ThatWrongPidsThrowException()
        {
            Assert.Throws<ArgumentException>(() => Driver.CreateDriver("12345698765", "John", "Doe"));
        }

        [Test]
        public void ThatNoOfYearsDrivingExperienceIsCorrect()
        {
            var sut = Driver.CreateDriver("01020398767", "John", "Doe");
            sut.StartDrivingYear = DateTime.Now.Year - 42;

            var result = sut.NoOfYearsDrivingExperience;

            Assert.That(result, Is.EqualTo(42));
        }
    }
}