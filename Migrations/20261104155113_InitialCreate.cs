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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
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
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric(2,1)", precision: 2, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchlistItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchlistItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchlistItems_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchlistItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListMovies",
                columns: table => new
                {
                    MovieListId = table.Column<int>(type: "integer", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListMovies", x => new { x.MovieListId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_ListMovies_Lists_MovieListId",
                        column: x => x.MovieListId,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
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
                table: "Movies",
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ListMovies_MovieId",
                table: "ListMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_UserId",
                table: "Lists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistItems_MovieId",
                table: "WatchlistItems",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistItems_UserId_MovieId",
                table: "WatchlistItems",
                columns: new[] { "UserId", "MovieId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ListMovies");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "WatchlistItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
