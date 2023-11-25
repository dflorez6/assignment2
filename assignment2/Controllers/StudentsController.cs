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
            // TODO: 
            // 1. Send a confirmation Flash Message (TempData) when student was successfully added to DB
            // 2. Fix validations, instead of returning the view, try to use TempData to pass ModelState errors to the
            // Manage view somehow

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

        [HttpGet]
        public IActionResult ConfirmEnrollment(int id)
        {
            var student = context.Students.Find(id);
            ViewBag.StudentCourse = context.Courses.Find(student.CourseId);
            return View(student);
        }

        [HttpPost]
        public IActionResult ConfirmEnrollment(string EnrollmentReply, int StudentId, int CourseId)
        {
            var student = context.Students.Find(StudentId);

            // Check student's reply
            if (EnrollmentReply == "Yes")
            {
                // Replied "Yes"
                student.StatusId = "EnrollmentConfirmed";
                context.Students.Update(student); // Updates record in DB
                context.SaveChanges();

                return RedirectToAction("ConfirmationSuccess", "Students");
            }
            else
            {
                // Replied "No"
                student.StatusId = "EnrollmentDeclined";
                context.Students.Update(student); // Updates record in DB
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult ConfirmationSuccess()
        {
            return View();
        }

    }
}
