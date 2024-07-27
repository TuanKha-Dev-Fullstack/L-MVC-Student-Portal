using L_MVC_Student_Portal.Data;
using L_MVC_Student_Portal.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L_MVC_Student_Portal.Controllers
{
    public class StudentController(AppDbContext _context) : Controller
    {
        // GET: StudentController
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        
        // POST: StudentController
        [HttpPost]
        public async Task<ActionResult> Add(Models.AddStudentViewModel studentInfo)
        {
            var student = new Student()
            {
                Name = studentInfo.Name,
                Email = studentInfo.Email,
                Phone = studentInfo.Phone,
                Subscribed = studentInfo.Subscribed
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return View();
        }
        
        // GET: StudentController
        [HttpGet]
        public async Task<ActionResult> ListStudents()
        {
            var students = await _context.Students.ToListAsync();
            return View(students);
        }
    }
}
