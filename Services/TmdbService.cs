using System.Text.Json.Serialization;

namespace betterboxd_web.Services;

public class TmdbService
{
    private readonly HttpClient _http;
    private readonly string _apiKey;

    public TmdbService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _apiKey = config["Tmdb:ApiKey"]
            ?? throw new InvalidOperationException("Tmdb:ApiKey tanımlı değil (User Secrets).");
    }

    public async Task<List<TmdbGenre>> GetGenresAsync()
    {
        var r = await _http.GetFromJsonAsync<TmdbGenreList>(
            $"genre/movie/list?api_key={_apiKey}&language=en-US");
        return r?.Genres ?? new();
    }

    public async Task<List<TmdbMovie>> GetPopularAsync(int page)
    {
        var r = await _http.GetFromJsonAsync<TmdbMovieList>(
            $"movie/popular?api_key={_apiKey}&language=en-US&page={page}");
        return r?.Results ?? new();
    }

    public async Task<string?> GetDirectorAsync(int movieId)
    {
        var r = await _http.GetFromJsonAsync<TmdbCredits>(
            $"movie/{movieId}/credits?api_key={_apiKey}");
        return r?.Crew.FirstOrDefault(c => c.Job == "Director")?.Name;
    }
}

public class TmdbGenreList { [JsonPropertyName("genres")] public List<TmdbGenre> Genres { get; set; } = new(); }
public class TmdbGenre
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; } = "";
}

public class TmdbMovieList { [JsonPropertyName("results")] public List<TmdbMovie> Results { get; set; } = new(); }
public class TmdbMovie
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("release_date")] public string? ReleaseDate { get; set; }
    [JsonPropertyName("vote_average")] public double VoteAverage { get; set; }
    [JsonPropertyName("poster_path")] public string? PosterPath { get; set; }
    [JsonPropertyName("genre_ids")] public List<int> GenreIds { get; set; } = new();
}

public class TmdbCredits { [JsonPropertyName("crew")] public List<TmdbCrew> Crew { get; set; } = new(); }
public class TmdbCrew
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("job")] public string? Job { get; set; }
}