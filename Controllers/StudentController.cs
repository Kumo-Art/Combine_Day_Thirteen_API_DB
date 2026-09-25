using Combine_Day_Thirteen_API_DB.Models;
using Combine_Day_Thirteen_API_DB.Services;
using Microsoft.AspNetCore.Mvc;

namespace Combine_Day_Thirteen_API_DB.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // -> /api/Student
    public class StudentController : ControllerBase
    {
        
        private readonly IStudentServices _student;
        //private because we dont want any class accessing this variable
        
        public StudentController(IStudentServices student)
        {
             _student = student;  //supplying the empty variable with methods from our StudentServices Class
        }




        [HttpGet("GetAllStudents")]


        public ActionResult<List<Student>> GetAll()
        {
            //we are storing our students from our database into the student list
            List<Student> students = _student.GetAll();


            return Ok(students); // return 200 status and students
        }




        [HttpPost("Create")]

        public ActionResult<Student> Create([FromBody] Student newStudent)
        {
            Student createdStudent = _student.AddStudent(newStudent);

            return CreatedAtAction(
                nameof(GetAll),
                createdStudent
            );
        }


        [HttpPut("Update/{id}")]

        public ActionResult<Student> Replace(int id, [FromBody] Student student)
        {
            //possible null return we add the null ? operator
            Student? updated = _student.Replace(id, student);

            if(updated is null)
            {
                return NotFound($"No student with Id {id}");
            }

            return NoContent();

        }

        [HttpPatch("Patch/{id}")]
        public ActionResult<Student> Patch(int id, [FromBody] Student student)
        {
            Student? change = _student.Patch(id, student);

            if(change == null)
            {
                return NotFound($"No student with Id {id}");
            }

            return NoContent();
        }
    }
}