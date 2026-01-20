//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using StudentWebApiDemo.Models;

//namespace StudentWebApiDemo.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentsController : ControllerBase
//    {
//        [HttpGet]
//        public IEnumerable<Student> Get()

//        {
//            return new List<Student>()
//            {
//            new Student() { Id = 1, Name = "Ram", Age = 20 },
//            new Student() { Id = 2, Name = "Shyam", Age = 25 },
//            new Student() { Id = 3, Name = "Hari", Age = 18 },
//            };
//        }
//    }
//}


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentWebApiDemo.Models;
using System.Xml.Linq;

namespace StudentWebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student { Id = 1, Name = "Ram", Age = 20 },
            new Student { Id = 2, Name = "Shyam", Age = 25 },
            new Student { Id = 3, Name = "Hari", Age = 18 },
        };

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _students;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           var student =_students.FirstOrDefault(s => s.Id == id);
            if (student ==null)
            {
                return NotFound($"Student with id {id} not found");
            }
            return Ok(student);
        }
        [HttpPut("{id}")]
        public IActionResult PutById(int id, Student updateStudent)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound($"Student with id {id} not found");
            }
            student.Name = updateStudent.Name;
            student.Age = updateStudent.Age;
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound($"Student with id {id} not found");
            }
            _students.Remove(student);
            return Ok(student);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            _students.Add(student);

            return Ok(student);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string name)
        {
            var result = _students.Where(s=> s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            return Ok(result);
        }
    }
}
