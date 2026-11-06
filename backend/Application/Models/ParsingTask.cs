using TaskStatus = Application.Enums.TaskStatus;

namespace Application.Models;

public class ParsingTask(string url)
{
    public string TaskId { get; } = Guid.NewGuid().ToString();
    public string Url { get; } = url;
    public TaskStatus Status { get; private set; } = TaskStatus.Pending;
    public string? Result { get; private set; }
    public string? Error { get; private set; }

    public void MarkProcessing() => Status = TaskStatus.Processing;
    public void MarkCompleted(string result) { Status = TaskStatus.Completed; Result = result; }
    public void MarkError(string error) { Status = TaskStatus.Error; Error = error; }
}