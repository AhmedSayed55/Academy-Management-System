using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmedSayedFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class relationshipBetweenTheTwoTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "professors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_professors_ProfessorId",
                table: "professors",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_courses_ProfessorId",
                table: "courses",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_professors_ProfessorId",
                table: "courses",
                column: "ProfessorId",
                principalTable: "professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_professors_professors_ProfessorId",
                table: "professors",
                column: "ProfessorId",
                principalTable: "professors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_professors_ProfessorId",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_professors_professors_ProfessorId",
                table: "professors");

            migrationBuilder.DropIndex(
                name: "IX_professors_ProfessorId",
                table: "professors");

            migrationBuilder.DropIndex(
                name: "IX_courses_ProfessorId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "professors");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "courses");
        }
    }
}
