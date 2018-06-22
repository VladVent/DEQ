using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Archive1.Migrations
{
    public partial class NewBaseGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Develop_Game_GameId",
                table: "Develop");

            migrationBuilder.DropForeignKey(
                name: "FK_Published_Game_GameId",
                table: "Published");

            migrationBuilder.DropIndex(
                name: "IX_Published_GameId",
                table: "Published");

            migrationBuilder.DropIndex(
                name: "IX_Develop_GameId",
                table: "Develop");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Published");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Develop");

            migrationBuilder.AddColumn<int>(
                name: "GameDevId",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GamePubId",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameDevId",
                table: "Game",
                column: "GameDevId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GamePubId",
                table: "Game",
                column: "GamePubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Develop_GameDevId",
                table: "Game",
                column: "GameDevId",
                principalTable: "Develop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Published_GamePubId",
                table: "Game",
                column: "GamePubId",
                principalTable: "Published",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Develop_GameDevId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Published_GamePubId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_GameDevId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_GamePubId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GameDevId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GamePubId",
                table: "Game");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Published",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Develop",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Published_GameId",
                table: "Published",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Develop_GameId",
                table: "Develop",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Develop_Game_GameId",
                table: "Develop",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Published_Game_GameId",
                table: "Published",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
