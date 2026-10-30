namespace Application.Interfaces;

using Domain.Enums;

public interface IParserFactory
{
    IParserStrategy GetStrategy(StoreSource source);
}