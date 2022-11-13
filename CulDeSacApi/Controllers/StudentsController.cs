using CulDeSacApi.Models.Students;
using CulDeSacApi.Services.Foundations.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace CulDeSacApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : RESTFulController
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService) =>
            this.studentService = studentService;


        [HttpPost]
        public async ValueTask<ActionResult<Student>> Post(Student student)
        {
            Student addedStudent = await studentService.AddStudentAsync(student);

            return Created(addedStudent);
        }
    }
}
