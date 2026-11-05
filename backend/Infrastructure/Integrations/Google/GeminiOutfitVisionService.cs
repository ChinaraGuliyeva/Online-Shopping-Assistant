namespace Infrastructure.Integrations.Google;

using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Mscc.GenerativeAI;
using Mscc.GenerativeAI.Types;

public class GeminiOutfitVisionService : IOutfitVisionService
{
    private readonly GoogleAI _googleAi;

    private const string ModelName = "gemini-3.8-flash";

    public GeminiOutfitVisionService(IConfiguration configuration)
    {
        var apiKey = configuration["Gemini:ApiKey"]
            ?? throw new ArgumentNullException("Gemini:ApiKey not configured");

        _googleAi = new GoogleAI(apiKey);
    }

    public async Task<string> AnalyzeProductFromUrlAsync(string productUrl, CancellationToken cancellationToken = default)
    {
        var model = _googleAi.GenerativeModel(model: ModelName);

        var prompt = $"Follow the link and provide a detailed description of the clothing, including the brand and its specifications: {productUrl}";

        var request = new GenerateContentRequest
        {
            Contents = [new Content(prompt)],
            Tools = [new Tool { GoogleSearch = new GoogleSearch() }]
        };

        var response = await model.GenerateContent(request, cancellationToken: cancellationToken);

        return response.Text ?? string.Empty;
    }
}