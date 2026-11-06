using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.Models;
using API.Dtos.Requests;
using TaskStatus = Application.Enums.TaskStatus;

namespace Api.Controllers;

[ApiController]
[Route("api/outfits")]
public class ClothController : ControllerBase
{
    private readonly ITaskQueue _queue;
    private readonly IParsingTaskRepository _repository;

    public ClothController(ITaskQueue queue, IParsingTaskRepository repository)
    {
        _queue = queue;
        _repository = repository;
    }

    [HttpPost("parse")]
    public async Task<IActionResult> ParseOutfit([FromBody] ParseOutfitRequest request)
    {
        var task = new ParsingTask(request.Url);

        _repository.Save(task);
        await _queue.QueueTaskAsync(task);

        return Accepted(new { taskId = task.TaskId, message = "Parsing started in background" });
    }

    [HttpGet("status/{taskId}")]
    public IActionResult GetStatus(string taskId)
    {
        var task = _repository.Get(taskId);
        if (task == null)
        {
            return NotFound(new { message = "Task not found" });
        }

        if (task.Status == TaskStatus.Error)
        {
            return BadRequest(new { status = task.Status.ToString(), error = task.Error });
        }

        if (task.Status == TaskStatus.Completed)
        {
            return Content(task.Result!, "application/json");
        }

        return Ok(new { status = task.Status.ToString() });
    }
}