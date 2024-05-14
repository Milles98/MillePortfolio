using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GitProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GithubUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveDemoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechIcons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Technology = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechIcons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechStacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechIconId = table.Column<int>(type: "int", nullable: false),
                    GitProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechStacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechStacks_GitProjects_GitProjectId",
                        column: x => x.GitProjectId,
                        principalTable: "GitProjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechStacks_TechIcons_TechIconId",
                        column: x => x.TechIconId,
                        principalTable: "TechIcons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechStacks_GitProjectId",
                table: "TechStacks",
                column: "GitProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TechStacks_TechIconId",
                table: "TechStacks",
                column: "TechIconId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechStacks");

            migrationBuilder.DropTable(
                name: "GitProjects");

            migrationBuilder.DropTable(
                name: "TechIcons");
        }
    }
}
