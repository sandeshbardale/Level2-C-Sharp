using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Azure Blob Storage connection
string blobConnectionString = "DefaultEndpointsProtocol=https;AccountName=YOUR_ACCOUNT_NAME;AccountKey=YOUR_ACCOUNT_KEY;EndpointSuffix=core.windows.net";
string containerName = "minierpfiles";

builder.Services.AddSingleton(new BlobServiceClient(blobConnectionString));

var app = builder.Build();

// Upload file
app.MapPost("/api/upload", async (IFormFile file, BlobServiceClient blobServiceClient) =>
{
    var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
    await containerClient.CreateIfNotExistsAsync();

    var blobClient = containerClient.GetBlobClient(file.FileName);
    using var stream = file.OpenReadStream();
    await blobClient.UploadAsync(stream, overwrite: true);

    return Results.Ok(new { message = $"File '{file.FileName}' uploaded successfully." });
});

// Download file
app.MapGet("/api/download/{filename}", async (string filename, BlobServiceClient blobServiceClient) =>
{
    var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
    var blobClient = containerClient.GetBlobClient(filename);

    if (!await blobClient.ExistsAsync()) return Results.NotFound();

    var download = await blobClient.DownloadAsync();
    return Results.File(download.Value.Content, "application/octet-stream", filename);
});

app.Run();