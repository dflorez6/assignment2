/*  StudentsController.cs
    Assignment 2

    Revision History
    David Florez ID: 8820815, 2023.11.24: Created
*/
using assignment2.Models;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    public class StudentsController : Controller
    {
        // DB Context
        private CoursesContext context { get; set; }
        public StudentsController(CoursesContext ctx) => context = ctx;

        //====================
        // Actions
        //====================
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            // Checks for Model validations
            if (ModelState.IsValid)
            {
                // If validations pass
                context.Students.Add(student); // Inserts new record into DB
                context.SaveChanges();
                return RedirectToAction("Manage", "Courses", new { id = student.CourseId });
            }
            else
            {
                // If validations don't pass
                return View();
            }
        }

    }
}
