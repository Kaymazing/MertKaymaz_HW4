using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MertKaymaz_HW4.Migrations
{
    public partial class thirddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Named",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Credit",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quota",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Credit",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Quota",
                table: "Courses");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Named",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
