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
                name: "Permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Permissi__3213E83F00E1E37D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__3213E83F46221B44", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__States__3213E83F71E8FB71", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    origin = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tasks__3213E83F26C748C2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false),
                    permissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RolePerm__101A5503EAC5AE42", x => new { x.roleId, x.permissionId });
                    table.ForeignKey(
                        name: "FK__RolePermi__permi__0F624AF8",
                        column: x => x.permissionId,
                        principalTable: "Permissions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__RolePermi__roleI__10566F31",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    profilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    firstName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    lastName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    supervisorId = table.Column<int>(type: "int", nullable: true),
                    entity = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    startDate = table.Column<DateOnly>(type: "date", nullable: true),
                    endDate = table.Column<DateOnly>(type: "date", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    roleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3213E83FC231B785", x => x.id);
                    table.ForeignKey(
                        name: "FK__Users__roleId__18EBB532",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Users__superviso__19DFD96B",
                        column: x => x.supervisorId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "BriefNotes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<int>(type: "int", nullable: false),
                    brief = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BriefNot__3213E83F7057F2F9", x => x.id);
                    table.ForeignKey(
                        name: "FK__BriefNote__UserI__276EDEB3",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: true),
                    updatedBy = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    classId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__1ABEEF0F1BE55F2F", x => x.id);
                    table.ForeignKey(
                        name: "FK__Document__ClassI__3A81B327",
                        column: x => x.classId,
                        principalTable: "Classes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Document__Create__38996AB5",
                        column: x => x.createdBy,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Document__Update__398D8EEE",
                        column: x => x.updatedBy,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UserAgencies",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false),
                    agencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserAgen__3B770C2ECF2CCFB9", x => new { x.userId, x.agencyId });
                    table.ForeignKey(
                        name: "FK__UserAgenc__agenc__2FCF1A8A",
                        column: x => x.agencyId,
                        principalTable: "Agencies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__UserAgenc__userI__30C33EC3",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UserFormations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    isCheck = table.Column<bool>(type: "bit", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false),
                    stateId = table.Column<int>(type: "int", nullable: false),
                    evaluationId = table.Column<int>(type: "int", nullable: false),
                    formationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserForm__3213E83F196B82AA", x => x.id);
                    table.ForeignKey(
                        name: "FK__UserForma__evalu__2A164134",
                        column: x => x.evaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__UserForma__forma__2B0A656D",
                        column: x => x.formationId,
                        principalTable: "Formations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__UserForma__state__2BFE89A6",
                        column: x => x.stateId,
                        principalTable: "States",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__UserForma__userI__2CF2ADDF",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Weeks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    weekNumber = table.Column<int>(type: "int", nullable: false),
                    periodNumber = table.Column<int>(type: "int", nullable: false),
                    startDateWeek = table.Column<DateOnly>(type: "date", nullable: false),
                    endDateWeek = table.Column<DateOnly>(type: "date", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    isDraft = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Weeks__3213E83F88BAC7E5", x => x.id);
                    table.ForeignKey(
                        name: "FK__Week__UserId__2A4B4B5E",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "HalfDayPlannings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    halfDayDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    halfDayTime = table.Column<bool>(type: "bit", nullable: true),
                    weekId = table.Column<int>(type: "int", nullable: false),
                    taskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HalfDayP__D4599D0FADCFD35A", x => x.id);
                    table.ForeignKey(
                        name: "FK__HalfDayPl__TaskI__35BCFE0A",
                        column: x => x.taskId,
                        principalTable: "Tasks",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__HalfDayPl__WeekI__34C8D9D1",
                        column: x => x.weekId,
                        principalTable: "Weeks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BriefNotes_userId",
                table: "BriefNotes",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_classId",
                table: "Documents",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_createdBy",
                table: "Documents",
                column: "createdBy");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_updatedBy",
                table: "Documents",
                column: "updatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HalfDayPlannings_taskId",
                table: "HalfDayPlannings",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_HalfDayPlannings_weekId",
                table: "HalfDayPlannings",
                column: "weekId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_permissionId",
                table: "RolePermissions",
                column: "permissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAgencies_agencyId",
                table: "UserAgencies",
                column: "agencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFormations_evaluationId",
                table: "UserFormations",
                column: "evaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFormations_formationId",
                table: "UserFormations",
                column: "formationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFormations_stateId",
                table: "UserFormations",
                column: "stateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFormations_userId",
                table: "UserFormations",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleId",
                table: "Users",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_supervisorId",
                table: "Users",
                column: "supervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Weeks_userId",
                table: "Weeks",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BriefNotes");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "HalfDayPlannings");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserAgencies");

            migrationBuilder.DropTable(
                name: "UserFormations");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Weeks");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
