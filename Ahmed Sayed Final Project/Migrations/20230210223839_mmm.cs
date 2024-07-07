using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmedSayedFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class mmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_professors_ProfessorId",
                table: "courses");

            migrationBuilder.DropTable(
                name: "professors");

            migrationBuilder.DropIndex(
                name: "IX_courses_ProfessorId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "professors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bonus = table.Column<double>(type: "float", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationalNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professors", x => x.Id);
                });

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
