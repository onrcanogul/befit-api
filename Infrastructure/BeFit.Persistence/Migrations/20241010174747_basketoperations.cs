using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class basketoperations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "B1",
                table: "NutrientProperties");

            migrationBuilder.DropColumn(
                name: "B12",
                table: "NutrientProperties");

            migrationBuilder.DropColumn(
                name: "B2",
                table: "NutrientProperties");

            migrationBuilder.DropColumn(
                name: "B3",
                table: "NutrientProperties");

            migrationBuilder.DropColumn(
                name: "Calcium",
                table: "NutrientProperties");

            migrationBuilder.DropColumn(
                name: "Carbohydrate",
                table: "NutrientProperties");

            migrationBuilder.DropColumn(
                name: "CholesterolWeight",
                table: "NutrientProperties");

            migrationBuilder.DropColumn(
                name: "E",
                table: "NutrientProperties");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "NutrientProperties");

            migrationBuilder.DropColumn(
                name: "FolicAcid",
                table: "NutrientProperties");

            migrationBuilder.DropColumn(
                name: "Iron",
                table: "NutrientProperties");

            migrationBuilder.RenameColumn(
                name: "Sulfur",
                table: "NutrientProperties",
                newName: "SugarWeight100gr");

            migrationBuilder.RenameColumn(
                name: "SugarWeight",
                table: "NutrientProperties",
                newName: "Sodium100gr");

            migrationBuilder.RenameColumn(
                name: "Sodium",
                table: "NutrientProperties",
                newName: "Salt100gr");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "NutrientProperties",
                newName: "Protein100gr");

            migrationBuilder.RenameColumn(
                name: "Protein",
                table: "NutrientProperties",
                newName: "Magnesium100gr");

            migrationBuilder.RenameColumn(
                name: "Potassium",
                table: "NutrientProperties",
                newName: "Fat100gr");

            migrationBuilder.RenameColumn(
                name: "Phosphorus",
                table: "NutrientProperties",
                newName: "CholesterolWeight100gr");

            migrationBuilder.RenameColumn(
                name: "Magnesium",
                table: "NutrientProperties",
                newName: "Carbohydrate100gr");

            migrationBuilder.CreateTable(
                name: "FoodBaskets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    TotalCalorie = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCarb = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalProtein = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalFat = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalSalt = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalSugar = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalSodium = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalMagnesium = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCholesterol = table.Column<decimal>(type: "numeric", nullable: false),
                    NutrientPropertiesId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodBaskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodBaskets_NutrientProperties_NutrientPropertiesId",
                        column: x => x.NutrientPropertiesId,
                        principalTable: "NutrientProperties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NutrientId = table.Column<Guid>(type: "uuid", nullable: false),
                    BasketId = table.Column<Guid>(type: "uuid", nullable: false),
                    Measure = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_FoodBaskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "FoodBaskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Nutrients_NutrientId",
                        column: x => x.NutrientId,
                        principalTable: "Nutrients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_NutrientId",
                table: "BasketItems",
                column: "NutrientId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodBaskets_NutrientPropertiesId",
                table: "FoodBaskets",
                column: "NutrientPropertiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "FoodBaskets");

            migrationBuilder.RenameColumn(
                name: "SugarWeight100gr",
                table: "NutrientProperties",
                newName: "Sulfur");

            migrationBuilder.RenameColumn(
                name: "Sodium100gr",
                table: "NutrientProperties",
                newName: "SugarWeight");

            migrationBuilder.RenameColumn(
                name: "Salt100gr",
                table: "NutrientProperties",
                newName: "Sodium");

            migrationBuilder.RenameColumn(
                name: "Protein100gr",
                table: "NutrientProperties",
                newName: "Salt");

            migrationBuilder.RenameColumn(
                name: "Magnesium100gr",
                table: "NutrientProperties",
                newName: "Protein");

            migrationBuilder.RenameColumn(
                name: "Fat100gr",
                table: "NutrientProperties",
                newName: "Potassium");

            migrationBuilder.RenameColumn(
                name: "CholesterolWeight100gr",
                table: "NutrientProperties",
                newName: "Phosphorus");

            migrationBuilder.RenameColumn(
                name: "Carbohydrate100gr",
                table: "NutrientProperties",
                newName: "Magnesium");

            migrationBuilder.AddColumn<decimal>(
                name: "B1",
                table: "NutrientProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "B12",
                table: "NutrientProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "B2",
                table: "NutrientProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "B3",
                table: "NutrientProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Calcium",
                table: "NutrientProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Carbohydrate",
                table: "NutrientProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CholesterolWeight",
                table: "NutrientProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "E",
                table: "NutrientProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Fat",
                table: "NutrientProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FolicAcid",
                table: "NutrientProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Iron",
                table: "NutrientProperties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
