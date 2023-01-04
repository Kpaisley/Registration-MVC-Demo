using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseRegistrationWebPage.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Course_Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Course_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    First_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Last_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Course_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Instructors_Courses_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    First_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Last_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Course_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_Courses_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Course_Name", "Course_Number", "Description" },
                values: new object[,]
                {
                    { 1, "Dark Arts Defense", "T0504", "Students will learn how to defend themselves from dark magic" },
                    { 2, "Potions", "T0506", "Students will learn how to create potions" },
                    { 3, "Animal Care", "T0509", "Students will learn how to care for magic animals" },
                    { 4, "Transfiguration", "T0510", "Students will learn how to transform themselves" },
                    { 5, "Herbology", "T0512", "Students will study the medical properties of herbs" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "ID", "Course_ID", "Email", "First_Name", "Last_Name" },
                values: new object[,]
                {
                    { 10, 2, "S.Snape@gmail.com", "Severus", "Snape" },
                    { 11, 1, "L.Lupin@gmail.com", "Remus", "Lupin" },
                    { 12, 3, "R.Hagrid@gmail.com", "Rubeus", "Hagrid" },
                    { 13, 4, "M.McGonagall@gmail.com", "Minerva", "McGonagall" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "Course_ID", "Email", "First_Name", "Last_Name", "Phone" },
                values: new object[,]
                {
                    { 100, 2, "H.Potter@gmail.com", "Harry", "Potter", "123-456-7899" },
                    { 101, 3, "R.Weasley@gmail.com", "Ron", "Weasley", "987-654-3211" },
                    { 102, 2, "H.Granger@gmail.com", "Hermione", "Granger", "963-852-7411" },
                    { 103, 1, "D.Malfoy@gmail.com", "Draco", "Malfoy", "741-852-9633" },
                    { 104, 4, "N.Longbottom@gmail.com", "Neville", "Longbottom", "852-963-7532" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Course_ID",
                table: "Instructors",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Course_ID",
                table: "Students",
                column: "Course_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
