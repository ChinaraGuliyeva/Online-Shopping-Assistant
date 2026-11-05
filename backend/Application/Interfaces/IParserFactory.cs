using Domain.Interfaces;
using Domain.Enums;

namespace Application.Interfaces;


public interface IParserFactory
{
    IParserStrategy GetStrategy(StoreSource source);
}