namespace Application.Interfaces;

public interface IOutfitParsingService
{
    Task<string> ProcessOutfitAsync(string url, string contentType, CancellationToken ct);
}