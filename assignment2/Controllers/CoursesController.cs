/*  CoursesController.cs
    Assignment 2

    Revision History
    David Florez ID: 8820815, 2023.11.24: Created
*/
using assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                return RedirectToAction("Index", "Courses");
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
                return RedirectToAction("Index", "Courses");
            }
            else
            {
                // If validations don't pass                
                return View(course);
            }
        }
                
        [HttpGet]
        public IActionResult Manage()
        {

            /*
             * Students that belong to a course
            var students = context.Students
                .Include(c = c.Course)
                .OrderBy(c => c.Name).ToList();
            */

            return View();
        }

    }
}

// TODO: VALIDATIONS
/*

To check validations
if (!ModelState.IsValid)
{
    // Model is not valid, handle the validation errors
    return View(model);
}

// Model is valid, continue with your processing

return RedirectToAction("Success");


*/