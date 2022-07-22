using System.Runtime.CompilerServices;
using DnD.LuaObjects;

namespace DnD.Races;

public abstract class Race : ScriptableModifier
{
    public abstract string RaceName { get; }

    public override string LuaScript => LuaMagicWords.Race_folder_name + "\\" + RaceName + ".lua";
    
    public abstract Races RaceType { get; }
    
    protected Race()
    {
        RaceUtils.RegisterRace(this, RaceType);
    }
    
}