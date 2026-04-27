using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Azure Key Vault URL
string keyVaultUrl = "https://YOUR_KEYVAULT_NAME.vault.azure.net/";

// Register SecretClient as a singleton
builder.Services.AddSingleton(new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential()));

var app = builder.Build();

// Endpoint to get secret
app.MapGet("/api/get-secret/{secretName}", (string secretName, SecretClient secretClient) =>
{
    try
    {
        KeyVaultSecret secret = secretClient.GetSecret(secretName);
        return Results.Ok(new { name = secret.Name, value = secret.Value });
    }
    catch (Exception ex)
    {
        return Results.NotFound(new { message = $"Secret '{secretName}' not found.", error = ex.Message });
    }
});

app.Run();