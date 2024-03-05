using System.Text.Json;
using Portfolio.Models;
using Portfolio.Web.Constants;

namespace Portfolio.Web.Services;

public class ProjectService
{
    private readonly IConfiguration _configuration;

    public ProjectService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<Project>> GetAll()
    {
        using var client = new HttpClient();

        var apiKey = _configuration.GetValue<string>(AuthConstants.ApiKeySectionName);
        var requestHeader = AuthConstants.ApiKeyHeaderName;
        
        client.DefaultRequestHeaders.Add(requestHeader, apiKey);
        var response = await client.GetAsync("https://kalebgarrettapi.azurewebsites.net/projects");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var projects = JsonSerializer.Deserialize<List<Project>>(json);
            Console.WriteLine(projects);
            return projects;
        }

        return new List<Project>();
    }
}