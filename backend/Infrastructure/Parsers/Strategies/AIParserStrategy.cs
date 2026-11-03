// namespace Infrastructure.Parsers.Strategies;

// using Domain.Enums;
// using Domain.Interfaces;
// using Domain.Models;

// public class AiParserStrategy : IParserStrategy
// {
//     private readonly IOutfitVisionService _outfitVisionService;

//     public StoreSource Source => StoreSource.Unknown;

//     public AiParserStrategy(IOutfitVisionService outfitVisionService)
//     {
//         _outfitVisionService = outfitVisionService;
//     }

//     public async Task<ParsedItem> ParseAsync(string url, CancellationToken ct = default)
//     {
//         var rawAnalysis = await _outfitVisionService.AnalyzeProductFromUrlAsync(url, ct);

//         return new ParsedItem
//         {
//             Url = url,
//             RawDescription = rawAnalysis,
//         };
//     }
// }

//TO DO: Implement interface

namespace Infrastructure.Parsers.Strategies;

using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;

public class AiParserStrategy : IParserStrategy
{
    private readonly IOutfitVisionService _outfitVisionService;

    public StoreSource Source => StoreSource.Unknown;

    public AiParserStrategy(IOutfitVisionService outfitVisionService)
    {
        _outfitVisionService = outfitVisionService;
    }

    public async Task<ParsedItem> ParseAsync(string url, CancellationToken ct = default)
    {
        var rawAnalysis = await _outfitVisionService.AnalyzeProductFromUrlAsync(url, ct);

        return new ParsedItem
        {
            Url = url,
            Source = StoreSource.Unknown,
            Title = "AI Pending Test",
            Description = rawAnalysis?.ToString() ?? string.Empty
        };
    }
}