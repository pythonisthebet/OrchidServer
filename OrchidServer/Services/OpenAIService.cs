using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using OrchidServer.Controllers;

namespace OrchidServer.Services;
public class OpenAIImageService
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string _apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

    //generate an image and save in in wwwroot using a user given prompt
    public async Task<string> GenerateImageAsync(string prompt, int userId,int crId, IWebHostEnvironment env)
    {
        if (string.IsNullOrWhiteSpace(prompt))
            throw new ArgumentException("Prompt must not be empty.");

        var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", apiKey);

        var requestBody = new
        {
            prompt = prompt + "in the style of a D&D adventurer",
            n = 1,
            size = "512x512"
        };

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("https://api.openai.com/v1/images/generations", content);
        var responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            //throw new Exception($"OpenAI error ({(int)response.StatusCode}): {responseString}");
            return "bad prompt";
        }


        using var doc = JsonDocument.Parse(responseString);
        var imageUrl = doc.RootElement.GetProperty("data")[0].GetProperty("url").GetString();

        // Download the image from the URL
        var imageBytes = await _httpClient.GetByteArrayAsync(imageUrl!);

        // Define the local path to save the image
        var fileName = $"Iu{userId}c{crId}.png";
        var directoryPath = $"{env.WebRootPath}\\CharacterImages\\";

        var fullFilePath = Path.Combine(directoryPath, fileName);

        // Save the file
        File.Delete(fullFilePath);
        File.WriteAllBytes(fullFilePath, imageBytes);

        return fileName; // Return local file path
    }
}