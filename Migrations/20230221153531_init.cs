using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloneIntime.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditoryEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoryEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeachersEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectionEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectionEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectionEntities_FacultyEntities_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "FacultyEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineEntityTeacherEntity",
                columns: table => new
                {
                    DisciplinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeachersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineEntityTeacherEntity", x => new { x.DisciplinesId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_DisciplineEntityTeacherEntity_DisciplineEntities_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "DisciplineEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineEntityTeacherEntity_TeachersEntities_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "TeachersEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupEntities_DirectionEntities_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "DirectionEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayName = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayEntities_GroupEntities_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GroupEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PairEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisciplineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuditoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PairEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PairEntities_AuditoryEntities_AuditoryId",
                        column: x => x.AuditoryId,
                        principalTable: "AuditoryEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PairEntities_DisciplineEntities_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "DisciplineEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PairEntities_GroupEntities_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GroupEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PairEntities_TeachersEntities_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "TeachersEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlotEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PairId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    DayEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlotEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlotEntities_DayEntities_DayEntityId",
                        column: x => x.DayEntityId,
                        principalTable: "DayEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TimeSlotEntities_PairEntities_PairId",
                        column: x => x.PairId,
                        principalTable: "PairEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayEntities_GroupId",
                table: "DayEntities",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectionEntities_FacultyId",
                table: "DirectionEntities",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineEntityTeacherEntity_TeachersId",
                table: "DisciplineEntityTeacherEntity",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEntities_DirectionId",
                table: "GroupEntities",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PairEntities_AuditoryId",
                table: "PairEntities",
                column: "AuditoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PairEntities_DisciplineId",
                table: "PairEntities",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_PairEntities_GroupId",
                table: "PairEntities",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PairEntities_TeacherId",
                table: "PairEntities",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotEntities_DayEntityId",
                table: "TimeSlotEntities",
                column: "DayEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotEntities_PairId",
                table: "TimeSlotEntities",
                column: "PairId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminEntities");

            migrationBuilder.DropTable(
                name: "DisciplineEntityTeacherEntity");

            migrationBuilder.DropTable(
                name: "TimeSlotEntities");

            migrationBuilder.DropTable(
                name: "DayEntities");

            migrationBuilder.DropTable(
                name: "PairEntities");

            migrationBuilder.DropTable(
                name: "AuditoryEntities");

            migrationBuilder.DropTable(
                name: "DisciplineEntities");

            migrationBuilder.DropTable(
                name: "GroupEntities");

            migrationBuilder.DropTable(
                name: "TeachersEntities");

            migrationBuilder.DropTable(
                name: "DirectionEntities");

            migrationBuilder.DropTable(
                name: "FacultyEntities");
        }
    }
}
