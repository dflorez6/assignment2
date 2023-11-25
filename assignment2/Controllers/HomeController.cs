/*  HomeController.cs
    Assignment 2

    Revision History
    David Florez ID: 8820815, 2023.11.24: Created
*/
using assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace assignment2.Controllers
{
    public class HomeController : Controller
    {
        // DB Context
        private CoursesContext context { get; set; }
        public HomeController(CoursesContext ctx) => context = ctx;

        //====================
        // Actions
        //====================    
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}