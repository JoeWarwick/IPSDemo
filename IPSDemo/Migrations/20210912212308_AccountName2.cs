using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPSDemo.Migrations
{
    public partial class AccountName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "PersonalAccounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PersonalAccounts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "CorporateAccounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "CorporateAccounts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "CorporateAccounts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CorporateAccounts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "PersonalAccounts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PersonalAccounts");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "CorporateAccounts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "CorporateAccounts");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "CorporateAccounts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CorporateAccounts");
        }
    }
}
