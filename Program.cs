using betterboxd_web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using betterboxd_web.Services;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Admin", "AdminOnly");
    options.Conventions.AuthorizePage("/Profil");
});

builder.Services.AddControllers();
builder.Services.AddHttpClient<TmdbService>(client =>
    client.BaseAddress = new Uri("https://api.themoviedb.org/3/"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Veritabanı bağlantısı (bağlantı cümlesi appsettings.json içinde)
builder.Services.AddDbContext<BetterboxdContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BetterboxdContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>

{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BetterboxdContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";

});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

    var roles = new[] { "Admin", "User" };

    foreach(var  role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    var adminEmail = config["SeedAdmin:Email"]!;
    var adminPassword = config["SeedAdmin:Password"]!;

    var admin = await userManager.FindByEmailAsync(adminEmail);

    if (admin == null)
    {
        admin = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
        var result = await userManager.CreateAsync(admin, adminPassword);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(admin, "Admin");
        }
        else
        {
            Console.WriteLine("seed hata: " + string.Join(" | ", result.Errors.Select(e => e.Description)));
        }
    }

}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
