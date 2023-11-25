/*  Student.cs
    Assignment 2

    Revision History
    David Florez ID: 8820815, 2023.11.24: Created
*/
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace assignment2.Models
{
    public class Student
    {
        //====================
        // Props
        //====================
        // Primary Key
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Name cannot be blank.")] // Annotation Validation
        public string Name { get; set; }

        [Required(ErrorMessage = "Email cannot be blank.")] // Annotation Validation
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email is not in the correct format (e.g. user@domain.com)")]
        public string Email { get; set; }

        //====================
        // Associations
        //====================
        // Foreign Key
        // Since I decided to use an actual entity to hold the values, and by design, a default status has been set on CoursesContext,
        // I removed the required annotation from this class in order to prevent failing ModelState Validations
        [ValidateNever]
        public string StatusId { get; set; }
        // Navigation property
        [ValidateNever] // We need to stop vaidation here
        public Status Status { get; set; }
        // int StatusCode { get; set; } = 0; // Defaults to 0 == "ConfirmationMessageNotSent"

        // Foreign Key
        [Required(ErrorMessage = "Course cannot be blank.")]
        public int CourseId { get; set; }
        // Navigation property
        [ValidateNever] // We need to stop vaidation here
        public Course Course { get; set; }

        //====================
        // Method
        //====================        

    }
}
