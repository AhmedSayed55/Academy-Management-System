using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmedSayedFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class relationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_professors_professors_ProfessorId",
                table: "professors");

            migrationBuilder.DropIndex(
                name: "IX_professors_ProfessorId",
                table: "professors");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "professors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "professors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_professors_ProfessorId",
                table: "professors",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_professors_professors_ProfessorId",
                table: "professors",
                column: "ProfessorId",
                principalTable: "professors",
                principalColumn: "Id");
        }
    }
}
