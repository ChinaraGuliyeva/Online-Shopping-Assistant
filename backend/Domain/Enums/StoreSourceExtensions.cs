namespace Domain.Enums;

public static class StoreSourceExtensions
{
    public static StoreSource ResolveFromUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return StoreSource.Unknown;

        foreach (StoreSource source in Enum.GetValues<StoreSource>())
        {
            if (source == StoreSource.Unknown)
                continue;

            if (url.Contains(source.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return source;
            }
        }

        return StoreSource.Unknown;
    }
}