using Microsoft.EntityFrameworkCore;
using Irimia_web.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AccessPolicy", policy => policy.RequireRole("Admin", "Asistent"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Servicii");
    options.Conventions.AllowAnonymousToPage("/Servcii/Index");
    options.Conventions.AllowAnonymousToPage("/Servicii/Details");
    options.Conventions.AuthorizeFolder("/Programari", "AccessPolicy");
    options.Conventions.AuthorizeFolder("/Pacienti", "AccessPolicy");
});
builder.Services.AddDbContext<Irimia_webContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Irimia_webContext") ?? throw new InvalidOperationException("Connection string 'Irimia_webContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Irimia_webContext") ?? throw new InvalidOperationException("Connection string 'Irimia_webContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
