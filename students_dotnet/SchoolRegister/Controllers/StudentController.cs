using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolRegister.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolRegister.Controllers
{
    [Route("/api/[controller]")]
    public class StudentController: InjectedController
    {
        public StudentController(StudentContext context) : base(context) { }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await db.Students.FindAsync(id);
            if (student is null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var department = await db.Departments.FindAsync(student.DepartmentId);
            if (department is null)
            {
                ModelState.AddModelError("Department Id", $"Department {student.DepartmentId} does not exist");
                return BadRequest(ModelState);
            }

            await db.Students.AddAsync(student);
            await db.SaveChangesAsync();

            return Ok(student.Id);
        }
    }
}