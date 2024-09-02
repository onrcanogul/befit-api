using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class bugfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutrientCalories_Carbohydrate_CarbohydrateId",
                table: "NutrientCalories");

            migrationBuilder.DropForeignKey(
                name: "FK_NutrientCalories_Fat_FatId",
                table: "NutrientCalories");

            migrationBuilder.DropForeignKey(
                name: "FK_NutrientCalories_Minerals_MineralsId",
                table: "NutrientCalories");

            migrationBuilder.DropForeignKey(
                name: "FK_NutrientCalories_Nutrients_NutrientId",
                table: "NutrientCalories");

            migrationBuilder.DropForeignKey(
                name: "FK_NutrientCalories_Protein_ProteinId",
                table: "NutrientCalories");

            migrationBuilder.DropForeignKey(
                name: "FK_NutrientCalories_Salt_SaltId",
                table: "NutrientCalories");

            migrationBuilder.DropForeignKey(
                name: "FK_NutrientCalories_Vitamins_VitaminsId",
                table: "NutrientCalories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NutrientCalories",
                table: "NutrientCalories");

            migrationBuilder.RenameTable(
                name: "NutrientCalories",
                newName: "NutrientProperties");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientCalories_VitaminsId",
                table: "NutrientProperties",
                newName: "IX_NutrientProperties_VitaminsId");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientCalories_SaltId",
                table: "NutrientProperties",
                newName: "IX_NutrientProperties_SaltId");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientCalories_ProteinId",
                table: "NutrientProperties",
                newName: "IX_NutrientProperties_ProteinId");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientCalories_NutrientId",
                table: "NutrientProperties",
                newName: "IX_NutrientProperties_NutrientId");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientCalories_MineralsId",
                table: "NutrientProperties",
                newName: "IX_NutrientProperties_MineralsId");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientCalories_FatId",
                table: "NutrientProperties",
                newName: "IX_NutrientProperties_FatId");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientCalories_CarbohydrateId",
                table: "NutrientProperties",
                newName: "IX_NutrientProperties_CarbohydrateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NutrientProperties",
                table: "NutrientProperties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientProperties_Carbohydrate_CarbohydrateId",
                table: "NutrientProperties",
                column: "CarbohydrateId",
                principalTable: "Carbohydrate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientProperties_Fat_FatId",
                table: "NutrientProperties",
                column: "FatId",
                principalTable: "Fat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientProperties_Minerals_MineralsId",
                table: "NutrientProperties",
                column: "MineralsId",
                principalTable: "Minerals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientProperties_Nutrients_NutrientId",
                table: "NutrientProperties",
                column: "NutrientId",
                principalTable: "Nutrients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientProperties_Protein_ProteinId",
                table: "NutrientProperties",
                column: "ProteinId",
                principalTable: "Protein",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientProperties_Salt_SaltId",
                table: "NutrientProperties",
                column: "SaltId",
                principalTable: "Salt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientProperties_Vitamins_VitaminsId",
                table: "NutrientProperties",
                column: "VitaminsId",
                principalTable: "Vitamins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutrientProperties_Carbohydrate_CarbohydrateId",
                table: "NutrientProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_NutrientProperties_Fat_FatId",
                table: "NutrientProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_NutrientProperties_Minerals_MineralsId",
                table: "NutrientProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_NutrientProperties_Nutrients_NutrientId",
                table: "NutrientProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_NutrientProperties_Protein_ProteinId",
                table: "NutrientProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_NutrientProperties_Salt_SaltId",
                table: "NutrientProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_NutrientProperties_Vitamins_VitaminsId",
                table: "NutrientProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NutrientProperties",
                table: "NutrientProperties");

            migrationBuilder.RenameTable(
                name: "NutrientProperties",
                newName: "NutrientCalories");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientProperties_VitaminsId",
                table: "NutrientCalories",
                newName: "IX_NutrientCalories_VitaminsId");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientProperties_SaltId",
                table: "NutrientCalories",
                newName: "IX_NutrientCalories_SaltId");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientProperties_ProteinId",
                table: "NutrientCalories",
                newName: "IX_NutrientCalories_ProteinId");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientProperties_NutrientId",
                table: "NutrientCalories",
                newName: "IX_NutrientCalories_NutrientId");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientProperties_MineralsId",
                table: "NutrientCalories",
                newName: "IX_NutrientCalories_MineralsId");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientProperties_FatId",
                table: "NutrientCalories",
                newName: "IX_NutrientCalories_FatId");

            migrationBuilder.RenameIndex(
                name: "IX_NutrientProperties_CarbohydrateId",
                table: "NutrientCalories",
                newName: "IX_NutrientCalories_CarbohydrateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NutrientCalories",
                table: "NutrientCalories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientCalories_Carbohydrate_CarbohydrateId",
                table: "NutrientCalories",
                column: "CarbohydrateId",
                principalTable: "Carbohydrate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientCalories_Fat_FatId",
                table: "NutrientCalories",
                column: "FatId",
                principalTable: "Fat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientCalories_Minerals_MineralsId",
                table: "NutrientCalories",
                column: "MineralsId",
                principalTable: "Minerals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientCalories_Nutrients_NutrientId",
                table: "NutrientCalories",
                column: "NutrientId",
                principalTable: "Nutrients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientCalories_Protein_ProteinId",
                table: "NutrientCalories",
                column: "ProteinId",
                principalTable: "Protein",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientCalories_Salt_SaltId",
                table: "NutrientCalories",
                column: "SaltId",
                principalTable: "Salt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientCalories_Vitamins_VitaminsId",
                table: "NutrientCalories",
                column: "VitaminsId",
                principalTable: "Vitamins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
