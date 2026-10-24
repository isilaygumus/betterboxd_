using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace betterboxd_web.Migrations
{
    /// <inheritdoc />
    public partial class LetterboxdFilmleriVeAfisler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AfisUrl",
                table: "Filmler",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            // Yeni türler, filmler onlara bağlanmadan önce eklenmeli
            migrationBuilder.InsertData(
                table: "Turler",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 6, "Korku" },
                    { 7, "Romantik" },
                    { 8, "Gerilim" }
                });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ad", "AfisUrl", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Parazit", "https://image.tmdb.org/t/p/w342/nx7TmJDMkgyBc09DVo5ze52Wt3F.jpg", 4.5m, 8, 2019, "Bong Joon-ho" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Ad", "AfisUrl", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Yıldızlararası", "https://image.tmdb.org/t/p/w342/xbiycuc84TrieEWwkkuH2hoEa9S.jpg", 4.4m, 2, 2014, "Christopher Nolan" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Ad", "AfisUrl", "Puan", "Yil", "Yonetmen" },
                values: new object[] { "Dövüş Kulübü", "https://image.tmdb.org/t/p/w342/yjMuqAyJUoQZGWsZ0vZuYj5inAR.jpg", 4.3m, 1999, "David Fincher" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Ad", "AfisUrl", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Aşıklar Şehri", "https://image.tmdb.org/t/p/w342/xDBZNak6HyOEjKIbrjqDxllWXRn.jpg", new DateTime(2026, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.1m, 7, 2016, "Damien Chazelle" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Ad", "AfisUrl", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Ucuz Roman", "https://image.tmdb.org/t/p/w342/AgY33Wtg4737MhYopJSFyKWhKsO.jpg", new DateTime(2026, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.3m, 3, 1994, "Quentin Tarantino" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Ad", "AfisUrl", "EklenmeTarihi", "Puan" },
                values: new object[] { "Baba", "https://image.tmdb.org/t/p/w342/vseIVRdN4xasYwStQIi6SI7DcEu.jpg", new DateTime(2026, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Ad", "AfisUrl", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Whiplash", "https://image.tmdb.org/t/p/w342/q3Ev5vIC3fklycV9kfpVIdbRe14.jpg", new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, 1, 2014, "Damien Chazelle" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AfisUrl", "EklenmeTarihi" },
                values: new object[] { "https://image.tmdb.org/t/p/w342/xvOEOMCzfV8qXkd1n1btZ8q4Psd.jpg", new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Ad", "AfisUrl", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Her Şey Her Yerde Aynı Anda", "https://image.tmdb.org/t/p/w342/vt5Fd1wouNEL7HN3TQ0PMls4auE.jpg", new DateTime(2026, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.3m, 2, 2022, "Daniel Kwan, Daniel Scheinert" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Ad", "AfisUrl", "EklenmeTarihi", "Puan", "Yil", "Yonetmen" },
                values: new object[] { "Barbie", "https://image.tmdb.org/t/p/w342/iPtla6hJOerwsgw0zMxyEI6pR3Q.jpg", new DateTime(2026, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.7m, 2023, "Greta Gerwig" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Ad", "AfisUrl", "EklenmeTarihi", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Oppenheimer", "https://image.tmdb.org/t/p/w342/mmZi0tyPFfbcCqEsJIPxVldCPOL.jpg", new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2023, "Christopher Nolan" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Ad", "AfisUrl", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Dune: Çöl Gezegeni Bölüm İki", "https://image.tmdb.org/t/p/w342/tihf8Trht9zP3scmUQfvGlAY9FU.jpg", new DateTime(2026, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.4m, 2, 2024, "Denis Villeneuve" });

            migrationBuilder.InsertData(
                table: "Filmler",
                columns: new[] { "Id", "Ad", "AfisUrl", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[,]
                {
                    { 15, "Kara Şövalye", "https://image.tmdb.org/t/p/w342/7IPCEr7ifdH5CtU97QG7XgAAtOp.jpg", new DateTime(2026, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, 3, 2008, "Christopher Nolan" },
                    { 16, "Büyük Budapeşte Oteli", "https://image.tmdb.org/t/p/w342/hYdclrAOjWtxTgE7PZy102hTYAf.jpg", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2m, 5, 2014, "Wes Anderson" },
                    { 17, "Güneş Sonrası", "https://image.tmdb.org/t/p/w342/cfW5wPV3cO01ObD6WeQ8fagImzt.jpg", new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2m, 1, 2022, "Charlotte Wells" },
                    { 19, "Yaman Tilki", "https://image.tmdb.org/t/p/w342/yfQJWTnARrunzLFjKnU89z6GZv6.jpg", new DateTime(2026, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2m, 4, 2009, "Wes Anderson" },
                    { 20, "Uğur Böceği", "https://image.tmdb.org/t/p/w342/5aKzS6YqMIAOOJwtNzLgB7vt9xE.jpg", new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.9m, 5, 2017, "Greta Gerwig" }
                });

            migrationBuilder.InsertData(
                table: "Filmler",
                columns: new[] { "Id", "Ad", "AfisUrl", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[,]
                {
                    { 13, "Başka Bir Hayatta", "https://image.tmdb.org/t/p/w342/ndE4NbhoNGFcnICbkhvpExdFp8W.jpg", new DateTime(2026, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2m, 7, 2023, "Celine Song" },
                    { 14, "Kapan", "https://image.tmdb.org/t/p/w342/2Uo7WiwHKb27i8Qskqy4arxaoLz.jpg", new DateTime(2026, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.1m, 6, 2017, "Jordan Peele" },
                    { 18, "Ritüel", "https://image.tmdb.org/t/p/w342/4hUSc9oKcudbYOyt8EVP65LnaQV.jpg", new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.9m, 6, 2019, "Ari Aster" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DropColumn(
                name: "AfisUrl",
                table: "Filmler");

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ad", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Kış Uykusu", 4.3m, 1, 2014, "Nuri Bilge Ceylan" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Ad", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Ahlat Ağacı", 4.2m, 1, 2018, "Nuri Bilge Ceylan" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Ad", "Puan", "Yil", "Yonetmen" },
                values: new object[] { "Babam ve Oğlum", 4.0m, 2005, "Çağan Irmak" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Ad", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Interstellar", new DateTime(2026, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.4m, 2, 2014, "Christopher Nolan" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Ad", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Blade Runner 2049", new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.1m, 2, 2017, "Denis Villeneuve" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Ad", "EklenmeTarihi", "Puan" },
                values: new object[] { "The Godfather", new DateTime(2026, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.6m });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Ad", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Pulp Fiction", new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.3m, 3, 1994, "Quentin Tarantino" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 8,
                column: "EklenmeTarihi",
                value: new DateTime(2026, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Ad", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Ratatouille", new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.9m, 4, 2007, "Brad Bird" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Ad", "EklenmeTarihi", "Puan", "Yil", "Yonetmen" },
                values: new object[] { "Hababam Sınıfı", new DateTime(2026, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.4m, 1975, "Ertem Eğilmez" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Ad", "EklenmeTarihi", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "The Grand Budapest Hotel", new DateTime(2026, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2014, "Wes Anderson" });

            migrationBuilder.UpdateData(
                table: "Filmler",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Ad", "EklenmeTarihi", "Puan", "TurId", "Yil", "Yonetmen" },
                values: new object[] { "Parasite", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, 1, 2019, "Bong Joon-ho" });

            // Türler en son silinmeli, önce filmler eski türlerine döner
            migrationBuilder.DeleteData(
                table: "Turler",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Turler",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Turler",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
