using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoleDeLaPerformance.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addformationsgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "formations",
                type: "int",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_formations_grade",
                table: "formations",
                column: "GradeId",
                principalTable: "grades",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_formations_grade",
                table: "formations");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "formations");

            migrationBuilder.AddForeignKey(
                name: "FK_formations_grade",
                table: "formations",
                column: "GradeId",
                principalTable: "grades",
                principalColumn: "id");
        }
    }
}
