namespace Application.Interfaces;

public interface IOutfitParsingService
{
    Task<string> ProcessOutfitAsync(string url, CancellationToken ct);
}