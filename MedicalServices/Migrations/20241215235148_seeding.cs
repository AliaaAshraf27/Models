using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalServices.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "2489d4fa-7e6c-4656-8ec8-faa53e70d6ce", "john.smith@hospital.com", true, false, null, "Dr. John Smith", null, null, "hashed_password_123", null, null, false, null, 0, null, false, "dr.john.smith" },
                    { 2, 0, "b33516f7-5497-452b-b4bf-b96e1f8230f0", "sarah.johnson@hospital.com", true, false, null, "Dr. Sarah Johnson", null, null, "hashed_password_456", null, null, false, null, 0, null, false, "dr.sarah.johnson" },
                    { 3, 0, "89884f5b-99b1-4f34-bf94-12678a90edf3", "ahmed.ali@hospital.com", true, false, null, "Dr. Ahmed Ali", null, null, "hashed_password_789", null, null, false, null, 0, null, false, "dr.ahmed.ali" },
                    { 4, 0, "c1d352f1-43c8-46e0-98eb-903a224d60de", "emily.brown@hospital.com", true, false, null, "Dr. Emily Brown", null, null, "hashed_password_101", null, null, false, null, 0, null, false, "dr.emily.brown" },
                    { 5, 0, "792f2336-09de-44e6-aa9b-e5d22b6d8b59", "william.davis@hospital.com", true, false, null, "Dr. William Davis", null, null, "hashed_password_102", null, null, false, null, 0, null, false, "dr.william.davis" },
                    { 6, 0, "9ca8f550-cb0b-49d4-ba41-8e3f3d4dfe21", "fatima.hassan@hospital.com", true, false, null, "Dr. Fatima Hassan", null, null, "hashed_password_103", null, null, false, null, 0, null, false, "dr.fatima.hassan" },
                    { 7, 0, "4e718e95-da95-4723-9b30-77c9a3d54b15", "jacob.wilson@hospital.com", true, false, null, "Dr. Jacob Wilson", null, null, "hashed_password_104", null, null, false, null, 0, null, false, "dr.jacob.wilson" },
                    { 8, 0, "b7f9a62a-131b-4638-8ac3-71322751e320", "sophia.martinez@hospital.com", true, false, null, "Dr. Sophia Martinez", null, null, "hashed_password_105", null, null, false, null, 0, null, false, "dr.sophia.martinez" },
                    { 9, 0, "e31ae39c-20fa-43ea-8a24-034e7cb0335c", "ethan.thompson@hospital.com", true, false, null, "Dr. Ethan Thompson", null, null, "hashed_password_106", null, null, false, null, 0, null, false, "dr.ethan.thompson" },
                    { 10, 0, "65774e83-f376-4fc1-8199-412b8267ea74", "ava.garcia@hospital.com", true, false, null, "Dr. Ava Garcia", null, null, "hashed_password_107", null, null, false, null, 0, null, false, "dr.ava.garcia" },
                    { 11, 0, "6af743de-f174-49e1-b7c0-d8506c051731", "michael.lee@hospital.com", true, false, null, "Dr. Michael Lee", null, null, "hashed_password_108", null, null, false, null, 0, null, false, "dr.michael.lee" },
                    { 12, 0, "cf951baf-e473-40cc-94a4-a47b2e9a5b23", "olivia.rodriguez@hospital.com", true, false, null, "Dr. Olivia Rodriguez", null, null, "hashed_password_109", null, null, false, null, 0, null, false, "dr.olivia.rodriguez" },
                    { 13, 0, "1b9204c9-2f2f-46b2-b7d4-482225f4eae3", "benjamin.white@hospital.com", true, false, null, "Dr. Benjamin White", null, null, "hashed_password_110", null, null, false, null, 0, null, false, "dr.benjamin.white" },
                    { 14, 0, "f8882703-d789-4635-8cc4-e985ed79b0f1", "isabella.hall@hospital.com", true, false, null, "Dr. Isabella Hall", null, null, "hashed_password_111", null, null, false, null, 0, null, false, "dr.isabella.hall" },
                    { 15, 0, "bdd3401c-7ebf-4ccc-904f-5cf1bf51c539", "daniel.young@hospital.com", true, false, null, "Dr. Daniel Young", null, null, "hashed_password_112", null, null, false, null, 0, null, false, "dr.daniel.young" },
                    { 16, 0, "b5b11fe7-78bb-4f16-9fc4-62dd688c96d6", "mia.king@hospital.com", true, false, null, "Dr. Mia King", null, null, "hashed_password_113", null, null, false, null, 0, null, false, "dr.mia.king" },
                    { 17, 0, "af1b23c3-6cb6-4409-8ff0-97582ca54234", "james.wright@hospital.com", true, false, null, "Dr. James Wright", null, null, "hashed_password_114", null, null, false, null, 0, null, false, "dr.james.wright" },
                    { 18, 0, "07684414-7c55-4c0f-b331-928d4a18cc6a", "amelia.scott@hospital.com", true, false, null, "Dr. Amelia Scott", null, null, "hashed_password_115", null, null, false, null, 0, null, false, "dr.amelia.scott" },
                    { 19, 0, "b18444c6-cb4d-4165-af4d-7b3915f76d96", "lucas.green@hospital.com", true, false, null, "Dr. Lucas Green", null, null, "hashed_password_116", null, null, false, null, 0, null, false, "dr.lucas.green" },
                    { 20, 0, "57431188-af4e-4f0a-bd76-e7f74129e91b", "charlotte.adams@hospital.com", true, false, null, "Dr. Charlotte Adams", null, null, "hashed_password_117", null, null, false, null, 0, null, false, "dr.charlotte.adams" },
                    { 21, 0, "175dfedf-9acb-4c56-b1b8-ca7e6aba2b57", "henry.baker@hospital.com", true, false, null, "Dr. Henry Baker", null, null, "hashed_password_118", null, null, false, null, 0, null, false, "dr.henry.baker" },
                    { 22, 0, "88e4178b-bfad-410f-ac79-a73243de0f91", "grace.nelson@hospital.com", true, false, null, "Dr. Grace Nelson", null, null, "hashed_password_119", null, null, false, null, 0, null, false, "dr.grace.nelson" },
                    { 23, 0, "040ea589-2df2-4cc9-b0d6-068600cceaac", "elijah.carter@hospital.com", true, false, null, "Dr. Elijah Carter", null, null, "hashed_password_120", null, null, false, null, 0, null, false, "dr.elijah.carter" },
                    { 24, 0, "834e8123-8b74-49c3-8fb1-c7e1ca6fe003", "lily.mitchell@hospital.com", true, false, null, "Dr. Lily Mitchell", null, null, "hashed_password_121", null, null, false, null, 0, null, false, "dr.lily.mitchell" }
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
                columns: new[] { "Id", "Address", "Experience", "Gender", "SpecializationId" },
                values: new object[,]
                {
                    { 1, "123 Heart St", "10 years", 0, 1 },
                    { 2, "456 Pulse Ave", "8 years", 1, 1 },
                    { 3, "789 Artery Blvd", "12 years", 0, 1 },
                    { 4, "321 Skin Lane", "7 years", 1, 2 },
                    { 5, "654 Acne Dr", "6 years", 0, 2 },
                    { 6, "987 Derma Ct", "9 years", 1, 2 },
                    { 7, "123 Brain Ave", "15 years", 0, 3 },
                    { 8, "456 Neuron Blvd", "11 years", 1, 3 },
                    { 9, "789 Spine Dr", "13 years", 0, 3 },
                    { 10, "321 Bone St", "14 years", 0, 4 },
                    { 11, "654 Joint Ave", "8 years", 1, 4 },
                    { 12, "987 Fracture Rd", "10 years", 0, 4 },
                    { 13, "123 Kids Ln", "5 years", 1, 5 },
                    { 14, "456 Baby Blvd", "6 years", 0, 5 },
                    { 15, "789 Child Ct", "8 years", 1, 5 },
                    { 16, "321 Cancer St", "12 years", 0, 6 },
                    { 17, "654 Tumor Blvd", "10 years", 1, 6 },
                    { 18, "987 Chemo Rd", "11 years", 0, 6 },
                    { 19, "123 Mind St", "9 years", 1, 7 },
                    { 20, "456 Emotion Ave", "8 years", 0, 7 },
                    { 21, "789 Therapy Ct", "7 years", 1, 7 },
                    { 22, "321 Xray Ln", "13 years", 0, 8 },
                    { 23, "654 MRI Blvd", "12 years", 1, 8 },
                    { 24, "987 CT Scan Rd", "14 years", 0, 8 }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
