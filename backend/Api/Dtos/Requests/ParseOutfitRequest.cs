using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Requests;
public record ParseOutfitRequest
{
    [Required]
    [Url]
    public string Url { get; init; } = default!;
}