namespace Infrastructure.Parsers.Factories;

using Application.Interfaces;
using Domain.Enums;
using Domain.Interfaces;

public class ParserFactory : IParserFactory
{
    private readonly Dictionary<StoreSource, IParserStrategy> _strategies;

    public ParserFactory(IEnumerable<IParserStrategy> strategies)
    {
        _strategies = strategies.ToDictionary(s => s.Source, s => s);
    }

    public IParserStrategy GetStrategy(StoreSource source)
    {
        return _strategies[source];
    }
}