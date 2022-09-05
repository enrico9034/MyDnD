using DnD.Classes;
using DnD.MagicSystems;
using DnD.Races;

namespace DnD;

/// <summary>
/// This is the translation of a player sheet from the DnD 5e rules.
/// </summary>
public class Character : DnDObj
{
    private int _level = 0;
    public int Level
    {
        get => _level;
        set
        {
            _level = value;
            LevelChangedEvent(); //TODO: Create custom event
        }
    }

    public Health HP;

    public ArmorClass AC;

    public Stats.Stats Stats = new();

    public ProficiencyModificator ProficiencyModificator;

    public Skills.Skills Skills;

    public Classes.Classes Classes;

    public ISystemType PowerSystemType
    {
        set
        {
            value.EnablePowerSystem(this);
        }
    }
    
    public Races.Races Race
    {
        set => this.ApplyRace(value);
    }

    public delegate void CharacterEventHandler();
    
    public event CharacterEventHandler StatsChangedEvent = ()
        => Console.WriteLine("Recalculation stats"); 

    public event CharacterEventHandler LevelChangedEvent = ()
        => Console.WriteLine("Recalculation level");
    
    public Character()
    {
        HP = new(this);
        AC = new(this);
        ProficiencyModificator = new(this);
        Skills = new(this);
        Classes = new(this);
        
        Stats.AnyStatsChangedEvent += StatsChanged;
    }

    private bool _recalculatingStats = false;
    private object _lock = new object();
    public void StatsChanged()
    {
        lock (_lock)
        {
            _recalculatingStats = true;
            StatsChangedEvent();
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