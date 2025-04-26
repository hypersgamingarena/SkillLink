using Microsoft.AspNetCore.Authorization; // Import Authorization
using Microsoft.AspNetCore.Identity;     // Import Identity
using Microsoft.EntityFrameworkCore;      // Import Entity Framework Core
using SkillLinkCMS.Data;                  // Import Data namespace
using SkillLinkCMS.Models;                // Import Models namespace
using SkillLinkCMS.Services;              // Import Services namespace

var builder = WebApplication.CreateBuilder(args);

// Add Razor Pages services to the container.
builder.Services.AddRazorPages();

// SQLite Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// Configure Identity Framework with ApplicationUser and IdentityRole
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Configure password requirements (optional - set to false for development)
    // These are good settings for development but you should change them in production
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders()
.AddDefaultUI(); // Add default UI for Identity (Razor Pages) - this is essential for Razor Pages


// Configure Authorization with a fallback policy requiring authentication
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
// Add other services (e.g., SiteSettingsService)
builder.Services.AddScoped<SiteSettingsService>();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Use HTTPS redirection
app.UseHttpsRedirection();

// Use static files (CSS, JS, images)
app.UseStaticFiles();

// Add Routing Middleware
app.UseRouting();

// Add Authentication Middleware - MUST come before Authorization
app.UseAuthentication();

// Add Authorization Middleware - MUST come after Authentication
app.UseAuthorization();

// Seed the database - move to after building the app
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DbInitializer.SeedSettings(db);
}
// Map Razor Pages - This is essential for Razor Pages
app.MapRazorPages();
// Run the application
app.Run();
