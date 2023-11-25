/*  CoursesController.cs
    Assignment 2

    Revision History
    David Florez ID: 8820815, 2023.11.24: Created
*/
using assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using NuGet.Protocol.Core.Types;
using System.Diagnostics.Metrics;

namespace assignment2.Controllers
{
    public class CoursesController : Controller
    {
        // DB Context
        private CoursesContext context { get; set; }
        public CoursesController(CoursesContext ctx) => context = ctx;

        //====================
        // Actions
        //====================
        [HttpGet]
        public IActionResult Index()
        {
            // Retrieves "all" records from DB
            var courses = context.Courses.OrderByDescending(c => c.Start).ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            // Checks for Model validations
            if (ModelState.IsValid)
            {
                // If validations pass
                context.Courses.Add(course); // Inserts new record into DB
                context.SaveChanges();
                return RedirectToAction("Manage", "Courses", new { id = course.CourseId });
            }
            else
            {
                // If validations don't pass
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var course = context.Courses.Find(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            // Checks for Model validations
            if (ModelState.IsValid)
            {
                // If validations pass
                context.Courses.Update(course); // Updates record in DB
                context.SaveChanges();
                return RedirectToAction("Manage", "Courses", new { id = course.CourseId });
            }
            else
            {
                // If validations don't pass                
                return View(course);
            }
        }

        [HttpGet]
        public IActionResult Manage(int id)
        {
            var course = context.Courses.Find(id);

            // Getting all the students that belong to a specific course
            ViewBag.CourseStudents = context.Students
                .Include(s => s.Course)
                .Where(s => s.CourseId == id)
                .OrderBy(c => c.Name).ToList();

            return View(course);
        }

        [HttpPost]
        public IActionResult SendConfirmationMessages(string CourseId)
        {

            // TODO: 
            // 1. Send a confirmation Flash Message (TempData) when SendConfirmationMessages was successful

            // Get a list of all the students in the course with status == ConfirmationMessageNotSent
            var studentsConfirmationNotSent = context.Students
                .Include(s => s.Course)
                .Where(s => s.CourseId == int.Parse(CourseId))
                .Where(s => s.StatusId == "ConfirmationMessageNotSent")
                .OrderBy(c => c.Name).ToList();

            Console.WriteLine("SendConfirmationMessages");
            // Iterates over the list of students that belong to the course and have status == ConfirmationMessageNotSent
            foreach (var student in studentsConfirmationNotSent)
            {
                // Sends email
                SendEmail(student.Email, student);

                // TODO: Change the student status to ConfirmationMessageSent
                // update student status here

            }







            return RedirectToAction("Manage", "Courses", new { id = CourseId });
        }

        // Methods
        public void SendEmail(string toAddress, Student student)
        {
            // Send Email to Students
            string fromAddress = "dflorez6.dev@gmail.com";
            // string toAddress = "dflorez6@gmail.com";
            string gmailAppPassword = "gibf edsp estc fisv "; // TODO: Remember to delete this once the assignment is graded

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromAddress, gmailAppPassword),
                EnableSsl = true,
            };
            
            var mailMessage = new MailMessage()
            {
                From = new MailAddress(fromAddress),
                Subject = "A test of emailing from C#",
                Body = $"<h1>Hello {student.Name}</h1>" + 
                $"<p>Your request to enroll in the course {student.Course.Name} in {student.Course.Room} starting {student.Course.Start.ToString("MM/dd/yyyy")} with instructor {student.Course.Instructor}.</p>" +
                $"<p>We are pleased to have you in the course if you could <a href='https://localhost:7031/Students/ConfirmEnrollment?courseId={student.CourseId}'>confirm your enrollment</a> as soon as possible that would be appreciate it!</p>" +
                $"<p>Sincerely,</p>" +
                $"<p>The Course Manager App</p>",
                IsBodyHtml = true
            };

            mailMessage.To.Add(toAddress);

            smtpClient.SendAsync(mailMessage, null);
        }

    }
}