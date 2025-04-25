using Microsoft.EntityFrameworkCore;
using SkillLinkCMS.Models;
using Microsoft.AspNetCore.Identity;
using SkillLinkCMS.Data;
using SkillLinkCMS.Services;
using SkillLinkCMS.Pages.Admin;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

// Use SQLite instead of SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); // SQLite configuration


builder.Services.AddRazorPages();
builder.Services.AddScoped<SiteSettingsService>();

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DbInitializer.SeedSettings(db);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
