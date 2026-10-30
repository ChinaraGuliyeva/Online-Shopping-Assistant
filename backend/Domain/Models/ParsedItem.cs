namespace Domain.Models;

using Domain.Enums;

public class ParsedItem
{
    public string ExternalId { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public StoreSource Source { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Category { get; set; } = string.Empty;

    public decimal Price { get; set; }
    public decimal? OldPrice { get; set; }
    public string Currency { get; set; } = "EUR";

    public string MainImageUrl { get; set; } = string.Empty;
    public List<string> AdditionalImageUrls { get; set; } = new();
    public List<ProductVariant> Variants { get; set; } = new();

    public DateTime ParsedAtUtc { get; set; } = DateTime.UtcNow;
}

public class ProductVariant
{
    public string Size { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public bool IsInStock { get; set; }
    public string? Sku { get; set; }
}