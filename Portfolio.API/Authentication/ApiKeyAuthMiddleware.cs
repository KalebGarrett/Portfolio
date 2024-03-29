﻿using Portfolio.API.Constants;

namespace Portfolio.API.Authentication;

public class ApiKeyAuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public ApiKeyAuthMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            if (!context.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key Header Is Missing");
            }
            else
            {
                var apiKey = _configuration.GetValue<string>(AuthConstants.ApiKeySectionName);

                if (!apiKey.Equals(extractedApiKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Invalid API Key");
                }
                else
                {
                    await _next(context);
                }
            }
        }
        catch (Exception e)
        {
            await context.Response.WriteAsync(e.Message);
        }
    }
}