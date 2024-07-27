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
            return RedirectToAction("ListStudents", "Student");
        }
        
        // GET: StudentController
        [HttpGet]
        public async Task<ActionResult> ListStudents()
        {
            var students = await _context.Students.ToListAsync();
            return View(students);
        }
        
        // GET: StudentController
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            return View(student);
        }
        
        // POST: StudentController
        [HttpPost]
        public async Task<ActionResult> Edit(Student viewModel)
        {
            var student = await _context.Students.FindAsync(viewModel.Id);
            if (student is null) return RedirectToAction("ListStudents", "Student");
            student.Name = viewModel.Name;
            student.Email = viewModel.Email;
            student.Phone = viewModel.Phone;
            student.Subscribed = viewModel.Subscribed;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("ListStudents", "Student");
        }
    }
}
