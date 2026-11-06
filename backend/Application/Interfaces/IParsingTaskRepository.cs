using Application.Models;

namespace Application.Interfaces;

public interface IParsingTaskRepository
{
    void Save(ParsingTask task);
    ParsingTask? Get(string taskId);
}