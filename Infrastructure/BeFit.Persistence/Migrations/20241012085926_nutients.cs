using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class nutients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Nutrients_NutrientId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Nutrients_Categories_CategoryId",
                table: "Nutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_Nutrients_Categories_Food_CategoryId",
                table: "Nutrients");

            migrationBuilder.DropIndex(
                name: "IX_Nutrients_CategoryId",
                table: "Nutrients");

            migrationBuilder.DropIndex(
                name: "IX_Nutrients_Food_CategoryId",
                table: "Nutrients");

            migrationBuilder.DropIndex(
                name: "IX_Categories_NutrientId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Nutrients");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Nutrients");

            migrationBuilder.DropColumn(
                name: "Food_CategoryId",
                table: "Nutrients");

            migrationBuilder.DropColumn(
                name: "NutrientId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "CategoryNutrient",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false),
                    NutrientsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryNutrient", x => new { x.CategoriesId, x.NutrientsId });
                    table.ForeignKey(
                        name: "FK_CategoryNutrient_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryNutrient_Nutrients_NutrientsId",
                        column: x => x.NutrientsId,
                        principalTable: "Nutrients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryNutrient_NutrientsId",
                table: "CategoryNutrient",
                column: "NutrientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryNutrient");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Nutrients",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Nutrients",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Food_CategoryId",
                table: "Nutrients",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NutrientId",
                table: "Categories",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nutrients_CategoryId",
                table: "Nutrients",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Nutrients_Food_CategoryId",
                table: "Nutrients",
                column: "Food_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NutrientId",
                table: "Categories",
                column: "NutrientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Nutrients_NutrientId",
                table: "Categories",
                column: "NutrientId",
                principalTable: "Nutrients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrients_Categories_CategoryId",
                table: "Nutrients",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrients_Categories_Food_CategoryId",
                table: "Nutrients",
                column: "Food_CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
