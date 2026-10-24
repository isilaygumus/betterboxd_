using betterboxd_web.Models;
using Microsoft.EntityFrameworkCore;

namespace betterboxd_web.Data
{
    public class BetterboxdContext : DbContext
    {
        public BetterboxdContext(DbContextOptions<BetterboxdContext> options) : base(options)
        {
        }

        public DbSet<Film> Filmler { get; set; }
        public DbSet<Tur> Turler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Örnek veriler: sayfa boş görünmesin diye
            modelBuilder.Entity<Tur>().HasData(
                new Tur { Id = 1, Ad = "Dram" },
                new Tur { Id = 2, Ad = "Bilim Kurgu" },
                new Tur { Id = 3, Ad = "Suç" },
                new Tur { Id = 4, Ad = "Animasyon" },
                new Tur { Id = 5, Ad = "Komedi" },
                new Tur { Id = 6, Ad = "Korku" },
                new Tur { Id = 7, Ad = "Romantik" },
                new Tur { Id = 8, Ad = "Gerilim" }
            );

            // Afişler TMDB'den (The Movie Database) geliyor, adresin başı hep aynı
            const string afis = "https://image.tmdb.org/t/p/w342";

            // Letterboxd'nin popüler filmleri (puanlar yaklaşık, örnek amaçlı)
            modelBuilder.Entity<Film>().HasData(
                new Film { Id = 1, Ad = "Parazit", Yonetmen = "Bong Joon-ho", Yil = 2019, Puan = 4.5m, TurId = 8, EklenmeTarihi = new DateTime(2026, 9, 1), AfisUrl = afis + "/nx7TmJDMkgyBc09DVo5ze52Wt3F.jpg" },
                new Film { Id = 2, Ad = "Yıldızlararası", Yonetmen = "Christopher Nolan", Yil = 2014, Puan = 4.4m, TurId = 2, EklenmeTarihi = new DateTime(2026, 9, 3), AfisUrl = afis + "/xbiycuc84TrieEWwkkuH2hoEa9S.jpg" },
                new Film { Id = 3, Ad = "Dövüş Kulübü", Yonetmen = "David Fincher", Yil = 1999, Puan = 4.3m, TurId = 1, EklenmeTarihi = new DateTime(2026, 9, 5), AfisUrl = afis + "/yjMuqAyJUoQZGWsZ0vZuYj5inAR.jpg" },
                new Film { Id = 4, Ad = "Aşıklar Şehri", Yonetmen = "Damien Chazelle", Yil = 2016, Puan = 4.1m, TurId = 7, EklenmeTarihi = new DateTime(2026, 9, 7), AfisUrl = afis + "/xDBZNak6HyOEjKIbrjqDxllWXRn.jpg" },
                new Film { Id = 5, Ad = "Ucuz Roman", Yonetmen = "Quentin Tarantino", Yil = 1994, Puan = 4.3m, TurId = 3, EklenmeTarihi = new DateTime(2026, 9, 9), AfisUrl = afis + "/AgY33Wtg4737MhYopJSFyKWhKsO.jpg" },
                new Film { Id = 6, Ad = "Baba", Yonetmen = "Francis Ford Coppola", Yil = 1972, Puan = 4.5m, TurId = 3, EklenmeTarihi = new DateTime(2026, 9, 11), AfisUrl = afis + "/vseIVRdN4xasYwStQIi6SI7DcEu.jpg" },
                new Film { Id = 7, Ad = "Whiplash", Yonetmen = "Damien Chazelle", Yil = 2014, Puan = 4.5m, TurId = 1, EklenmeTarihi = new DateTime(2026, 9, 13), AfisUrl = afis + "/q3Ev5vIC3fklycV9kfpVIdbRe14.jpg" },
                new Film { Id = 8, Ad = "Ruhların Kaçışı", Yonetmen = "Hayao Miyazaki", Yil = 2001, Puan = 4.5m, TurId = 4, EklenmeTarihi = new DateTime(2026, 9, 15), AfisUrl = afis + "/xvOEOMCzfV8qXkd1n1btZ8q4Psd.jpg" },
                new Film { Id = 9, Ad = "Her Şey Her Yerde Aynı Anda", Yonetmen = "Daniel Kwan, Daniel Scheinert", Yil = 2022, Puan = 4.3m, TurId = 2, EklenmeTarihi = new DateTime(2026, 9, 17), AfisUrl = afis + "/vt5Fd1wouNEL7HN3TQ0PMls4auE.jpg" },
                new Film { Id = 10, Ad = "Barbie", Yonetmen = "Greta Gerwig", Yil = 2023, Puan = 3.7m, TurId = 5, EklenmeTarihi = new DateTime(2026, 9, 19), AfisUrl = afis + "/iPtla6hJOerwsgw0zMxyEI6pR3Q.jpg" },
                new Film { Id = 11, Ad = "Oppenheimer", Yonetmen = "Christopher Nolan", Yil = 2023, Puan = 4.2m, TurId = 1, EklenmeTarihi = new DateTime(2026, 9, 21), AfisUrl = afis + "/mmZi0tyPFfbcCqEsJIPxVldCPOL.jpg" },
                new Film { Id = 12, Ad = "Dune: Çöl Gezegeni Bölüm İki", Yonetmen = "Denis Villeneuve", Yil = 2024, Puan = 4.4m, TurId = 2, EklenmeTarihi = new DateTime(2026, 9, 23), AfisUrl = afis + "/tihf8Trht9zP3scmUQfvGlAY9FU.jpg" },
                new Film { Id = 13, Ad = "Başka Bir Hayatta", Yonetmen = "Celine Song", Yil = 2023, Puan = 4.2m, TurId = 7, EklenmeTarihi = new DateTime(2026, 9, 25), AfisUrl = afis + "/ndE4NbhoNGFcnICbkhvpExdFp8W.jpg" },
                new Film { Id = 14, Ad = "Kapan", Yonetmen = "Jordan Peele", Yil = 2017, Puan = 4.1m, TurId = 6, EklenmeTarihi = new DateTime(2026, 9, 27), AfisUrl = afis + "/2Uo7WiwHKb27i8Qskqy4arxaoLz.jpg" },
                new Film { Id = 15, Ad = "Kara Şövalye", Yonetmen = "Christopher Nolan", Yil = 2008, Puan = 4.5m, TurId = 3, EklenmeTarihi = new DateTime(2026, 9, 29), AfisUrl = afis + "/7IPCEr7ifdH5CtU97QG7XgAAtOp.jpg" },
                new Film { Id = 16, Ad = "Büyük Budapeşte Oteli", Yonetmen = "Wes Anderson", Yil = 2014, Puan = 4.2m, TurId = 5, EklenmeTarihi = new DateTime(2026, 10, 1), AfisUrl = afis + "/hYdclrAOjWtxTgE7PZy102hTYAf.jpg" },
                new Film { Id = 17, Ad = "Güneş Sonrası", Yonetmen = "Charlotte Wells", Yil = 2022, Puan = 4.2m, TurId = 1, EklenmeTarihi = new DateTime(2026, 10, 3), AfisUrl = afis + "/cfW5wPV3cO01ObD6WeQ8fagImzt.jpg" },
                new Film { Id = 18, Ad = "Ritüel", Yonetmen = "Ari Aster", Yil = 2019, Puan = 3.9m, TurId = 6, EklenmeTarihi = new DateTime(2026, 10, 5), AfisUrl = afis + "/4hUSc9oKcudbYOyt8EVP65LnaQV.jpg" },
                new Film { Id = 19, Ad = "Yaman Tilki", Yonetmen = "Wes Anderson", Yil = 2009, Puan = 4.2m, TurId = 4, EklenmeTarihi = new DateTime(2026, 10, 7), AfisUrl = afis + "/yfQJWTnARrunzLFjKnU89z6GZv6.jpg" },
                new Film { Id = 20, Ad = "Uğur Böceği", Yonetmen = "Greta Gerwig", Yil = 2017, Puan = 3.9m, TurId = 5, EklenmeTarihi = new DateTime(2026, 10, 9), AfisUrl = afis + "/5aKzS6YqMIAOOJwtNzLgB7vt9xE.jpg" }
            );
        }
    }
}
