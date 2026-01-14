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

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            _students.Add(student);

            return Ok(student);
        }
    }
}
