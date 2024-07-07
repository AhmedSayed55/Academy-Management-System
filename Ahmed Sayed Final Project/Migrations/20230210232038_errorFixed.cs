using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmedSayedFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class errorFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_courses_ProfessorId",
                table: "courses",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_Professor_ProfessorId",
                table: "courses",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_Professor_ProfessorId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_ProfessorId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "courses");
        }
    }
}
