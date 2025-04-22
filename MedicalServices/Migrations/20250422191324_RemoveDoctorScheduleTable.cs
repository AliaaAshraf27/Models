using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalServices.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDoctorScheduleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorSchedules");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AvailableAppointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AvailableAppointments");

            migrationBuilder.CreateTable(
                name: "DoctorSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSchedules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
             
            migrationBuilder.InsertData(
                table: "DoctorSchedules",
                columns: new[] { "Id", "Date", "DoctorId", "Name", "Price", "TimeEnd", "TimeStart" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 12, 16), 1, "Morning Shift", 100f, new DateTime(2024, 12, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateOnly(2024, 12, 16), 1, "Evening Shift", 120f, new DateTime(2024, 12, 16, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 16, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateOnly(2024, 12, 17), 2, "Morning Shift", 110f, new DateTime(2024, 12, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 17, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateOnly(2024, 12, 17), 2, "Evening Shift", 130f, new DateTime(2024, 12, 17, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 17, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateOnly(2024, 12, 18), 3, "Morning Shift", 90f, new DateTime(2024, 12, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateOnly(2024, 12, 18), 3, "Evening Shift", 150f, new DateTime(2024, 12, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 18, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateOnly(2024, 12, 19), 4, "Morning Shift", 95f, new DateTime(2024, 12, 19, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 19, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateOnly(2024, 12, 19), 4, "Evening Shift", 125f, new DateTime(2024, 12, 19, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 19, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateOnly(2024, 12, 20), 5, "Morning Shift", 110f, new DateTime(2024, 12, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateOnly(2024, 12, 20), 5, "Evening Shift", 140f, new DateTime(2024, 12, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 20, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateOnly(2024, 12, 21), 6, "Morning Shift", 115f, new DateTime(2024, 12, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateOnly(2024, 12, 21), 6, "Evening Shift", 125f, new DateTime(2024, 12, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateOnly(2024, 12, 22), 7, "Morning Shift", 105f, new DateTime(2024, 12, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateOnly(2024, 12, 22), 7, "Evening Shift", 135f, new DateTime(2024, 12, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateOnly(2024, 12, 23), 8, "Morning Shift", 100f, new DateTime(2024, 12, 23, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateOnly(2024, 12, 23), 8, "Evening Shift", 120f, new DateTime(2024, 12, 23, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 15, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateOnly(2024, 12, 24), 9, "Morning Shift", 125f, new DateTime(2024, 12, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateOnly(2024, 12, 24), 9, "Evening Shift", 135f, new DateTime(2024, 12, 24, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateOnly(2024, 12, 25), 10, "Morning Shift", 110f, new DateTime(2024, 12, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateOnly(2024, 12, 25), 10, "Evening Shift", 130f, new DateTime(2024, 12, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateOnly(2024, 12, 26), 11, "Morning Shift", 115f, new DateTime(2024, 12, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateOnly(2024, 12, 26), 11, "Evening Shift", 125f, new DateTime(2024, 12, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateOnly(2024, 12, 27), 12, "Morning Shift", 120f, new DateTime(2024, 12, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateOnly(2024, 12, 27), 12, "Evening Shift", 140f, new DateTime(2024, 12, 27, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 27, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateOnly(2024, 12, 28), 13, "Morning Shift", 110f, new DateTime(2024, 12, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateOnly(2024, 12, 28), 13, "Evening Shift", 130f, new DateTime(2024, 12, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 28, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateOnly(2024, 12, 28), 14, "Morning Shift", 110f, new DateTime(2024, 12, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateOnly(2024, 12, 28), 14, "Evening Shift", 130f, new DateTime(2024, 12, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 28, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateOnly(2024, 12, 29), 15, "Morning Shift", 115f, new DateTime(2024, 12, 29, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new DateOnly(2024, 12, 29), 15, "Evening Shift", 135f, new DateTime(2024, 12, 29, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 31, new DateOnly(2024, 12, 30), 16, "Morning Shift", 120f, new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, new DateOnly(2024, 12, 30), 16, "Evening Shift", 140f, new DateTime(2024, 12, 30, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, new DateOnly(2024, 12, 31), 17, "Morning Shift", 110f, new DateTime(2024, 12, 31, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, new DateOnly(2024, 12, 31), 17, "Evening Shift", 130f, new DateTime(2024, 12, 31, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 35, new DateOnly(2025, 1, 1), 18, "Morning Shift", 125f, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, new DateOnly(2025, 1, 1), 18, "Evening Shift", 145f, new DateTime(2025, 1, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, new DateOnly(2025, 1, 2), 19, "Morning Shift", 115f, new DateTime(2025, 1, 2, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 38, new DateOnly(2025, 1, 2), 19, "Evening Shift", 135f, new DateTime(2025, 1, 2, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 16, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 39, new DateOnly(2025, 1, 3), 20, "Morning Shift", 120f, new DateTime(2025, 1, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, new DateOnly(2025, 1, 3), 20, "Evening Shift", 140f, new DateTime(2025, 1, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, new DateOnly(2025, 1, 4), 21, "Morning Shift", 125f, new DateTime(2025, 1, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, new DateOnly(2025, 1, 4), 21, "Evening Shift", 145f, new DateTime(2025, 1, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, new DateOnly(2025, 1, 5), 22, "Morning Shift", 110f, new DateTime(2025, 1, 5, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 44, new DateOnly(2025, 1, 5), 22, "Evening Shift", 130f, new DateTime(2025, 1, 5, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 45, new DateOnly(2025, 1, 6), 23, "Morning Shift", 115f, new DateTime(2025, 1, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, new DateOnly(2025, 1, 6), 23, "Evening Shift", 135f, new DateTime(2025, 1, 6, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 6, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, new DateOnly(2024, 12, 30), 24, "Morning Shift", 120f, new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, new DateOnly(2024, 12, 30), 24, "Evening Shift", 140f, new DateTime(2024, 12, 30, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 16, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_DoctorId",
                table: "DoctorSchedules",
                column: "DoctorId");
        }
    }
}
