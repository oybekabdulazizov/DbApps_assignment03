using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project01.Models;
using Project01.Services;

namespace Project01.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        MockDbService _mockDb = new MockDbService();

        // ============================================= GetStudent() =============================================
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return _mockDb.GetStudents();
        }
        // ========================================================================================================

        // =========================================== GetStudent(int id) =========================================
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            Student student = _mockDb.GetStudents().FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                return Ok(student);
            }
            return NotFound($"Sorry mate. There is an error in GetStudents() method.\nStudent with id {id} does not exist.");
        }
        // ========================================================================================================

        // ===================================== CreateStudent(Student student) ===================================
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = randomId();
            _mockDb.GetStudents().Add(student);
            return Ok($"Student {student.FirstName} has been added to the list. ");
        }
        // ========================================================================================================

        // ======================================= PutStudent(Studnet student) ====================================
        [HttpPut("{id}")]
        public IActionResult PutStudent(Student student)
        {

            //Student student = _mockDb._getStudents().FirstOrDefault(x => x._idStudent == id);

            if (student == null)
            {
                return NotFound($"There is an error in PutStudent() method.");
            }
            else if (student.Id < 1 || student.FirstName == null || student.LastName == null)
            {
                return NotFound($"You only can change all the details of the student.\n" +
                                $"Changing only some areas is not allowed.");
            }
            else
            {
                student.IndexNumber = randomId();
                // return Ok($"Student with id {id} has been updated successfully!");
                return Ok(student);
            }

        }
        // ========================================================================================================

        // ===================================== DeleteStudent(Studnet student) ===================================
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            Student student = _mockDb.GetStudents().FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return NotFound($"Sorry mate. Student with id {id} does not exist.");
            }
            else
            {
                _mockDb.GetStudents().Remove(student);
                return Ok($"Student with id {student.Id} has been deleted successfully!");
            }
        }
        // ========================================================================================================


        private string randomId()
        {
            return $"s{new Random().Next(15000, 21000)}";
        }

    }
}
