using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace betterboxd_web.Migrations
{
    /// <inheritdoc />
    public partial class IlkOlusturma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Yonetmen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Yil = table.Column<int>(type: "int", nullable: false),
                    Puan = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmler_Turler_TurId",
                        column: x => x.TurId,
                        principalTable: "Turler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Turler",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "Dram" },
                    { 2, "Bilim Kurgu" },
                    { 3, "Suç" },
                    { 4, "Animasyon" },
                    { 5, "Komedi" }
                });

            migrationBuilder.InsertData(
                table: "Filmler",
                columns: new[] { "Id", "Ad", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[,]
                {
                    { 1, "Kış Uykusu", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.3m, 1, 2014, "Nuri Bilge Ceylan" },
                    { 2, "Ahlat Ağacı", new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2m, 1, 2018, "Nuri Bilge Ceylan" },
                    { 3, "Babam ve Oğlum", new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0m, 1, 2005, "Çağan Irmak" },
                    { 4, "Interstellar", new DateTime(2026, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.4m, 2, 2014, "Christopher Nolan" },
                    { 5, "Blade Runner 2049", new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.1m, 2, 2017, "Denis Villeneuve" },
                    { 6, "The Godfather", new DateTime(2026, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.6m, 3, 1972, "Francis Ford Coppola" },
                    { 7, "Pulp Fiction", new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.3m, 3, 1994, "Quentin Tarantino" },
                    { 8, "Ruhların Kaçışı", new DateTime(2026, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, 4, 2001, "Hayao Miyazaki" },
                    { 9, "Ratatouille", new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.9m, 4, 2007, "Brad Bird" },
                    { 10, "Hababam Sınıfı", new DateTime(2026, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.4m, 5, 1975, "Ertem Eğilmez" },
                    { 11, "The Grand Budapest Hotel", new DateTime(2026, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2m, 5, 2014, "Wes Anderson" },
                    { 12, "Parasite", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, 1, 2019, "Bong Joon-ho" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmler_TurId",
                table: "Filmler",
                column: "TurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmler");

            migrationBuilder.DropTable(
                name: "Turler");
        }
    }
}
