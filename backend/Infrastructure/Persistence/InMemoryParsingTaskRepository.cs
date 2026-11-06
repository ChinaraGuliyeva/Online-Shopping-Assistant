using Microsoft.Extensions.Caching.Memory;
using Application.Interfaces;
using Application.Models;

namespace Infrastructure.Persistence;

public class InMemoryParsingTaskRepository : IParsingTaskRepository
{
    private readonly IMemoryCache _cache;
    private static readonly TimeSpan Expiration = TimeSpan.FromHours(24);

    public InMemoryParsingTaskRepository(IMemoryCache cache)
    {
        _cache = cache;
    }

    public void Save(ParsingTask task)
    {
        _cache.Set(task.TaskId, task, Expiration);
    }

    public ParsingTask? Get(string taskId)
    {
        _cache.TryGetValue(taskId, out ParsingTask? task);
        return task;
    }
}