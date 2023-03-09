using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloneIntime.Migrations
{
    /// <inheritdoc />
    public partial class fixTimeslots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayEntities_GroupEntities_GroupId",
                table: "DayEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlotEntities_DayEntities_DayId",
                table: "TimeSlotEntities");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlotEntities_DayId",
                table: "TimeSlotEntities");

            migrationBuilder.DropIndex(
                name: "IX_DayEntities_GroupId",
                table: "DayEntities");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TimeSlotEntities");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "TimeSlotEntities");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "DayEntities");

            migrationBuilder.AddColumn<Guid>(
                name: "DayEntityId",
                table: "TimeSlotEntities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PairNumber",
                table: "TimeSlotEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotEntities_DayEntityId",
                table: "TimeSlotEntities",
                column: "DayEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlotEntities_DayEntities_DayEntityId",
                table: "TimeSlotEntities",
                column: "DayEntityId",
                principalTable: "DayEntities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlotEntities_DayEntities_DayEntityId",
                table: "TimeSlotEntities");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlotEntities_DayEntityId",
                table: "TimeSlotEntities");

            migrationBuilder.DropColumn(
                name: "DayEntityId",
                table: "TimeSlotEntities");

            migrationBuilder.DropColumn(
                name: "PairNumber",
                table: "TimeSlotEntities");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TimeSlotEntities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DayId",
                table: "TimeSlotEntities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "DayEntities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotEntities_DayId",
                table: "TimeSlotEntities",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_DayEntities_GroupId",
                table: "DayEntities",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayEntities_GroupEntities_GroupId",
                table: "DayEntities",
                column: "GroupId",
                principalTable: "GroupEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlotEntities_DayEntities_DayId",
                table: "TimeSlotEntities",
                column: "DayId",
                principalTable: "DayEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
