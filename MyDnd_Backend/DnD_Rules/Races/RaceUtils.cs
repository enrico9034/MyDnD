using System.Reflection;
using System.Runtime.CompilerServices;

namespace DnD.Races;

public enum Races
{
    Dwarf
}

public static class RaceUtils
{
    private static Dictionary<Races, Race> _enumToClassCtorBinding = new ();
    
    public static void RegisterRace(Race race, Races raceEnum)
    {
        _enumToClassCtorBinding[raceEnum] = race;
    }
    public static void ApplyRace(this Character target, Races race)
    {
        _enumToClassCtorBinding[race].Apply(target);
    }

    public static void InitRaces()
    {
        var racesClasses = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsAssignableTo(typeof(Race)) && !t.IsAbstract);
        foreach (var raceType in racesClasses)
        {
            Activator.CreateInstance(raceType);
        }
    }
}