using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalServices.Migrations
{
    /// <inheritdoc />
    public partial class updateBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProblemDescription",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "55aef1ff-80fd-4b6b-99e8-54d951efae09");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f5d2f7c9-087f-47fc-b5c5-a9df7088d46d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "2795a17e-294a-47a3-97ad-920d63668542");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "62185908-cac3-49aa-abb0-50a6e93b09c7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "12334c39-1925-4fcb-b779-3a35708e71a9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "4275868b-b78f-4949-8b4e-0cbd57b47c18");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "e666c731-4f58-40dc-83ed-5029fcb5b8e8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "9fe47a53-c9bd-4b82-a206-daaa73accdf4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "4998a50c-7d45-483f-9fd2-17ca5c426a21");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "d09fae34-67f9-44e4-a669-8477f8bca967");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "15f12faf-e225-4652-8083-a8fae63d044d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "83944762-eccf-416f-8c40-0737bd93b2d6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "3b3603c1-eabf-45f6-a4d0-f63b461a449f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "8a4145e5-7466-469b-b1c1-922f3f1e228d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "cf7a6cb8-1596-443c-8862-13d535b409ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "f870f3d1-c434-4c4c-9750-3787844d4199");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "abafb72c-31ed-4518-bc14-d0de9cd50d15");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "cad58286-d314-4777-955d-b473e729d499");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "60158783-5f04-4335-b6a8-324f3a1374b1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "5bf9f40e-c06e-4085-accd-ae48d39547ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "56487dfc-9a9d-4008-a466-1ecf70ab7e62");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "5164d836-e1cc-4d51-8629-a9e99f3868f7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                column: "ConcurrencyStamp",
                value: "523b2f22-8487-47ce-9032-0757a4788d50");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                column: "ConcurrencyStamp",
                value: "a8321287-874c-4196-8cdc-5d131529efe1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProblemDescription",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "30fc1db0-da55-460a-86bd-b31a0638f1b2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9f395456-85a9-42b6-a2d8-bd132d482d77");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "89133149-88b3-42ae-97ae-b7f52b9c070d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "af1cb60e-b1c9-44fa-ae29-fe0f7f9f91e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "1ee15471-9e67-41bc-91c3-e962f54afc2b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "d796a5e8-d72b-4f6c-89d9-5a3d8159668d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "5f3ed950-c1b6-45ae-bde7-227fb3b828e5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "355f4d75-2b04-4289-a4e8-c9cfbaf041ae");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "60f2d044-3b37-4e4b-ad77-c158ab2e99e9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "69db0949-fdd4-4dd2-9070-5e3a29d5a7f3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "0d027996-fa46-4fe9-a069-6999cf3715c4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "8f5f8652-3219-4b05-b0eb-4a132dc987ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "e49a0129-9132-4c36-9e5d-fc7c57df74f5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "da1f2d6a-60b8-4dc8-beeb-3639f0df6b83");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "56fda0fd-9ae8-4382-94df-a310016519b6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "9f0716b3-7f32-4feb-b338-b0d3c18a13c9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "f5b68bca-d195-449f-a1bd-eca358bc19e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "b5125f79-7ce5-4d02-8850-203f2320a65a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "8dc9922b-8db6-41bd-9093-447fecc02d88");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "299edfcf-1e5b-4ce9-b732-504fabfaf1e7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "5c0eb1ff-06df-4bb3-87d9-76c53793856d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "8ee1d9f6-ce2b-4453-8e5b-958acaa083ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                column: "ConcurrencyStamp",
                value: "16840444-8e3e-45c7-b638-061079605e60");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                column: "ConcurrencyStamp",
                value: "34178884-9f0f-40b8-961e-085856e7f83d");
        }
    }
}
