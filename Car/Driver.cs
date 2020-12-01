using System;
using NinEngine;

namespace CarSimulator
{
    public interface IDriver
    {
        string GivenName { get; }
        string LastName { get; }
        string Pid { get; }
        string ZipCode { get; set; }
        string Place { get; set; }
        string Country { get; set; }
        int StartDrivingYear { get; set; }
        int NoOfYearsDrivingExperience { get; }
        string FullName { get; }
    }

    public class Driver : IDriver
    {
        public string GivenName { get; }
        public string LastName { get; }

        public string Pid { get; }

        public string ZipCode { get; set; }
        public string Place { get; set; }

        public string Country { get; set; }

        public int StartDrivingYear { get; set; } = DateTime.Now.Year;

        public int NoOfYearsDrivingExperience => DateTime.Now.Year - StartDrivingYear;

        public string FullName => $"{GivenName} {LastName}";

        public Driver(string pid, string givenname, string lastname)
        {
            Pid = pid;
            GivenName = givenname;
            LastName = lastname;
        }

        public static Driver CreateDriver(string pid, string givenname, string lastname)
        {
            if (!pid.IsValidFoedselsnummer())
                throw new ArgumentException("Invalid pid number", pid);
            return new Driver(pid, givenname, lastname);
        }

    }
}
