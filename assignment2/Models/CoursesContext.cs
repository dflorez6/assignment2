/*  CoursesContext.cs
    Assignment 2

    Revision History
    David Florez ID: 8820815, 2023.11.24: Created
*/
using Microsoft.EntityFrameworkCore;

namespace assignment2.Models
{
    public class CoursesContext : DbContext
    {
        //====================
        // DB Tables
        //====================
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Status> Statuses { get; set; }

        //====================
        // Constructor
        //====================
        public CoursesContext(DbContextOptions<CoursesContext> options) : base(options) { }

        //====================
        // DB Seed
        //====================
        // Adds seed values to DB on Model creation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Statuses
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "ConfirmationMessageNotSent", StatusName = "Confirmation Message Not Sent" },
                new Status { StatusId = "ConfirmationMessageSent", StatusName = "Confirmation Message Sent" },
                new Status { StatusId = "EnrollmentConfirmed", StatusName = "Enrollment Confirmed" },
                new Status { StatusId = "EnrollmentDeclined", StatusName = "Enrollment Declined" }
            );

            // Courses

            // Students

            // Default value for StatusId in Student
            modelBuilder.Entity<Student>().Property(s => s.StatusId).HasDefaultValue("ConfirmationMessageNotSent");
        }

    }
}
