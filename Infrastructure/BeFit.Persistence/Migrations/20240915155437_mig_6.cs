using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActivityId",
                table: "UserProperties",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BodyDecision",
                table: "UserProperties",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ActivityCoefficient = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProperties_ActivityId",
                table: "UserProperties",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProperties_Activity_ActivityId",
                table: "UserProperties",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProperties_Activity_ActivityId",
                table: "UserProperties");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_UserProperties_ActivityId",
                table: "UserProperties");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "UserProperties");

            migrationBuilder.DropColumn(
                name: "BodyDecision",
                table: "UserProperties");
        }
    }
}
