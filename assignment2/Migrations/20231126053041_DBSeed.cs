using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace assignment2.Migrations
{
    /// <inheritdoc />
    public partial class DBSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Instructor", "Name", "Room", "Start" },
                values: new object[,]
                {
                    { 1, "Peter Mazdiak", "Programming Microsoft Web Technologies", "1C09", new DateTime(2024, 1, 18, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Noman Atique", "Programming Concepts II", "4G15", new DateTime(2024, 1, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Peter Mazdiak", "Distributed Application Development", "3G19", new DateTime(2023, 12, 19, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "CourseId", "Email", "Name", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, "dflorez6@gmail.com", "Bart Simpson", "ConfirmationMessageNotSent" },
                    { 2, 1, "dflorez6.dev@gmail.com", "Lisa Simpson", "ConfirmationMessageNotSent" },
                    { 3, 2, "dflorez6@gmail.com", "Marge Simpson", "ConfirmationMessageNotSent" },
                    { 4, 2, "dflorez6.dev@gmail.com", "Homer Simpson", "ConfirmationMessageNotSent" },
                    { 5, 3, "dflorez6@gmail.com", "Maggie Simpson", "ConfirmationMessageNotSent" },
                    { 6, 3, "dflorez6.dev@gmail.com", "Ned Flanders", "ConfirmationMessageNotSent" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);
        }
    }
}
