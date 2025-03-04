using Microsoft.AspNetCore.Mvc;

namespace NZRegionWalksAPI.Controllers
{
    // {baseUrl}/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // Get: {baseUrl}/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] students = new string[] { "John", "Doe", "Jane", "Doe" };
            return Ok(students);
        }
    }
}
