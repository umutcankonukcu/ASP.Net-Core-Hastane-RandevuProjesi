
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HastaneProjesi.Models;
using HastaneProjesi.Controllers;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Razor;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();



/*builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
}); */


builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
});

builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
    {
        x.Cookie.Name = "NetCoreMvc.Auth";
        x.ExpireTimeSpan = TimeSpan.FromDays(7);
        x.LoginPath = "/Account/Login/";
        x.LogoutPath = "/Account/Logut/";
        x.AccessDeniedPath = "/Home/AccessDenied/";
    });




builder.Services.AddDistributedMemoryCache();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

var suppertedCultures = new[] { "en", "tr" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(suppertedCultures[0]).AddSupportedCultures
    (suppertedCultures).AddSupportedUICultures(suppertedCultures);
app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
