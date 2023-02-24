namespace SmiteTools.Models;

public class CombatStep
{
    public TimeSpan TimeStamp { get; set; }

    public Player Player1 { get; set; }
    public Player Player2 { get; set; }


    public IEnumerable<CombatStep> StepsInTimeSpan(List<CombatStep> steps, TimeSpan timeSpan)
    {
        if (!steps?.Any() ?? true)
        {
            return default;
        }

        return steps.Where(s => s.TimeStamp > TimeStamp - timeSpan && s.TimeStamp <= TimeStamp);
    }
}