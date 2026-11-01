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
                    Ad = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Yonetmen = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Yil = table.Column<int>(type: "integer", nullable: false),
                    Puan = table.Column<decimal>(type: "numeric(2,1)", nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AfisUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    TurId = table.Column<int>(type: "integer", nullable: false)
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
                    { 5, "Komedi" },
                    { 6, "Korku" },
                    { 7, "Romantik" },
                    { 8, "Gerilim" }
                });

            migrationBuilder.InsertData(
                table: "Filmler",
                columns: new[] { "Id", "Ad", "AfisUrl", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[,]
                {
                    { 1, "Parazit", "https://image.tmdb.org/t/p/w342/nx7TmJDMkgyBc09DVo5ze52Wt3F.jpg", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, 8, 2019, "Bong Joon-ho" },
                    { 2, "Yıldızlararası", "https://image.tmdb.org/t/p/w342/xbiycuc84TrieEWwkkuH2hoEa9S.jpg", new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.4m, 2, 2014, "Christopher Nolan" },
                    { 3, "Dövüş Kulübü", "https://image.tmdb.org/t/p/w342/yjMuqAyJUoQZGWsZ0vZuYj5inAR.jpg", new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.3m, 1, 1999, "David Fincher" },
                    { 4, "Aşıklar Şehri", "https://image.tmdb.org/t/p/w342/xDBZNak6HyOEjKIbrjqDxllWXRn.jpg", new DateTime(2026, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.1m, 7, 2016, "Damien Chazelle" },
                    { 5, "Ucuz Roman", "https://image.tmdb.org/t/p/w342/AgY33Wtg4737MhYopJSFyKWhKsO.jpg", new DateTime(2026, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.3m, 3, 1994, "Quentin Tarantino" },
                    { 6, "Baba", "https://image.tmdb.org/t/p/w342/vseIVRdN4xasYwStQIi6SI7DcEu.jpg", new DateTime(2026, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, 3, 1972, "Francis Ford Coppola" },
                    { 7, "Whiplash", "https://image.tmdb.org/t/p/w342/q3Ev5vIC3fklycV9kfpVIdbRe14.jpg", new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, 1, 2014, "Damien Chazelle" },
                    { 8, "Ruhların Kaçışı", "https://image.tmdb.org/t/p/w342/xvOEOMCzfV8qXkd1n1btZ8q4Psd.jpg", new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, 4, 2001, "Hayao Miyazaki" },
                    { 9, "Her Şey Her Yerde Aynı Anda", "https://image.tmdb.org/t/p/w342/vt5Fd1wouNEL7HN3TQ0PMls4auE.jpg", new DateTime(2026, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.3m, 2, 2022, "Daniel Kwan, Daniel Scheinert" },
                    { 10, "Barbie", "https://image.tmdb.org/t/p/w342/iPtla6hJOerwsgw0zMxyEI6pR3Q.jpg", new DateTime(2026, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.7m, 5, 2023, "Greta Gerwig" },
                    { 11, "Oppenheimer", "https://image.tmdb.org/t/p/w342/mmZi0tyPFfbcCqEsJIPxVldCPOL.jpg", new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2m, 1, 2023, "Christopher Nolan" },
                    { 12, "Dune: Çöl Gezegeni Bölüm İki", "https://image.tmdb.org/t/p/w342/tihf8Trht9zP3scmUQfvGlAY9FU.jpg", new DateTime(2026, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.4m, 2, 2024, "Denis Villeneuve" },
                    { 13, "Başka Bir Hayatta", "https://image.tmdb.org/t/p/w342/ndE4NbhoNGFcnICbkhvpExdFp8W.jpg", new DateTime(2026, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2m, 7, 2023, "Celine Song" },
                    { 14, "Kapan", "https://image.tmdb.org/t/p/w342/2Uo7WiwHKb27i8Qskqy4arxaoLz.jpg", new DateTime(2026, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.1m, 6, 2017, "Jordan Peele" },
                    { 15, "Kara Şövalye", "https://image.tmdb.org/t/p/w342/7IPCEr7ifdH5CtU97QG7XgAAtOp.jpg", new DateTime(2026, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, 3, 2008, "Christopher Nolan" },
                    { 16, "Büyük Budapeşte Oteli", "https://image.tmdb.org/t/p/w342/hYdclrAOjWtxTgE7PZy102hTYAf.jpg", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2m, 5, 2014, "Wes Anderson" },
                    { 17, "Güneş Sonrası", "https://image.tmdb.org/t/p/w342/cfW5wPV3cO01ObD6WeQ8fagImzt.jpg", new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2m, 1, 2022, "Charlotte Wells" },
                    { 18, "Ritüel", "https://image.tmdb.org/t/p/w342/4hUSc9oKcudbYOyt8EVP65LnaQV.jpg", new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.9m, 6, 2019, "Ari Aster" },
                    { 19, "Yaman Tilki", "https://image.tmdb.org/t/p/w342/yfQJWTnARrunzLFjKnU89z6GZv6.jpg", new DateTime(2026, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2m, 4, 2009, "Wes Anderson" },
                    { 20, "Uğur Böceği", "https://image.tmdb.org/t/p/w342/5aKzS6YqMIAOOJwtNzLgB7vt9xE.jpg", new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.9m, 5, 2017, "Greta Gerwig" }
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
