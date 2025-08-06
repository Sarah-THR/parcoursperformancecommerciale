using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoleDeLaPerformance.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_first_connection",
                table: "users",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_first_connection",
                table: "users");
        }
    }
}
