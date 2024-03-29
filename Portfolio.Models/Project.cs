﻿using System.Text.Json.Serialization;

namespace Portfolio.Models;

public class Project
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("projectName")]
    public string ProjectName { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("challenges")]
    public string Challenges { get; set; }

    [JsonPropertyName("solutions")]
    public string Solutions { get; set; }

    [JsonPropertyName("whatILearned")]
    public string WhatILearned { get; set; }
    
    [JsonPropertyName("applicationUrl")]
    public string ApplicationUrl { get; set; }
    
    [JsonPropertyName("gitHubUrl")]
    public string GitHubUrl { get; set; }
    
    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }
}