using AyrLyne_Personal.Data;
using AyrLyne_Personal.Models;
using AyrlyneAppLibrary.DataAccess;
using AyrlyneAppLibrary.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Web.Http;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddAuthentication("Cookies").AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["OAuth:Google:ClientID"];
        googleOptions.ClientSecret = builder.Configuration["OAuth:Google:ClientSecret"];
    }
).AddCookie();
builder.Services.AddAuthorization(options =>
    options.AddPolicy("generalUser", policy => policy.RequireRole("customer"))
);
builder.Services.AddScoped<ISignInUser, SignInUser>();

builder.Services.AddSingleton<IDbConnection, DbConnection>();
builder.Services.AddSingleton<IRegionData, MySQLRegionData>();
builder.Services.AddSingleton<IStateData, MySQLStateData>();
builder.Services.AddSingleton<IUserData, MySQLUserData>();
builder.Services.AddSingleton<IAirportData, MySQLAirportData>();
builder.Services.AddSingleton<IAirportConnectionData, MySQLAirportConnectionData>();

builder.Services.AddHttpContextAccessor();

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


app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{data}",
    defaults: new { controller = "AuthCallback", 
                    action = "CallBack", 
                    data = new GoogleSignInFormData { 
                        clientID = RouteParameter.Optional.ToString(), 
                        credential = RouteParameter.Optional.ToString(),
                        g_csrf_token = RouteParameter.Optional.ToString(),
                        select_by = RouteParameter.Optional.ToString()
                    } });

app.Run();
