using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Application.Interfaces;

namespace Infrastructure.Background;

public class OutfitParsingWorker : BackgroundService
{
    private readonly ITaskQueue _queue;
    private readonly IParsingTaskRepository _repository;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<OutfitParsingWorker> _logger;

    public OutfitParsingWorker(
        ITaskQueue queue,
        IParsingTaskRepository repository,
        IServiceScopeFactory scopeFactory,
        ILogger<OutfitParsingWorker> logger)
    {
        _queue = queue;
        _repository = repository;
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var task = await _queue.DequeueAsync(stoppingToken);

            task.MarkProcessing();
            _repository.Save(task);

            using var scope = _scopeFactory.CreateScope();
            var parsingService = scope.ServiceProvider.GetRequiredService<IOutfitParsingService>();

            try
            {
                var result = await parsingService.ProcessOutfitAsync(task.Url, stoppingToken);
                task.MarkCompleted(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to process task {TaskId}", task.TaskId);
                task.MarkError("Outfit processing failed");
            }

            _repository.Save(task);
        }
    }
}