using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fiction" },
                    { 2, "Non-Fiction" },
                    { 3, "Children's and Young Adult" },
                    { 4, "Poetry and Drama" },
                    { 5, "Horror/Suspense" },
                    { 6, "Miscellaneous" }
                });

            migrationBuilder.InsertData(
                table: "SubGenres",
                columns: new[] { "Id", "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Literary Fiction" },
                    { 3, 1, "Science Fiction" },
                    { 4, 1, "Fantasy" },
                    { 5, 1, "Romance" },
                    { 6, 1, "Historical Fiction" },
                    { 7, 1, "Adventure" },
                    { 8, 2, "Biography/Autobiography" },
                    { 9, 2, "Self-Help" },
                    { 10, 2, "History" },
                    { 11, 2, "Memoir" },
                    { 12, 2, "Cookbook" },
                    { 13, 2, "Travel" },
                    { 14, 2, "Science" },
                    { 15, 3, "Picture Books" },
                    { 16, 3, "Middle Grade" },
                    { 17, 3, "Young Adult" },
                    { 18, 3, "Contemporary" },
                    { 19, 4, "Poetry" },
                    { 20, 4, "Drama" },
                    { 21, 4, "Play" },
                    { 22, 5, "Mystery" },
                    { 23, 5, "Thriller" },
                    { 24, 5, "Suspense" },
                    { 25, 5, "Crime" },
                    { 26, 5, "Horror" },
                    { 27, 6, "Humor" },
                    { 28, 6, "Psychological" },
                    { 29, 6, "Western" },
                    { 30, 6, "Satire" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_GenreId",
                table: "Book",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_SubGenres_GenreId",
                table: "SubGenres",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "SubGenres");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
