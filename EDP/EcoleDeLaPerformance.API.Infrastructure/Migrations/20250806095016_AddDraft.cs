using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoleDeLaPerformance.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDraft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "comment",
                table: "users_formations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<bool>(
                name: "is_draft",
                table: "debriefs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_draft",
                table: "briefs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_draft",
                table: "debriefs");

            migrationBuilder.DropColumn(
                name: "is_draft",
                table: "briefs");

            migrationBuilder.AlterColumn<string>(
                name: "comment",
                table: "users_formations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
