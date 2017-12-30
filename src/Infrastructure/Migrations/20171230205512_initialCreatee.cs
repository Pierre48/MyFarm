using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyFarm.Infrastructure.Migrations
{
    public partial class initialCreatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Farm",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Farm_AddressId",
                table: "Farm",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Farm_Address_AddressId",
                table: "Farm",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farm_Address_AddressId",
                table: "Farm");

            migrationBuilder.DropIndex(
                name: "IX_Farm_AddressId",
                table: "Farm");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Farm");
        }
    }
}
