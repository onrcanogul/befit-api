using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_user_props : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProperties_Carbohydrate_NeededCarbohydrateId",
                table: "UserProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProperties_Fat_NeededFatId",
                table: "UserProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProperties_Protein_NeededProteinId",
                table: "UserProperties");

            migrationBuilder.DropIndex(
                name: "IX_UserProperties_NeededCarbohydrateId",
                table: "UserProperties");

            migrationBuilder.DropIndex(
                name: "IX_UserProperties_NeededFatId",
                table: "UserProperties");

            migrationBuilder.DropIndex(
                name: "IX_UserProperties_NeededProteinId",
                table: "UserProperties");

            migrationBuilder.DropColumn(
                name: "NeededCarbohydrateId",
                table: "UserProperties");

            migrationBuilder.DropColumn(
                name: "NeededFatId",
                table: "UserProperties");

            migrationBuilder.DropColumn(
                name: "NeededProteinId",
                table: "UserProperties");

            migrationBuilder.AddColumn<decimal>(
                name: "NeededCarbohydrate",
                table: "UserProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NeededFat",
                table: "UserProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NeededProtein",
                table: "UserProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeededCarbohydrate",
                table: "UserProperties");

            migrationBuilder.DropColumn(
                name: "NeededFat",
                table: "UserProperties");

            migrationBuilder.DropColumn(
                name: "NeededProtein",
                table: "UserProperties");

            migrationBuilder.AddColumn<Guid>(
                name: "NeededCarbohydrateId",
                table: "UserProperties",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NeededFatId",
                table: "UserProperties",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NeededProteinId",
                table: "UserProperties",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserProperties_NeededCarbohydrateId",
                table: "UserProperties",
                column: "NeededCarbohydrateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProperties_NeededFatId",
                table: "UserProperties",
                column: "NeededFatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProperties_NeededProteinId",
                table: "UserProperties",
                column: "NeededProteinId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProperties_Carbohydrate_NeededCarbohydrateId",
                table: "UserProperties",
                column: "NeededCarbohydrateId",
                principalTable: "Carbohydrate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProperties_Fat_NeededFatId",
                table: "UserProperties",
                column: "NeededFatId",
                principalTable: "Fat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProperties_Protein_NeededProteinId",
                table: "UserProperties",
                column: "NeededProteinId",
                principalTable: "Protein",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
