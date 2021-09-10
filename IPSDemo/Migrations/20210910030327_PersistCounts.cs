using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPSDemo.Migrations
{
    public partial class PersistCounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_CorporateAccounts_CorporateAccountId1",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_CorporateAccountId1",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CorporateAccountId1",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "NoOfPersonnel",
                table: "PersonalAccounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfPersonnel",
                table: "PersonalAccounts");

            migrationBuilder.AddColumn<Guid>(
                name: "CorporateAccountId1",
                table: "Person",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_CorporateAccountId1",
                table: "Person",
                column: "CorporateAccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_CorporateAccounts_CorporateAccountId1",
                table: "Person",
                column: "CorporateAccountId1",
                principalTable: "CorporateAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
