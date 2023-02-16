namespace SmiteTools.Models;

public class CombatStep
{
    public TimeSpan TimeStamp { get; set; }

    public Player Player1 { get; set; }
    public Player Player2 { get; set; }

}