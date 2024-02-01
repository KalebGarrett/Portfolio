using System.Text.Json;
using Portfolio.Models;

namespace Portfolio.Web.Services;

public class ProjectService
{
    public async Task<List<Project>> GetAll()
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://kalebgarrettapi.azurewebsites.net/projects");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var projects =  JsonSerializer.Deserialize<List<Project>>(json);
            return projects;
        }

        return new List<Project>();
    }
}