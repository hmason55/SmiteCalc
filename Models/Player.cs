

namespace SmiteTools.Models;

public class Player
{
    public Player Target { get; set; }
    public God God { get; set; } = new();
    public List<Item> Loadout { get; set; } = new();

    public bool IsBasicAttacking { get; set; }

    // Buffs, debuffs

    public Player()
    {
        Initialize();
    }

    public Player(Player target) : this()
    {
        Target = target;
    }

    public float BasicAttackDamage { get; set; } = 100;
    public float CurrentHealth { get; set; }
    public float MaximumHealth { get; set; }
    public float DamageDealt { get; set; }
    public float DeltaHealth { get; set; }



    public List<StepAction> StepActions = new();

    public void Initialize()
    {
        MaximumHealth = God.Health + Loadout.Sum(i => i.Health);
        CurrentHealth = MaximumHealth;

        StepActions = new()
        {
            // Use a basic attack
            new()
            {
                Value = BasicAttackDamage,
                Cooldown = TimeSpan.FromSeconds(0.25),
                Action = UseBasicAttack,
            },
        };
    }


    public void PreStep()
    {
        DeltaHealth = CurrentHealth;
        DamageDealt = 0;
    }

    public void Step(TimeSpan timestamp)
    {
        foreach(StepAction action in StepActions)
        {
            action.Step(timestamp);
        }
    }

    public void PostStep()
    {
        DeltaHealth = CurrentHealth - DeltaHealth;
    }

    public void UseBasicAttack()
    {
        if(!IsBasicAttacking)
        {
            return;
        }

        DamageDealt += Target?.ReceiveBasicAttack(this) ?? 0;
    }

    public float ReceiveBasicAttack(Player sender)
    {
        CurrentHealth -= sender.BasicAttackDamage;
        return sender.BasicAttackDamage;
    }


}