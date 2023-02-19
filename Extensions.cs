using SmiteTools.Models;

namespace SmiteTools;

public static class Extensions
{
    public static string ToStaticResource(this string url)
    {
        url ??= string.Empty;
        Uri uri = new(url);
        return $"/data/{uri.Host}/{new Uri($"{uri.Scheme}://{uri.Host}").MakeRelativeUri(new(url))}";
    }

    public static bool ContainsItem(this IEnumerable<Item> items, Item item) => items.Where(i => i.ItemId == item.ItemId).Any();
    public static bool ContainsStarterItem(this IEnumerable<Item> items) => items.Where(i => i.StartingItem).Any();
    public static bool ContainsMagicAcornItem(this IEnumerable<Item> items) => items.Where(i => i.ItemId == Item.MAGIC_ACORN_ID).Any();
    public static bool ContainsGlyphItem(this IEnumerable<Item> items) => items.Where(i => i.IsGlyph).Any();
    public static bool ContainsGlyphOfT3Item(this IEnumerable<Item> items, Item item) => item.ItemTier == 3 && items.Where(i => i.IsGlyph && i.ChildItemId == item.ItemId).Any();
    public static bool ContainsEvolvedItem(this IEnumerable<Item> items, Item item) => item.Type == "Item" && item.ItemTier == 3 && items.Where(i => i.ChildItemId == item.ItemId).Any();
    public static bool ContainsRelic(this IEnumerable<Item> items, Item item) => items.Where(i => i.ItemId == item.ItemId || i.ChildItemId == item.ChildItemId).Any();
}