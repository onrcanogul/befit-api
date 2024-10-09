using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_AspNetUsers_UserId",
                table: "Trainings");

            migrationBuilder.DropTable(
                name: "Cardios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainings",
                table: "Trainings");

            migrationBuilder.RenameTable(
                name: "Trainings",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_Trainings_UserId",
                table: "Exercises",
                newName: "IX_Exercises_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "Reps",
                table: "Exercises",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "BurnedCaloriePer12Reps",
                table: "Exercises",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

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
                name: "Discriminator",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Minutes",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Training_UserId",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Trainings");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_UserId",
                table: "Trainings",
                newName: "IX_Trainings_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "Reps",
                table: "Trainings",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BurnedCaloriePer12Reps",
                table: "Trainings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainings",
                table: "Trainings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cardios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Minutes = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    WOBurnedCalorie = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cardios_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cardios_UserId",
                table: "Cardios",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_AspNetUsers_UserId",
                table: "Trainings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
