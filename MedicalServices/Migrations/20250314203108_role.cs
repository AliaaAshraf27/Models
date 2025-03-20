﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalServices.Migrations
{
    /// <inheritdoc />
    public partial class role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    SenderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    SenderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    patientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    MedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    Focus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableAppointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "PatientFavoriteDoctors",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFavoriteDoctors", x => new { x.PatientId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_PatientFavoriteDoctors_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientFavoriteDoctors_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeCount = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForHimSelf = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AvailableAppointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "AvailableAppointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "b7148bc8-64c7-424b-8fa5-15e453b58121", "john.smith@hospital.com", true, false, null, "Dr. John Smith", null, null, "hashed_password_123", null, null, false, null, 0, null, false, "dr.john.smith" },
                    { 2, 0, "636c3f7b-f110-4abb-8420-41e92b5bf4da", "sarah.johnson@hospital.com", true, false, null, "Dr. Sarah Johnson", null, null, "hashed_password_456", null, null, false, null, 0, null, false, "dr.sarah.johnson" },
                    { 3, 0, "57a237df-db53-49b7-bb4c-c57f17ac2627", "ahmed.ali@hospital.com", true, false, null, "Dr. Ahmed Ali", null, null, "hashed_password_789", null, null, false, null, 0, null, false, "dr.ahmed.ali" },
                    { 4, 0, "5ab84e2a-a5af-41f2-9b17-2e94f7c5a2ae", "emily.brown@hospital.com", true, false, null, "Dr. Emily Brown", null, null, "hashed_password_101", null, null, false, null, 0, null, false, "dr.emily.brown" },
                    { 5, 0, "8bb135da-e939-4f9a-a514-d0f5bbe2bcc1", "william.davis@hospital.com", true, false, null, "Dr. William Davis", null, null, "hashed_password_102", null, null, false, null, 0, null, false, "dr.william.davis" },
                    { 6, 0, "ad6bd8a6-bc01-4c46-a81c-dd3ec83e2b59", "fatima.hassan@hospital.com", true, false, null, "Dr. Fatima Hassan", null, null, "hashed_password_103", null, null, false, null, 0, null, false, "dr.fatima.hassan" },
                    { 7, 0, "8122bb07-7ead-4048-99a1-4e2cd05c9ae6", "jacob.wilson@hospital.com", true, false, null, "Dr. Jacob Wilson", null, null, "hashed_password_104", null, null, false, null, 0, null, false, "dr.jacob.wilson" },
                    { 8, 0, "5cd1240a-7d53-42b6-af47-04bb905e7188", "sophia.martinez@hospital.com", true, false, null, "Dr. Sophia Martinez", null, null, "hashed_password_105", null, null, false, null, 0, null, false, "dr.sophia.martinez" },
                    { 9, 0, "0178d4c6-4dfc-48ae-838c-5e56b52549b8", "ethan.thompson@hospital.com", true, false, null, "Dr. Ethan Thompson", null, null, "hashed_password_106", null, null, false, null, 0, null, false, "dr.ethan.thompson" },
                    { 10, 0, "9fd769e2-6e97-437c-b665-a84b24f0b9c5", "ava.garcia@hospital.com", true, false, null, "Dr. Ava Garcia", null, null, "hashed_password_107", null, null, false, null, 0, null, false, "dr.ava.garcia" },
                    { 11, 0, "459282cd-57da-463e-ba05-2d2849d98418", "michael.lee@hospital.com", true, false, null, "Dr. Michael Lee", null, null, "hashed_password_108", null, null, false, null, 0, null, false, "dr.michael.lee" },
                    { 12, 0, "d5a63458-6f4a-4901-9154-c7509641ad5e", "olivia.rodriguez@hospital.com", true, false, null, "Dr. Olivia Rodriguez", null, null, "hashed_password_109", null, null, false, null, 0, null, false, "dr.olivia.rodriguez" },
                    { 13, 0, "489fd30e-cca6-463d-9278-da6e54fbefe2", "benjamin.white@hospital.com", true, false, null, "Dr. Benjamin White", null, null, "hashed_password_110", null, null, false, null, 0, null, false, "dr.benjamin.white" },
                    { 14, 0, "8971fe25-d683-455c-9c40-0384f3eec612", "isabella.hall@hospital.com", true, false, null, "Dr. Isabella Hall", null, null, "hashed_password_111", null, null, false, null, 0, null, false, "dr.isabella.hall" },
                    { 15, 0, "fd7b9c13-29e8-4858-af5c-fdf6a85ac046", "daniel.young@hospital.com", true, false, null, "Dr. Daniel Young", null, null, "hashed_password_112", null, null, false, null, 0, null, false, "dr.daniel.young" },
                    { 16, 0, "87d615c5-b5c9-4f24-a678-8d318e06e60f", "mia.king@hospital.com", true, false, null, "Dr. Mia King", null, null, "hashed_password_113", null, null, false, null, 0, null, false, "dr.mia.king" },
                    { 17, 0, "73c11c27-08aa-4b7e-afde-7bb7ecb3a1f6", "james.wright@hospital.com", true, false, null, "Dr. James Wright", null, null, "hashed_password_114", null, null, false, null, 0, null, false, "dr.james.wright" },
                    { 18, 0, "5a293314-1be0-47e8-a727-049f2b1b8b85", "amelia.scott@hospital.com", true, false, null, "Dr. Amelia Scott", null, null, "hashed_password_115", null, null, false, null, 0, null, false, "dr.amelia.scott" },
                    { 19, 0, "c654a97a-d691-46bd-bad5-b172643278b8", "lucas.green@hospital.com", true, false, null, "Dr. Lucas Green", null, null, "hashed_password_116", null, null, false, null, 0, null, false, "dr.lucas.green" },
                    { 20, 0, "1f9170e1-7b80-463a-bbdb-7088281bdae4", "charlotte.adams@hospital.com", true, false, null, "Dr. Charlotte Adams", null, null, "hashed_password_117", null, null, false, null, 0, null, false, "dr.charlotte.adams" },
                    { 21, 0, "1bbdf0d6-6f23-44c7-88c8-4258d3ddf480", "henry.baker@hospital.com", true, false, null, "Dr. Henry Baker", null, null, "hashed_password_118", null, null, false, null, 0, null, false, "dr.henry.baker" },
                    { 22, 0, "ed4e2caf-0ba7-4680-af8c-430d0c1b6e4f", "grace.nelson@hospital.com", true, false, null, "Dr. Grace Nelson", null, null, "hashed_password_119", null, null, false, null, 0, null, false, "dr.grace.nelson" },
                    { 23, 0, "37e4de12-f448-4c05-b306-bfe7c0fd1d2d", "elijah.carter@hospital.com", true, false, null, "Dr. Elijah Carter", null, null, "hashed_password_120", null, null, false, null, 0, null, false, "dr.elijah.carter" },
                    { 24, 0, "d481472b-4d6f-4f50-ac44-3511ba039a03", "lily.mitchell@hospital.com", true, false, null, "Dr. Lily Mitchell", null, null, "hashed_password_121", null, null, false, null, 0, null, false, "dr.lily.mitchell" }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cardiology" },
                    { 2, "Dermatology" },
                    { 3, "Neurology" },
                    { 4, "Orthopedics" },
                    { 5, "Pediatrics" },
                    { 6, "Oncology" },
                    { 7, "Psychiatry" },
                    { 8, "Radiology" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "Experience", "Focus", "Gender", "SpecializationId" },
                values: new object[,]
                {
                    { 1, "123 Heart St", "10 years", null, 0, 1 },
                    { 2, "456 Pulse Ave", "8 years", null, 1, 1 },
                    { 3, "789 Artery Blvd", "12 years", null, 0, 1 },
                    { 4, "321 Skin Lane", "7 years", null, 1, 2 },
                    { 5, "654 Acne Dr", "6 years", null, 0, 2 },
                    { 6, "987 Derma Ct", "9 years", null, 1, 2 },
                    { 7, "123 Brain Ave", "15 years", null, 0, 3 },
                    { 8, "456 Neuron Blvd", "11 years", null, 1, 3 },
                    { 9, "789 Spine Dr", "13 years", null, 0, 3 },
                    { 10, "321 Bone St", "14 years", null, 0, 4 },
                    { 11, "654 Joint Ave", "8 years", null, 1, 4 },
                    { 12, "987 Fracture Rd", "10 years", null, 0, 4 },
                    { 13, "123 Kids Ln", "5 years", null, 1, 5 },
                    { 14, "456 Baby Blvd", "6 years", null, 0, 5 },
                    { 15, "789 Child Ct", "8 years", null, 1, 5 },
                    { 16, "321 Cancer St", "12 years", null, 0, 6 },
                    { 17, "654 Tumor Blvd", "10 years", null, 1, 6 },
                    { 18, "987 Chemo Rd", "11 years", null, 0, 6 },
                    { 19, "123 Mind St", "9 years", null, 1, 7 },
                    { 20, "456 Emotion Ave", "8 years", null, 0, 7 },
                    { 21, "789 Therapy Ct", "7 years", null, 1, 7 },
                    { 22, "321 Xray Ln", "13 years", null, 0, 8 },
                    { 23, "654 MRI Blvd", "12 years", null, 1, 8 },
                    { 24, "987 CT Scan Rd", "14 years", null, 0, 8 }
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableAppointments_DoctorId",
                table: "AvailableAppointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AppointmentId",
                table: "Bookings",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DoctorId",
                table: "Bookings",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PatientId",
                table: "Bookings",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializationId",
                table: "Doctors",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_DoctorId",
                table: "DoctorSchedules",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_BookingId",
                table: "MedicalRecords",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFavoriteDoctors_DoctorId",
                table: "PatientFavoriteDoctors",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DoctorId",
                table: "Reviews",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PatientId",
                table: "Reviews",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "DoctorSchedules");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PatientFavoriteDoctors");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "AvailableAppointments");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
