using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace Api.Controllers;

[ApiController]
[Route("api/outfits")]
public class ClothController : ControllerBase
{
    private readonly IOutfitParsingService _parsingService;

    public ClothController(IOutfitParsingService parsingService)
    {
        _parsingService = parsingService;
    }

    [HttpPost("parse")]
    public async Task<IActionResult> ParseOutfit(IFormFile file, CancellationToken ct)
    {
        using var stream = file.OpenReadStream();

        string result = await _parsingService.ProcessOutfitAsync(stream, file.ContentType, ct);

        return Content(result, "application/json");
    }
}