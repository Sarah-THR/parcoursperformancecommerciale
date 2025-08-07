using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoleDeLaPerformance.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFormationRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "formations",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_formations_RoleId",
                table: "formations",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_formations_role",
                table: "formations",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_formations_role",
                table: "formations");

            migrationBuilder.DropIndex(
                name: "IX_formations_RoleId",
                table: "formations");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "formations");
        }
    }
}
