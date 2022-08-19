using System.Reflection;
using System.Runtime.CompilerServices;

namespace DnD.Races;

public enum Races
{
    Dwarf
}

public static class RaceUtils
{
    public static void ApplyRace(this Character targetCharacter, Races race)
    {
        var raceClass = Assembly.GetExecutingAssembly().GetTypes().First(x => x.Name == race.ToString());
        if(raceClass == null)
            return;

        Race raceObj = Activator.CreateInstance(raceClass, new [] {targetCharacter}) as Race;
        raceObj.Apply();
    }
}