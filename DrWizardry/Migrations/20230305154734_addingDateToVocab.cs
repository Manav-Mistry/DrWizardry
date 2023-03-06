using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrWizardry.Migrations
{
    public partial class addingDateToVocab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "UserVocab");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Vocabs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Vocabs");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "UserVocab",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
