using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using API.Dtos.Requests;

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

    [HttpPost]
    public async Task<IActionResult> ParseOutfit([FromBody] ParseOutfitRequest request, CancellationToken ct)
    {
        string result = await _parsingService.ProcessOutfitAsync(request.Url, ct);

        return Content(result, "application/json");
    }
}