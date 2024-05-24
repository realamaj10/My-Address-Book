using address_bk.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
               .AddCookie(options =>
               {
                   options.Cookie.HttpOnly = true;
                   options.LoginPath = new PathString("/Auth/Login");
                   options.Cookie.Name = "Addr";
                   options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                   options.SlidingExpiration = true;

               });

builder.Services.AddDbContext<BookDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetValue<string>("ConnStr:DBConnStr")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BookDBContext>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BookContacts}/{action=Index}/{id?}");

app.Run();
