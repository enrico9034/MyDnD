using DnD.Classes;
using DnD.Races;

namespace DnD;

/// <summary>
/// This is the translation of a player sheet from the DnD 5e rules.
/// </summary>
public class Character : DnDObj
{
    public Health HP;

    public ArmorClass AC;

    public Stats.Stats Stats = new();

    public ProficiencyModificator ProficiencyModificator;

    public Skills.Skills Skills;

    public Classes.Classes Classes = new ();

    public Races.Races Race
    {
        set => RaceUtils.ApplyRace(value);
    }
    
    public event EventHandler StatsChangedEvent = (_, _) 
        => Console.WriteLine("Recalculation stats"); //TODO (DG): Create custom EventHandler type, Insert logging

    public Character()
    {
        HP = new(this);
        AC = new(this);
        ProficiencyModificator = new(this);
        Skills = new(this);
        
        Stats.AnyStatsChangedEvent += StatsChanged;
        
        RaceUtils.InitRaces(this);
    }

    public bool RecalculatingStats = false;
    private object _lock = new object();
    public void StatsChanged()
    {
        lock (_lock)
        {
            RecalculatingStats = true;
            StatsChangedEvent(this, EventArgs.Empty);
            RecalculatingStats = false;    
        }
    }
}