namespace Infrastructure.Integrations.Google.Models;

internal record GeminiParsedItemDto(
    string? ExternalId,
    string? Title,
    string? Brand,
    string? Description,
    string? Category,
    decimal? Price,
    decimal? OldPrice,
    string? Currency,
    string? MainImageUrl,
    List<string>? AdditionalImageUrls,
    List<GeminiVariantDto>? Variants
);

internal record GeminiVariantDto(
    string? Size,
    string? Color,
    bool? IsInStock
);