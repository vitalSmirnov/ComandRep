using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloneIntime.Migrations
{
    /// <inheritdoc />
    public partial class teachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineEntities_TeachersEntities_TeacherEntityId",
                table: "DisciplineEntities");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineEntities_TeacherEntityId",
                table: "DisciplineEntities");

            migrationBuilder.DropColumn(
                name: "TeacherEntityId",
                table: "DisciplineEntities");

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

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineEntityTeacherEntity_TeachersId",
                table: "DisciplineEntityTeacherEntity",
                column: "TeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplineEntityTeacherEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherEntityId",
                table: "DisciplineEntities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineEntities_TeacherEntityId",
                table: "DisciplineEntities",
                column: "TeacherEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineEntities_TeachersEntities_TeacherEntityId",
                table: "DisciplineEntities",
                column: "TeacherEntityId",
                principalTable: "TeachersEntities",
                principalColumn: "Id");
        }
    }
}
