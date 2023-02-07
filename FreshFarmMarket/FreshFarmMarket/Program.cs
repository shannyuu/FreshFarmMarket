using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FreshFarmMarket.Models;
using AspNetCore.ReCaptcha;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppUserDbContext>();
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppUserDbContext>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
});
builder.Services.AddReCaptcha(builder.Configuration.GetSection("ReCaptcha"));
builder.Services.Configure<IdentityOptions>(opts =>
{
    opts.Lockout.AllowedForNewUsers = true;
    opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);
    opts.Lockout.MaxFailedAccessAttempts = 3;
});

builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options=>
{
    options.Cookie.Name = "MyCookieAuth";
    options.AccessDeniedPath = "/AccessDenied";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MustBeUser",
     policy => policy.RequireClaim("User", "AppUser"));
});

builder.Services.AddDataProtection();

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

app.UseSession();

app.UseStatusCodePagesWithRedirects("/{0}");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
