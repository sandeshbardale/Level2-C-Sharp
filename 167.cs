using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ApiConsumptionExample
{
    // Sample model class
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            using HttpClient client = new HttpClient();

            Console.WriteLine("=== API Consumption using HttpClient ===\n");

            // Example 1: GET Request
            string url = "https://jsonplaceholder.typicode.com/posts/1";
            Console.WriteLine("Sending GET request...");
            Post post = await client.GetFromJsonAsync<Post>(url);
            Console.WriteLine($"Post ID: {post.Id}, Title: {post.Title}\n");

            // Example 2: POST Request
            Console.WriteLine("Sending POST request...");
            var newPost = new Post
            {
                UserId = 1,
                Title = "Hello World",
                Body = "This is a test post"
            };

            HttpResponseMessage response = await client.PostAsJsonAsync("https://jsonplaceholder.typicode.com/posts", newPost);
            if (response.IsSuccessStatusCode)
            {
                Post createdPost = await response.Content.ReadFromJsonAsync<Post>();
                Console.WriteLine($"Created Post ID: {createdPost.Id}, Title: {createdPost.Title}");
            }
            else
            {
                Console.WriteLine($"Failed to create post. Status code: {response.StatusCode}");
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}