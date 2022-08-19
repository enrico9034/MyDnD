using DnD.Classes;
using DnD.Races;

namespace DnD;

/// <summary>
/// This is the translation of a player sheet from the DnD 5e rules.
/// </summary>
public class Character : DnDObj
{
    private int _level = 1;
    public int Level
    {
        get => _level;
        set
        {
            _level = value;
            StatsChangedEvent(this, EventArgs.Empty); //TODO: Create custom event
        }
    }

    public Health HP;

    public ArmorClass AC;

    public Stats.Stats Stats = new();

    public ProficiencyModificator ProficiencyModificator;

    public Skills.Skills Skills;

    public Classes.Classes Classes;

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
        Classes = new(this);
        
        Stats.AnyStatsChangedEvent += StatsChanged;
        
        RaceUtils.InitRaces(this);
    }

    private bool _recalculatingStats = false;
    private object _lock = new object();
    public void StatsChanged()
    {
        lock (_lock)
        {
            _recalculatingStats = true;
            StatsChangedEvent(this, EventArgs.Empty);
            _recalculatingStats = false;    
        }
    }

    public bool IsRecalculatingStats()
    {
        lock (_lock)
        {
            return _recalculatingStats;
        }
    }
}