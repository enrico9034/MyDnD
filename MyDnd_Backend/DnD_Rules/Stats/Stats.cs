﻿namespace DnD.Stats;

public class Stats
{
    public Intelligence Intelligence { get; } = new();

    public Strength Strength { get; } = new();

    public Dexterity Dexterity { get; } = new();

    public Constitution Constitution { get; } = new();

    public Wisdom Wisdom { get; } = new();

    public Charisma Charisma { get; } = new();

    public event Stat.StatsChangedEventHandler AnyStatsChangedEvent;

    public Stats()
    {
        Intelligence.StatChangedEvent += AnyStatsChanged;
        Strength.StatChangedEvent += AnyStatsChanged;
        Dexterity.StatChangedEvent += AnyStatsChanged;
        Constitution.StatChangedEvent += AnyStatsChanged;
        Wisdom.StatChangedEvent += AnyStatsChanged;
        Charisma.StatChangedEvent += AnyStatsChanged;
    }

    
    private void AnyStatsChanged()
    {
            if (AnyStatsChangedEvent == null)
                return;
            AnyStatsChangedEvent();
    }
    
    public Stat GetStat<T>() where T : Stat
    {
        if (typeof(T) == typeof(Intelligence))
            return Intelligence;
        if (typeof(T) == typeof(Strength))
            return Strength;
        if (typeof(T) == typeof(Dexterity))
            return Dexterity;
        if (typeof(T) == typeof(Constitution))
            return Constitution;
        if (typeof(T) == typeof(Wisdom))
            return Wisdom;
        if (typeof(T) == typeof(Charisma))
            return Charisma;
        throw new ArgumentException($"{typeof(T)} is not a valid stat");
    }
}
