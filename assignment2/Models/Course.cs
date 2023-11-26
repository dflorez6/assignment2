/*  Courses.cs
    Assignment 2

    Revision History
    David Florez ID: 8820815, 2023.11.24: Created
*/
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace assignment2.Models
{
    public class Course
    {
        //====================
        // Props
        //====================
        // Primary Key
        public int CourseId { get; set; } 

        [Required(ErrorMessage = "Course name cannot be blank.")] // Annotation Validation
        public string Name { get; set; }

        [Required(ErrorMessage = "Course instructor cannot be blank.")] // Annotation Validation
        public string Instructor { get; set; }

        [Required(ErrorMessage = "Course start date cannot be blank.")] // Annotation Validation
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "Course room cannot be blank.")] // Annotation Validation
        [RegularExpression(@"^[\d][a-zA-Z][\d]{2}$", ErrorMessage = "Room is not in the correct format (e.g. 3G19)")]
        public string Room { get; set; }

        // Used to calculate student count per course
        public ICollection<Student> Students { get; set; }

    }
}
    