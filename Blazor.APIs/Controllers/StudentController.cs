using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace Blazor.APIs.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IBusiness _business;
        public StudentController(IBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [Route("GetStudents")]
        public async Task<ActionResult<List<StudentVM>>> GetStudents()
        {
            var students = await _business.GetStudents();
            return Ok(students);
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<ActionResult<int>> AddStudent(StudentVM student)
        {
            var newStudentId = await _business.AddStudent(student);

            return newStudentId;
        }

        [HttpPut]
        [Route("UpdateStudent/{studentId}")]
        public async Task<IActionResult> UpdateStudent(int studentId, StudentVM updatedStudent)
        {
            await _business.UpdateStudent(studentId, updatedStudent);
            return Ok();
        }

        [HttpGet]
        [Route("GetStudentById/{studentId}")]
        public async Task<ActionResult<StudentVM>> GetStudentById(int studentId)
        {
            var student = await _business.GetStudentById(studentId);
            return Ok(student);
        }

        [HttpDelete]

        [Route("DeleteStudent/{studentId}")]

        public async Task<IActionResult> DeleteStudent(int studentId)

        {

            await _business.DeleteStudent(studentId);

            return Ok();

        }
    }
}
