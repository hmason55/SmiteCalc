using SmiteTools.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace SmiteTools;

public static class Globals
{

    private static string _gods = string.Empty;
    private static string _items = string.Empty;
    private static HttpClient _client = new();
    public static Uri BaseUri => _client.BaseAddress;

    public static async Task Initialize(string hostUrl)
    {
        _client = new()
        {
            BaseAddress = new(hostUrl)
        };

        _gods = await _client.GetStringAsync("data/gods.json");
        _items = await _client.GetStringAsync("data/items.json");
    }

    public static HttpClient Client => _client;
    public static List<God> Gods => JsonSerializer.Deserialize<List<God>>(_gods);
    public static List<Item> Items => JsonSerializer.Deserialize<List<Item>>(_items).Where(i => i.ActiveFlag == "y" && (i.ItemTier >= 3 || (i.StartingItem && i.ItemTier == 2))).ToList();


}