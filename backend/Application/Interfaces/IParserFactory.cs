namespace Application.Interfaces;

using  Domain.Interfaces;
using Domain.Enums;

public interface IParserFactory
{
    IParserStrategy GetStrategy(StoreSource source);
}