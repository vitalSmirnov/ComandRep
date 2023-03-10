using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloneIntime.Migrations
{
    /// <inheritdoc />
    public partial class fixDisciplines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FacultyEntityId",
                table: "DisciplineEntities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineEntities_FacultyEntityId",
                table: "DisciplineEntities",
                column: "FacultyEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineEntities_FacultyEntities_FacultyEntityId",
                table: "DisciplineEntities",
                column: "FacultyEntityId",
                principalTable: "FacultyEntities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineEntities_FacultyEntities_FacultyEntityId",
                table: "DisciplineEntities");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineEntities_FacultyEntityId",
                table: "DisciplineEntities");

            migrationBuilder.DropColumn(
                name: "FacultyEntityId",
                table: "DisciplineEntities");
        }
    }
}
