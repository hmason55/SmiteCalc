

using System.Text.Json.Serialization;

namespace SmiteTools.Models;

public class God
{
    public const int RATATOSKR_ID = 2063;

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("godIcon_URL")]
    public string IconUrl { get; set; }
    public int Health { get; set; } = 1000;

    public string Name { get; set; }

    public string Roles { get; set; }


    public bool IsAssassin => Roles is "Assassin";
    public bool IsGuardian => Roles is "Guardian";
    public bool IsHunter => Roles is "Hunter";
    public bool IsMage => Roles is "Mage";
    public bool IsWarrior => Roles is "Warrior";
    public bool IsMagical => Roles is "Guardian" or "Mage";
    public bool IsPhysical => !IsMagical;
    public bool IsRatatoskr => Id == RATATOSKR_ID;

    public bool CanPurchaseItem(Item item)
    {
        // Specific items.
        switch(item.RootItemId)
        {
            case Item.KATANA_ID when !(IsWarrior || IsAssassin):
                return false;

            case Item.MAGIC_ACORN_ID when !IsRatatoskr:
                return false;

            case Item.SHORT_BOW_ID when !IsHunter:
                return false;

            case Item.PROTECTORS_MASK_ID when IsWarrior || IsGuardian:
                return false;

            case Item.FIGHTERS_MASK_ID when !(IsWarrior || IsGuardian):
                return false;
        }

        // Power-restricted items.
        if ((IsMagical && item.IsPhysicalOnly) || (IsPhysical && item.IsMagicalOnly))
        {
            return false;
        }

        return true;
    }
}