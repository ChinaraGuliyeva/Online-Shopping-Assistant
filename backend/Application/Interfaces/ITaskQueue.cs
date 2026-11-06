using Application.Models;

namespace Application.Interfaces;

public interface ITaskQueue
{
    ValueTask QueueTaskAsync(ParsingTask task);
    ValueTask<ParsingTask> DequeueAsync(CancellationToken ct);
}