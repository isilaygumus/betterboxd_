using betterboxd_web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace betterboxd_web.Data;

public class BetterboxdContext : IdentityDbContext<IdentityUser>
{
    //internal readonly object Movies;

    public BetterboxdContext(DbContextOptions<BetterboxdContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<WatchlistItem> WatchlistItems { get; set; }
    public DbSet<MovieList> Lists { get; set; }
    public DbSet<ListMovie> ListMovies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Identity için şart

        modelBuilder.Entity<IdentityUser>().ToTable("Users");

        modelBuilder.Entity<Review>().Property(r => r.Rating).HasPrecision(2, 1);

        // Aynı film bir kullanıcının izleme listesine iki kez eklenemesin
        modelBuilder.Entity<WatchlistItem>()
            .HasIndex(w => new { w.UserId, w.MovieId }).IsUnique();

        // Liste ile film arasındaki çoka-çok ilişki
        modelBuilder.Entity<ListMovie>().HasKey(lm => new { lm.MovieListId, lm.MovieId }); 

        // Örnek veriler: sayfa boş görünmesin diye
        modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Ad = "Dram" },
                new Genre { Id = 2, Ad = "Bilim Kurgu" },
                new Genre { Id = 3, Ad = "Suç" },
                new Genre { Id = 4, Ad = "Animasyon" },
                new Genre { Id = 5, Ad = "Komedi" },
                new Genre { Id = 6, Ad = "Korku" },
                new Genre { Id = 7, Ad = "Romantik" },
                new Genre { Id = 8, Ad = "Gerilim" }
            );

            const string afis = "https://image.tmdb.org/t/p/w342";

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Parazit", Director = "Bong Joon-ho", Year = 2019, Rating = 4.5m, GenreId = 8, AddedDate = new DateTime(2026, 9, 1), PosterUrl = afis + "/nx7TmJDMkgyBc09DVo5ze52Wt3F.jpg" },
                new Movie { Id = 2, Title = "Yıldızlararası", Director = "Christopher Nolan", Year = 2014, Rating = 4.4m, GenreId = 2, AddedDate = new DateTime(2026, 9, 3), PosterUrl = afis + "/xbiycuc84TrieEWwkkuH2hoEa9S.jpg" },
                new Movie { Id = 3, Title = "Dövüş Kulübü", Director = "David Fincher", Year = 1999, Rating = 4.3m, GenreId = 1, AddedDate = new DateTime(2026, 9, 5), PosterUrl = afis + "/yjMuqAyJUoQZGWsZ0vZuYj5inAR.jpg" },
                new Movie { Id = 4, Title = "Aşıklar Şehri", Director = "Damien Chazelle", Year = 2016, Rating = 4.1m, GenreId = 7, AddedDate = new DateTime(2026, 9, 7), PosterUrl = afis + "/xDBZNak6HyOEjKIbrjqDxllWXRn.jpg" },
                new Movie { Id = 5, Title = "Ucuz Roman", Director = "Quentin Tarantino", Year = 1994, Rating = 4.3m, GenreId = 3, AddedDate = new DateTime(2026, 9, 9), PosterUrl = afis + "/AgY33Wtg4737MhYopJSFyKWhKsO.jpg" },
                new Movie { Id = 6, Title = "Baba", Director = "Francis Ford Coppola", Year = 1972, Rating = 4.5m, GenreId = 3, AddedDate = new DateTime(2026, 9, 11), PosterUrl = afis + "/vseIVRdN4xasYwStQIi6SI7DcEu.jpg" },
                new Movie { Id = 7, Title = "Whiplash", Director = "Damien Chazelle", Year = 2014, Rating = 4.5m, GenreId = 1, AddedDate = new DateTime(2026, 9, 13), PosterUrl = afis + "/q3Ev5vIC3fklycV9kfpVIdbRe14.jpg" },
                new Movie { Id = 8, Title = "Ruhların Kaçışı", Director = "Hayao Miyazaki", Year = 2001, Rating = 4.5m, GenreId = 4, AddedDate = new DateTime(2026, 9, 15), PosterUrl = afis + "/xvOEOMCzfV8qXkd1n1btZ8q4Psd.jpg" },
                new Movie { Id = 9, Title = "Her Şey Her Yerde Aynı Anda", Director = "Daniel Kwan, Daniel Scheinert", Year = 2022, Rating = 4.3m, GenreId = 2, AddedDate = new DateTime(2026, 9, 17), PosterUrl = afis + "/vt5Fd1wouNEL7HN3TQ0PMls4auE.jpg" },
                new Movie { Id = 10, Title = "Barbie", Director = "Greta Gerwig", Year = 2023, Rating = 3.7m, GenreId = 5, AddedDate = new DateTime(2026, 9, 19), PosterUrl = afis + "/iPtla6hJOerwsgw0zMxyEI6pR3Q.jpg" },
                new Movie { Id = 11, Title = "Oppenheimer", Director = "Christopher Nolan", Year = 2023, Rating = 4.2m, GenreId = 1, AddedDate = new DateTime(2026, 9, 21), PosterUrl = afis + "/mmZi0tyPFfbcCqEsJIPxVldCPOL.jpg" },
                new Movie { Id = 12, Title = "Dune: Çöl Gezegeni Bölüm İki", Director = "Denis Villeneuve", Year = 2024, Rating = 4.4m, GenreId = 2, AddedDate = new DateTime(2026, 9, 23), PosterUrl = afis + "/tihf8Trht9zP3scmUQfvGlAY9FU.jpg" },
                new Movie { Id = 13, Title = "Başka Bir Hayatta", Director = "Celine Song", Year = 2023, Rating = 4.2m, GenreId = 7, AddedDate = new DateTime(2026, 9, 25), PosterUrl = afis + "/ndE4NbhoNGFcnICbkhvpExdFp8W.jpg" },
                new Movie { Id = 14, Title = "Kapan", Director = "Jordan Peele", Year = 2017, Rating = 4.1m, GenreId = 6, AddedDate = new DateTime(2026, 9, 27), PosterUrl = afis + "/2Uo7WiwHKb27i8Qskqy4arxaoLz.jpg" },
                new Movie { Id = 15, Title = "Kara Şövalye", Director = "Christopher Nolan", Year = 2008, Rating = 4.5m, GenreId = 3, AddedDate = new DateTime(2026, 9, 29), PosterUrl = afis + "/7IPCEr7ifdH5CtU97QG7XgAAtOp.jpg" },
                new Movie { Id = 16, Title = "Büyük Budapeşte Oteli", Director = "Wes Anderson", Year = 2014, Rating = 4.2m, GenreId = 5, AddedDate = new DateTime(2026, 10, 1), PosterUrl = afis + "/hYdclrAOjWtxTgE7PZy102hTYAf.jpg" },
                new Movie { Id = 17, Title = "Güneş Sonrası", Director = "Charlotte Wells", Year = 2022, Rating = 4.2m, GenreId = 1, AddedDate = new DateTime(2026, 10, 3), PosterUrl = afis + "/cfW5wPV3cO01ObD6WeQ8fagImzt.jpg" },
                new Movie { Id = 18, Title = "Ritüel", Director = "Ari Aster", Year = 2019, Rating = 3.9m, GenreId = 6, AddedDate = new DateTime(2026, 10, 5), PosterUrl = afis + "/4hUSc9oKcudbYOyt8EVP65LnaQV.jpg" },
                new Movie { Id = 19, Title = "Yaman Tilki", Director = "Wes Anderson", Year = 2009, Rating = 4.2m, GenreId = 4, AddedDate = new DateTime(2026, 10, 7), PosterUrl = afis + "/yfQJWTnARrunzLFjKnU89z6GZv6.jpg" },
                new Movie { Id = 20, Title = "Uğur Böceği", Director = "Greta Gerwig", Year = 2017, Rating = 3.9m, GenreId = 5, AddedDate = new DateTime(2026, 10, 9), PosterUrl = afis + "/5aKzS6YqMIAOOJwtNzLgB7vt9xE.jpg" }
            );
        
    }
}
