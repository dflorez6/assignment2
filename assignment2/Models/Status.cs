/*  Status.cs
    Assignment 2

    Revision History
    David Florez ID: 8820815, 2023.11.24: Created
*/
using System.ComponentModel.DataAnnotations;

namespace assignment2.Models
{
    public class Status
    {
        //====================
        // Props
        //====================
        // Primary Key
        public string StatusId { get; set; }

        [Required(ErrorMessage = "Status name cannot be blank.")]
        public string StatusName { get; set; }

        public ICollection<Student> Students { get; set; }

        //====================
        // Methods
        //====================

    }
}
