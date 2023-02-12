using System.Text.Json.Serialization;

namespace SmiteCalc.Models;

public class Item
{
    [JsonPropertyName("DeviceName")]
    public string Name { get; set; }

    [JsonPropertyName("itemIcon_URL")]
    public string IconUrl { get; set; }
}