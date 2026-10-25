# betterboxd

Letterboxd'den ilham alarak geliştirdiğimiz bir film sitesi. Filmlere göz atıp puanlarını görebileceğin, ileride yorum yazıp kendi listelerini oluşturabileceğin bir platform olmasını hedefliyoruz.

ASP.NET Core Razor Pages ve Entity Framework Core ile geliştiriliyor.

## Şu ana kadar neler yaptık

- **Giriş ve kayıt sayfaları:** Kullanıcı adı/e-posta ve şifre alanları, form doğrulamaları ve Türkçe hata mesajları hazır. Şimdilik form gönderilince ana sayfaya yönlendiriyor, gerçek üyelik sistemi (Identity) sonraki adımda eklenecek.(Işılay Gümüş)
- **Profil sayfası:** Kullanıcı adı, biyografi ve favori filmler için alanlar içeren profil tasarımı yapıldı.(Berna Demirer)
- **Tema ve renkler:** Sitenin genel renkleri koyu temaya uygun şekilde düzenlendi.(Işılay Gümüş)
- **Veritabanı**: EF Core ile `Film` ve `Tur` tabloları oluşturuldu. Bir türün birden fazla filmi olabiliyor (bire-çok ilişki). Migration'lar projede mevcut.(Zeynep Nida Erdem)
- **Örnek veriler:** Sayfalar boş görünmesin diye Letterboxd'de popüler olan 20 film ve 8 tür eklendi. Afişler TMDB'den çekiliyor.(Zeynep Nida Erdem)
- **Ana sayfa:** Filmler artık veritabanından geliyor. Ana sayfada şu bölümler var:(Zeynep Nida Erdem)
  - En yüksek puanlı filmler
  - Son eklenen filmler
  - Sitede neler yapılabileceğini anlatan kısa bir tanıtım (yorum yazma, liste oluşturma, puan verme)
  - Tüm filmlerin alfabetik listesi
- **Film kartları:** Film afişi, adı ve puanı ortak bir kart bileşeniyle gösteriliyor, böylece her sayfada aynı görünüm kullanılabiliyor.(Zeynep Nida Erdem)
- **Menü:** Ana sayfa dışındaki tüm sayfalarda menü üstte sabit duruyor, bulunduğun sayfa menüde işaretli görünüyor.(Zeynep Nida Erdem)

## Sırada ne var

- Identity ile gerçek kayıt olma / giriş yapma
- Filmlere yorum yazma ve puan verme
- Kullanıcıların kendi film listelerini oluşturması
- Profil düzenleme sayfası
- Film ve liste sayfalarının ayrı ayrı hazırlanması

## Kullanılan teknolojiler

- ASP.NET Core Razor Pages (.NET 10)
- Entity Framework Core
- SQL Server (LocalDB)
- Bootstrap
