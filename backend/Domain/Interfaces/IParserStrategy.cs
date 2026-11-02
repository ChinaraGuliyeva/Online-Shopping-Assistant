namespace Domain.Interfaces;

using Domain.Models;
using Domain.Enums;

public interface IParserStrategy
{
    StoreSource Source { get; }
    Task<ParsedItem> ParseAsync(string url, CancellationToken ct = default);
}