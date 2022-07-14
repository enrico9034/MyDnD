namespace DnD;

/// <summary>
/// This is the translation of a player sheet from the DnD 5e rules.
/// </summary>
public class Character : DnDObj
{
    public Health HP;

    public ArmorClass AC;

    public Stats.Stats Stats = new();

    public event EventHandler StatsChangedEvent = (_, _) => Console.WriteLine("Recalculation stats"); //TODO (DG): Create custom EventHandler type, Insert logging

    public Character()
    {
        HP = new(this);
        AC = new(this);
    }

    public void StatsChanged()
    {
        StatsChangedEvent(this, EventArgs.Empty);
    }
}