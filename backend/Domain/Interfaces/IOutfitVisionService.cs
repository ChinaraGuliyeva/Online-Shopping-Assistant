namespace Domain.Interfaces;
public interface IOutfitVisionService
{
    Task<string> AnalyzeProductFromUrlAsync(string productUrl, CancellationToken cancellationToken = default);
}