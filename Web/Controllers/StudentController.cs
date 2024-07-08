using System.Collections.Generic;
using System.Web.Mvc;
using Application.Services;
using Core.Entities;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public ActionResult Index()
        {
            var students = _studentService.GetAllStudents();
            return View(students);
        }

        public ActionResult Details(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // Add other actions for Create, Edit, Delete as needed
    }
}
