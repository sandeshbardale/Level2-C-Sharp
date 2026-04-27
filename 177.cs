using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MiniERPFileConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Mini ERP File Upload/Download Demo\n");

            using HttpClient client = new HttpClient();
            string baseUrl = "http://localhost:5000/api/file"; // Your API base URL

            // 1. Upload a file
            string filePath = "sample.txt";
            File.WriteAllText(filePath, "Hello from Mini ERP!");

            using var form = new MultipartFormDataContent();
            using var fileStream = File.OpenRead(filePath);
            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            form.Add(fileContent, "file", Path.GetFileName(filePath));

            var uploadResponse = await client.PostAsync($"{baseUrl}/upload", form);
            if (uploadResponse.IsSuccessStatusCode)
            {
                Console.WriteLine($"File '{filePath}' uploaded successfully!");
            }
            else
            {
                Console.WriteLine("File upload failed.");
            }

            // 2. List uploaded files
            var listResponse = await client.GetAsync($"{baseUrl}/list");
            if (listResponse.IsSuccessStatusCode)
            {
                var files = await listResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"\nUploaded files:\n{files}");
            }

            // 3. Download the uploaded file
            var downloadResponse = await client.GetAsync($"{baseUrl}/download/{Path.GetFileName(filePath)}");
            if (downloadResponse.IsSuccessStatusCode)
            {
                var downloadedBytes = await downloadResponse.Content.ReadAsByteArrayAsync();
                string downloadedPath = "downloaded_" + Path.GetFileName(filePath);
                await File.WriteAllBytesAsync(downloadedPath, downloadedBytes);
                Console.WriteLine($"\nFile downloaded successfully as '{downloadedPath}'");
            }
            else
            {
                Console.WriteLine("File download failed.");
            }
        }
    }
}