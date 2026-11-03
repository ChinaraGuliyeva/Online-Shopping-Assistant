using Application.Interfaces;
using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.Parsers.Strategies;

namespace Infrastructure.Parsers.Factories;

public class ParserFactory : IParserFactory
{
    private readonly Dictionary<StoreSource, IParserStrategy> _strategies;
    private readonly IParserStrategy _defaultStrategy;

    public ParserFactory(
        IEnumerable<IParserStrategy> strategies,
        AiParserStrategy defaultStrategy)
    {
        _strategies = strategies.ToDictionary(s => s.Source, s => s);
        _defaultStrategy = defaultStrategy;
    }

    public IParserStrategy GetStrategy(StoreSource source)
        => _strategies.GetValueOrDefault(source, _defaultStrategy);
}