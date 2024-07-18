using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorClinicManagerWebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "Experience", "Name", "Phone", "Speciality" },
                values: new object[,]
                {
                    { 101, 15, "tonny", "9876543321", "Multispecialist" },
                    { 102, 3, "stephen-strange", "9988776655", "Neuro" },
                    { 103, 5, "Bruce-Banner", "2133443422", "Neuro" },
                    { 104, 1, "peter-parker", "765790809438", "Webspecialist" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
