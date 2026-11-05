using Application.Interfaces;
using Domain.Enums;

namespace Application.Services;

//TO DO: Add DTO to result, ets
public class ParsingAppService : IOutfitParsingService
{
    private readonly IParserFactory _parserFactory;

    public ParsingAppService(IParserFactory parserFactory)
    {
        _parserFactory = parserFactory;
    }

    public async Task<string> ProcessOutfitAsync(string clothUrl, CancellationToken ct)
    {
        var storeSource = StoreSourceExtensions.ResolveFromUrl(clothUrl);

        var strategy = _parserFactory.GetStrategy(storeSource);

        return await Task.FromResult($"Stub result for strategy: {strategy.GetType().Name} (Store: {storeSource})");
    }
}