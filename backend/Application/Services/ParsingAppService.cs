namespace Application.Services;

using Application.Interfaces;

//TO DO: Add DTO to result, ets
public class ParsingAppService : IOutfitParsingService
{
    private readonly IParserFactory _parserFactory;

    public ParsingAppService(IParserFactory parserFactory)
    {
        _parserFactory = parserFactory;
    }

    public async Task<string> ProcessOutfitAsync(Stream imageStream, string contentType, CancellationToken ct)
    {
        var strategy = _parserFactory.GetStrategy(contentType);

        string rawResult = await strategy.ParseAsync(imageStream, ct);

        return rawResult;
    }
}