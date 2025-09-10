using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagment.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigationInEnrollments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CoursesId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentsId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_CoursesId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_StudentsId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Enrollments");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseID",
                table: "Enrollments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_CourseID",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments");

            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CoursesId",
                table: "Enrollments",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentsId",
                table: "Enrollments",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CoursesId",
                table: "Enrollments",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentsId",
                table: "Enrollments",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
