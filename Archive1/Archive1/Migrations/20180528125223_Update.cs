using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Archive1.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Game",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Game",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Game");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Game",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
