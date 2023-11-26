/*  AppCookies.cs
    Assignment 2

    Revision History
    David Florez ID: 8820815, 2023.11.24: Created
*/
using Microsoft.AspNetCore.Http;
namespace assignment2.Models
{
    public class AppCookies
    {
        //====================
        // Props
        //====================
        private readonly IHttpContextAccessor _cookieContext;
        private string _cookieKey = "Kanut2023";

        //====================
        // Constructor
        //====================
        public AppCookies(IHttpContextAccessor cookieContext) => _cookieContext = cookieContext;

        //====================
        // Methods
        //====================
        // Sets cookie with timestamp
        public void SetCookie(string value, double expiration)
        {
            // Cookie values            
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(expiration),
                IsEssential = true
            };

            // Appends cookie
            _cookieContext.HttpContext.Response.Cookies.Append(_cookieKey, value, options);
        }

        public string ReturnCookie()
        {
            return _cookieContext.HttpContext.Request.Cookies[_cookieKey];
        }

    }
}
