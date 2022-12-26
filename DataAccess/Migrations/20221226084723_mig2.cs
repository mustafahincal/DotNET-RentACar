using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentDate",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 40, 176, 21, 232, 250, 188, 73, 255, 168, 137, 214, 65, 148, 147, 219, 12, 82, 108, 151, 22, 195, 127, 225, 142, 49, 122, 0, 81, 204, 57, 34, 236, 206, 189, 255, 88, 46, 46, 4, 24, 143, 104, 225, 9, 97, 17, 56, 34, 196, 218, 149, 57, 222, 17, 203, 163, 243, 18, 173, 108, 176, 156, 138, 25 }, new byte[] { 10, 107, 133, 85, 158, 85, 188, 85, 225, 232, 178, 220, 33, 209, 156, 173, 186, 90, 8, 248, 54, 60, 83, 27, 153, 10, 146, 88, 136, 1, 213, 170, 233, 183, 235, 84, 104, 198, 183, 194, 172, 132, 55, 135, 131, 196, 96, 182, 235, 205, 87, 72, 160, 160, 135, 241, 139, 252, 134, 36, 175, 127, 35, 2, 186, 243, 17, 141, 169, 197, 115, 17, 120, 162, 179, 67, 236, 19, 203, 22, 221, 205, 28, 215, 218, 76, 57, 95, 178, 94, 181, 34, 234, 209, 130, 171, 209, 87, 138, 23, 35, 78, 92, 211, 120, 54, 93, 254, 8, 199, 80, 212, 138, 150, 12, 28, 51, 26, 133, 57, 221, 91, 93, 100, 129, 41, 140, 187 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Rentals");

            migrationBuilder.AddColumn<DateTime>(
                name: "RentDate",
                table: "Rentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Rentals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 83, 92, 227, 114, 120, 159, 204, 83, 132, 108, 70, 46, 7, 5, 24, 225, 50, 247, 37, 211, 36, 141, 74, 163, 152, 186, 174, 172, 134, 83, 97, 33, 98, 20, 181, 176, 235, 36, 27, 158, 146, 96, 58, 16, 181, 60, 101, 208, 181, 144, 241, 199, 163, 99, 172, 232, 37, 253, 163, 76, 34, 235, 23, 96 }, new byte[] { 49, 191, 19, 57, 240, 249, 199, 10, 241, 101, 130, 70, 218, 240, 85, 31, 161, 46, 231, 153, 138, 80, 184, 75, 23, 208, 236, 99, 88, 65, 204, 176, 16, 63, 76, 178, 153, 229, 184, 222, 76, 167, 174, 202, 55, 139, 202, 51, 37, 169, 117, 142, 23, 188, 2, 196, 234, 228, 114, 175, 15, 125, 216, 61, 17, 71, 104, 164, 219, 67, 5, 39, 204, 200, 44, 90, 35, 133, 113, 253, 111, 31, 175, 246, 203, 231, 59, 176, 60, 179, 140, 201, 191, 164, 211, 53, 83, 68, 71, 78, 33, 125, 248, 254, 212, 112, 149, 108, 236, 68, 27, 2, 69, 127, 145, 151, 136, 71, 18, 238, 215, 116, 230, 21, 12, 48, 208, 180 } });
        }
    }
}
