using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalServices.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceInAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "AvailableAppointments",
                newName: "TimeStart");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "AvailableAppointments",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "TimeEnd",
                table: "AvailableAppointments",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "AvailableAppointments");

            migrationBuilder.DropColumn(
                name: "TimeEnd",
                table: "AvailableAppointments");

            migrationBuilder.RenameColumn(
                name: "TimeStart",
                table: "AvailableAppointments",
                newName: "Time");

        }
    }
}
