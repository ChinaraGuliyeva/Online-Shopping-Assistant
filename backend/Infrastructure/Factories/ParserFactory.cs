namespace Infrastructure.FActories;
using Application.Interfaces;
using Domain.Enums;

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