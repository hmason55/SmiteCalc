

namespace SmiteCalc.Models;

public class StepAction
{
    public float Value { get; set; } = 1000;
    public TimeSpan Cooldown { get; set; } = TimeSpan.FromSeconds(1);
    public TimeSpan LastTimetamp { get; set; } = TimeSpan.FromSeconds(-1);
    public Action Action { get; set; } = () => { };

    public void Step(TimeSpan timestamp)
    {
        if (timestamp < LastTimetamp + Cooldown)
        {
            return;
        }

        Action?.Invoke();
        LastTimetamp = timestamp;
    }
}