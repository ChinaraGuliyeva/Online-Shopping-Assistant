namespace Domain.Interfaces;

using Domain.Models;
using Domain.Enums;

//TO DO: Add interface here for  Task<string>, replace with parsed item
public interface IParserStrategy
{
    StoreSource Source { get; }
    Task<string> ParseAsync(string url, CancellationToken ct = default);
}