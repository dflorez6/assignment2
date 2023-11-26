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

            // Associations
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade); // Used to delete associated students records when deleting a course

            // Default value for StatusId in Student
            modelBuilder.Entity<Student>().Property(s => s.StatusId).HasDefaultValue("ConfirmationMessageNotSent");

            // Courses
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = 1,
                    Name = "Programming Microsoft Web Technologies",
                    Instructor = "Peter Mazdiak",
                    Start = new DateTime(2024, 01, 18, 14, 30, 0),
                    Room = "1C09"
                },
                new Course
                {
                    CourseId = 2,
                    Name = "Programming Concepts II",
                    Instructor = "Noman Atique",
                    Start = new DateTime(2024, 01, 15, 12, 0, 0),
                    Room = "4G15"
                },
                new Course
                {
                    CourseId = 3,
                    Name = "Distributed Application Development",
                    Instructor = "Peter Mazdiak",
                    Start = new DateTime(2023, 12, 19, 9, 0, 0),
                    Room = "3G19"
                }
            );

            // Students
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    Name = "Bart Simpson",
                    Email = "dflorez6@gmail.com",
                    CourseId = 1,
                    StatusId = "ConfirmationMessageNotSent"
                },
                new Student
                {
                    StudentId = 2,
                    Name = "Lisa Simpson",
                    Email = "dflorez6.dev@gmail.com",
                    CourseId = 1,
                    StatusId = "ConfirmationMessageNotSent"
                },
                new Student
                {
                    StudentId = 3,
                    Name = "Marge Simpson",
                    Email = "dflorez6@gmail.com",
                    CourseId = 2,
                    StatusId = "ConfirmationMessageNotSent"
                },
                new Student
                {
                    StudentId = 4,
                    Name = "Homer Simpson",
                    Email = "dflorez6.dev@gmail.com",
                    CourseId = 2,
                    StatusId = "ConfirmationMessageNotSent"
                },
                new Student
                {
                    StudentId = 5,
                    Name = "Maggie Simpson",
                    Email = "dflorez6@gmail.com",
                    CourseId = 3,
                    StatusId = "ConfirmationMessageNotSent"
                },
                new Student
                {
                    StudentId = 6,
                    Name = "Ned Flanders",
                    Email = "dflorez6.dev@gmail.com",
                    CourseId = 3,
                    StatusId = "ConfirmationMessageNotSent"
                }
            );

        }

    }
}
