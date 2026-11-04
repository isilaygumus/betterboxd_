using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace betterboxd_web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Director = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric(2,1)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PosterUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmler_Turler_GenreId",
                        column: x => x.GenreId,
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
                    { 5, "Komedi" },
                    { 6, "Korku" },
                    { 7, "Romantik" },
                    { 8, "Gerilim" }
                });

            migrationBuilder.InsertData(
                table: "Filmler",
                columns: new[] { "Id", "AddedDate", "Director", "GenreId", "PosterUrl", "Rating", "Title", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bong Joon-ho", 8, "https://image.tmdb.org/t/p/w342/nx7TmJDMkgyBc09DVo5ze52Wt3F.jpg", 4.5m, "Parazit", 2019 },
                    { 2, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christopher Nolan", 2, "https://image.tmdb.org/t/p/w342/xbiycuc84TrieEWwkkuH2hoEa9S.jpg", 4.4m, "Yıldızlararası", 2014 },
                    { 3, new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Fincher", 1, "https://image.tmdb.org/t/p/w342/yjMuqAyJUoQZGWsZ0vZuYj5inAR.jpg", 4.3m, "Dövüş Kulübü", 1999 },
                    { 4, new DateTime(2026, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Damien Chazelle", 7, "https://image.tmdb.org/t/p/w342/xDBZNak6HyOEjKIbrjqDxllWXRn.jpg", 4.1m, "Aşıklar Şehri", 2016 },
                    { 5, new DateTime(2026, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quentin Tarantino", 3, "https://image.tmdb.org/t/p/w342/AgY33Wtg4737MhYopJSFyKWhKsO.jpg", 4.3m, "Ucuz Roman", 1994 },
                    { 6, new DateTime(2026, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Francis Ford Coppola", 3, "https://image.tmdb.org/t/p/w342/vseIVRdN4xasYwStQIi6SI7DcEu.jpg", 4.5m, "Baba", 1972 },
                    { 7, new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Damien Chazelle", 1, "https://image.tmdb.org/t/p/w342/q3Ev5vIC3fklycV9kfpVIdbRe14.jpg", 4.5m, "Whiplash", 2014 },
                    { 8, new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hayao Miyazaki", 4, "https://image.tmdb.org/t/p/w342/xvOEOMCzfV8qXkd1n1btZ8q4Psd.jpg", 4.5m, "Ruhların Kaçışı", 2001 },
                    { 9, new DateTime(2026, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Kwan, Daniel Scheinert", 2, "https://image.tmdb.org/t/p/w342/vt5Fd1wouNEL7HN3TQ0PMls4auE.jpg", 4.3m, "Her Şey Her Yerde Aynı Anda", 2022 },
                    { 10, new DateTime(2026, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greta Gerwig", 5, "https://image.tmdb.org/t/p/w342/iPtla6hJOerwsgw0zMxyEI6pR3Q.jpg", 3.7m, "Barbie", 2023 },
                    { 11, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christopher Nolan", 1, "https://image.tmdb.org/t/p/w342/mmZi0tyPFfbcCqEsJIPxVldCPOL.jpg", 4.2m, "Oppenheimer", 2023 },
                    { 12, new DateTime(2026, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Villeneuve", 2, "https://image.tmdb.org/t/p/w342/tihf8Trht9zP3scmUQfvGlAY9FU.jpg", 4.4m, "Dune: Çöl Gezegeni Bölüm İki", 2024 },
                    { 13, new DateTime(2026, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Celine Song", 7, "https://image.tmdb.org/t/p/w342/ndE4NbhoNGFcnICbkhvpExdFp8W.jpg", 4.2m, "Başka Bir Hayatta", 2023 },
                    { 14, new DateTime(2026, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordan Peele", 6, "https://image.tmdb.org/t/p/w342/2Uo7WiwHKb27i8Qskqy4arxaoLz.jpg", 4.1m, "Kapan", 2017 },
                    { 15, new DateTime(2026, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christopher Nolan", 3, "https://image.tmdb.org/t/p/w342/7IPCEr7ifdH5CtU97QG7XgAAtOp.jpg", 4.5m, "Kara Şövalye", 2008 },
                    { 16, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wes Anderson", 5, "https://image.tmdb.org/t/p/w342/hYdclrAOjWtxTgE7PZy102hTYAf.jpg", 4.2m, "Büyük Budapeşte Oteli", 2014 },
                    { 17, new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlotte Wells", 1, "https://image.tmdb.org/t/p/w342/cfW5wPV3cO01ObD6WeQ8fagImzt.jpg", 4.2m, "Güneş Sonrası", 2022 },
                    { 18, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ari Aster", 6, "https://image.tmdb.org/t/p/w342/4hUSc9oKcudbYOyt8EVP65LnaQV.jpg", 3.9m, "Ritüel", 2019 },
                    { 19, new DateTime(2026, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wes Anderson", 4, "https://image.tmdb.org/t/p/w342/yfQJWTnARrunzLFjKnU89z6GZv6.jpg", 4.2m, "Yaman Tilki", 2009 },
                    { 20, new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greta Gerwig", 5, "https://image.tmdb.org/t/p/w342/5aKzS6YqMIAOOJwtNzLgB7vt9xE.jpg", 3.9m, "Uğur Böceği", 2017 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmler_GenreId",
                table: "Filmler",
                column: "GenreId");
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
