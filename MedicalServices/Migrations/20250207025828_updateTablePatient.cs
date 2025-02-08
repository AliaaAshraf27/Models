using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalServices.Migrations
{
    /// <inheritdoc />
    public partial class updateTablePatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0b78f908-eed2-4a23-92a6-2113a3bf2700");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f92a0a20-4634-49f4-ad24-9f33fc3be90e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f64a6827-8bb8-44ff-83dd-acd96ca925b7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "08d7b037-83ca-455c-a480-c93de93995fc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "7ca3da12-16a6-4853-b2fa-cf81e79e33bd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "9127add2-34e7-4d96-a923-ce5958fcb439");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "4e677c85-e6e8-4fe8-8c7d-a8d7d7d8d50c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "efc32885-3b07-4af1-af00-927420fe2938");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "6ab3eb91-3aac-411c-bf92-bf53c5f8408f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "ab34a42f-32fc-4609-bdd2-295fbca46a4b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "1d1c9910-a16d-4709-90e5-93b4dffabf56");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "0e22f3b4-a959-4f30-88f9-c9b6040431aa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "a4ea8a73-e6f9-4566-8bc5-280671d769fd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "3f3cfc1c-604e-415b-9dfd-a399a95f48fa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "004e9e57-719a-44fc-a394-819b4f7727ea");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "36b05fa3-2292-44d9-87d1-06243249ba56");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "5152ff56-7dbc-4a9a-9ec6-907ae593cbc9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "a1b5b49c-1f68-40dc-82bf-91583683dc08");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "85597705-662c-4e8d-b067-2cff6103fb95");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "8a6a4160-82e7-49c0-ad81-eb8dd1bde740");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "b7c9797c-0155-4472-9d60-3f797abd564b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "7042a53a-7337-4364-b116-65cb1ac4c7e5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                column: "ConcurrencyStamp",
                value: "66ebb2f5-05a5-48d8-8723-b577d9593e99");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                column: "ConcurrencyStamp",
                value: "363f9835-447a-495c-9d66-9e0e646c4e6c");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "patientName",
                table: "Patients");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f04df9f5-a9f6-40fb-bc0f-73c19fb64c72");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "aa0e045e-a003-49e2-8b78-e0ea0fd86a04");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c40c1958-b6ce-4352-944d-5322b8b27606");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "8b0f072a-5204-4f0b-b610-3cba2f7efbe3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "cc2b40b5-a124-4577-8414-5136a87c04e8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "7f3ae4d6-21e2-4679-95fe-bec0935e11a6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "1534bea2-1f8f-4abf-8095-952df07a655c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "c981548d-79e8-4931-8121-eb434fc910d9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "cf626b50-7ca0-46e2-b1bd-a3c5ae2b9389");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "c5cfcab9-9522-4111-97bc-7ff99a113c2d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "13df3937-0bd6-47f1-839b-6dea578fe63b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "a8c89030-d897-4bf7-aa8e-175cdbd899b0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "1f3b87a9-7c15-413f-91fb-d3f9ac2671b0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "9e562988-53ba-46b5-938e-cce3a4f2c56f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "1e78e0a3-49d5-44c1-9362-730a9601b5ff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "f187588b-5f60-480b-a7a9-8f93588c1db4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "bcece096-dcd6-4e12-9657-2f3d61201e76");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "d31fa845-eac5-40b3-9cc7-26f618e941de");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "5c1bcb0f-9721-4481-a25d-d78c9c40ebe0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "71c46c04-f1a5-4116-8ef7-48b80a97a207");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "2f8f5b93-8dcc-4baa-80de-b6ca0eb95e0f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "b0840a29-d397-4571-817a-5ac8ca8d326d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                column: "ConcurrencyStamp",
                value: "467fd07e-8d18-4db7-987b-3dd2accef3d3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                column: "ConcurrencyStamp",
                value: "13b53b86-8a12-46be-8046-fb0937ec1c5b");
        }
    }
}
