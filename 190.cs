using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configure authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
{
    options.ClientId = "YOUR_GOOGLE_CLIENT_ID";
    options.ClientSecret = "YOUR_GOOGLE_CLIENT_SECRET";
})
.AddMicrosoftAccount(microsoftOptions =>
{
    microsoftOptions.ClientId = "YOUR_MICROSOFT_CLIENT_ID";
    microsoftOptions.ClientSecret = "YOUR_MICROSOFT_CLIENT_SECRET";
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Login endpoints
app.MapGet("/", () => "Welcome to Mini ERP OAuth Example!");

app.MapGet("/login-google", async (context) =>
{
    await context.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    {
        RedirectUri = "/oauth-success"
    });
});

app.MapGet("/login-microsoft", async (context) =>
{
    await context.ChallengeAsync(MicrosoftAccountDefaults.AuthenticationScheme, new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    {
        RedirectUri = "/oauth-success"
    });
});

app.MapGet("/oauth-success", (context) =>
{
    var user = context.User.Identity;
    return Results.Ok(new { user.Name, IsAuthenticated = user.IsAuthenticated });
});

app.Run();