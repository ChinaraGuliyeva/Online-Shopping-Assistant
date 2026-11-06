using System.Threading.Channels;
using Application.Interfaces;
using Application.Models;

namespace Infrastructure.Background;

public class ChannelTaskQueue : ITaskQueue
{
    private readonly Channel<ParsingTask> _channel = Channel.CreateUnbounded<ParsingTask>(
        new UnboundedChannelOptions { SingleReader = true });

    public ValueTask QueueTaskAsync(ParsingTask task) => _channel.Writer.WriteAsync(task);

    public ValueTask<ParsingTask> DequeueAsync(CancellationToken ct) => _channel.Reader.ReadAsync(ct);
}