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
        // Cookies
        private readonly AppCookies _cookiesContext;

        // Constructor
        public HomeController(AppCookies cookiesContext)
        {
            _cookiesContext = cookiesContext; // Cookies
        }

        //====================
        // Actions
        //====================    
        public IActionResult Index()
        {
            // Set a cookie
            var cookie = _cookiesContext.ReturnCookie();

            // Checks if the cookie was not set, before setting up the vlaue
            if (string.IsNullOrEmpty(cookie))
            {
                _cookiesContext.SetCookie(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), 90);
            }

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