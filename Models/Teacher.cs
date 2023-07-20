using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30.Models
{
    public class Teacher:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Salary { get; set; }
        public DateTime Bday { get; set; }

        private static int counter = 0;
        public Teacher(string name, string surname, double salary, DateTime bday)
        {
            Name = name;
            Surname = surname;
            Salary = salary;
            Bday = bday;

            Id = counter++;
            counter++;
        }
    }
}
