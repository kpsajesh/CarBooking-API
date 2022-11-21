using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookingData.Migrations
{
    public partial class RolCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegnNo",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SecondName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23fae0de-b8a2-4c24-975a-e0c490d06bd6", "b952b3bc-3064-40fd-82f6-c8ae6ee22248", "Administrator", "ADMINISTRATOR" },
                    { "748fc736-2384-4420-aac6-d21e7aaa7ccc", "fc792379-6be4-40f1-926e-66a87165152c", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 18, 12, 42, 25, 421, DateTimeKind.Local).AddTicks(7287), new DateTime(2022, 11, 18, 12, 42, 25, 421, DateTimeKind.Local).AddTicks(7292) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 18, 12, 42, 25, 421, DateTimeKind.Local).AddTicks(7295), new DateTime(2022, 11, 18, 12, 42, 25, 421, DateTimeKind.Local).AddTicks(7297) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 18, 12, 42, 25, 421, DateTimeKind.Local).AddTicks(7014), new DateTime(2022, 11, 18, 12, 42, 25, 421, DateTimeKind.Local).AddTicks(7088) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 18, 12, 42, 25, 421, DateTimeKind.Local).AddTicks(7092), new DateTime(2022, 11, 18, 12, 42, 25, 421, DateTimeKind.Local).AddTicks(7095) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23fae0de-b8a2-4c24-975a-e0c490d06bd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "748fc736-2384-4420-aac6-d21e7aaa7ccc");

            migrationBuilder.AlterColumn<string>(
                name: "RegnNo",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecondName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 17, 23, 33, 11, 211, DateTimeKind.Local).AddTicks(3784), new DateTime(2022, 11, 17, 23, 33, 11, 211, DateTimeKind.Local).AddTicks(3787) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 17, 23, 33, 11, 211, DateTimeKind.Local).AddTicks(3790), new DateTime(2022, 11, 17, 23, 33, 11, 211, DateTimeKind.Local).AddTicks(3791) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 17, 23, 33, 11, 211, DateTimeKind.Local).AddTicks(3595), new DateTime(2022, 11, 17, 23, 33, 11, 211, DateTimeKind.Local).AddTicks(3637) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 17, 23, 33, 11, 211, DateTimeKind.Local).AddTicks(3641), new DateTime(2022, 11, 17, 23, 33, 11, 211, DateTimeKind.Local).AddTicks(3642) });
        }
    }
}
