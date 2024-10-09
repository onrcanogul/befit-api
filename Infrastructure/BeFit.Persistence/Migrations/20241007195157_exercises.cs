using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class exercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_AspNetUsers_UserId",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_UserId",
                table: "Exercises",
                newName: "IX_Exercises_UserId");

            migrationBuilder.AddColumn<decimal>(
                name: "BurnedCaloriePer12Reps",
                table: "Exercises",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Exercises",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Minutes",
                table: "Exercises",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "Exercises",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Training_UserId",
                table: "Exercises",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_Training_UserId",
                table: "Exercises",
                column: "Training_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_Training_UserId",
                table: "Exercises",
                column: "Training_UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_UserId",
                table: "Exercises",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_Training_UserId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_UserId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_Training_UserId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "BurnedCaloriePer12Reps",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Minutes",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Training_UserId",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_UserId",
                table: "Exercise",
                newName: "IX_Exercise_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_AspNetUsers_UserId",
                table: "Exercise",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
