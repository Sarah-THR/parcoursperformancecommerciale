using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoleDeLaPerformance.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__3213E83F971B5BFD", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "evaluations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__evaluati__3213E83FEFDC4BB3", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "formations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__formatio__3213E83FF5152FEA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "grades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__grades__3213E83F3D2A0444", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__statuses__3213E83F8BFA154D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tasks__3213E83FB9325923", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    profile_picture_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    entity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    start_follow_up = table.Column<DateOnly>(type: "date", nullable: true),
                    supervisor_id = table.Column<int>(type: "int", nullable: true),
                    director_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    grade_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83F389B100E", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_director",
                        column: x => x.director_id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_users_grade",
                        column: x => x.grade_id,
                        principalTable: "grades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_users_supervisor",
                        column: x => x.supervisor_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "briefs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    signature_commitment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    files_to_check = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__briefs__3213E83F8E97A8C8", x => x.id);
                    table.ForeignKey(
                        name: "FK_briefs_user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "debriefs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    completed_business = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    business_in_progress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__debriefs__3213E83F75622013", x => x.id);
                    table.ForeignKey(
                        name: "FK_debriefs_user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    content_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    category_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__document__3213E83F8CDF0AE3", x => x.id);
                    table.ForeignKey(
                        name: "FK_documents_category",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_documents_user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "plannings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__planning__3213E83FEFD1DABD", x => x.id);
                    table.ForeignKey(
                        name: "FK_plannings_user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users_formations",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    formation_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    evaluation_id = table.Column<int>(type: "int", nullable: true),
                    is_validated = table.Column<bool>(type: "bit", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    document_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_formations", x => new { x.user_id, x.formation_id });
                    table.ForeignKey(
                        name: "FK_users_formations_document",
                        column: x => x.document_id,
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_users_formations_evaluation",
                        column: x => x.evaluation_id,
                        principalTable: "evaluations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_users_formations_formation",
                        column: x => x.formation_id,
                        principalTable: "formations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_users_formations_status",
                        column: x => x.status_id,
                        principalTable: "statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_users_formations_user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "plannings_tasks",
                columns: table => new
                {
                    planning_id = table.Column<int>(type: "int", nullable: false),
                    task_id = table.Column<int>(type: "int", nullable: false),
                    time_of_day = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plannings_tasks", x => new { x.planning_id, x.task_id });
                    table.ForeignKey(
                        name: "FK_plannings_tasks_planning",
                        column: x => x.planning_id,
                        principalTable: "plannings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_plannings_tasks_task",
                        column: x => x.task_id,
                        principalTable: "tasks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_briefs_user_id",
                table: "briefs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_debriefs_user_id",
                table: "debriefs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_category_id",
                table: "documents",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_user_id",
                table: "documents",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_plannings_user_id",
                table: "plannings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_plannings_tasks_task_id",
                table: "plannings_tasks",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_director_id",
                table: "users",
                column: "director_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_grade_id",
                table: "users",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_supervisor_id",
                table: "users",
                column: "supervisor_id");

            migrationBuilder.CreateIndex(
                name: "UQ__users__AB6E616424F4F6E3",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_formations_document_id",
                table: "users_formations",
                column: "document_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_formations_evaluation_id",
                table: "users_formations",
                column: "evaluation_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_formations_formation_id",
                table: "users_formations",
                column: "formation_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_formations_status_id",
                table: "users_formations",
                column: "status_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "briefs");

            migrationBuilder.DropTable(
                name: "debriefs");

            migrationBuilder.DropTable(
                name: "plannings_tasks");

            migrationBuilder.DropTable(
                name: "users_formations");

            migrationBuilder.DropTable(
                name: "plannings");

            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "documents");

            migrationBuilder.DropTable(
                name: "evaluations");

            migrationBuilder.DropTable(
                name: "formations");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "grades");
        }
    }
}
