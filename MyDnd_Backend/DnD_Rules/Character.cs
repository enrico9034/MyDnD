namespace DnD;

public class Character : DnDObj
{
    public Health HP;

    public ArmorClass AC;

    public Stats.Stats Stats = new();

    public event EventHandler ReCalculateStatsEvent = (_, _) => Console.WriteLine("Recalculation stats"); //TODO (DG): Create custom EventHandler type, Insert logging

    public Character()
    {
        HP = new(this);
        AC = new(this);
    }

    public void ReCalculateStats()
    {
        ReCalculateStatsEvent(this, EventArgs.Empty);
    }
}