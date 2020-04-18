using Project01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.Services
{
    public class MockDbService: IDbService
    {
        private static List<Student> students;

        static MockDbService()
        {
            students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Gwen",
                    LastName = "Stacy",
                    IndexNumber = _randomId()
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Ariana",
                    LastName = "Grande",
                    IndexNumber = _randomId()
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Megan",
                    LastName = "Fox",
                    IndexNumber = _randomId()
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Jennifer",
                    LastName = "Lawrence",
                    IndexNumber = _randomId()
                }
            };
        }
        public List<Student> GetStudents()
        {
            return students;
        }

        private static string _randomId()
        {
            return $"s{new Random().Next(15000, 21000)}";
        }

    }
}
