using System.Runtime.CompilerServices;
using DnD.LuaObjects;

namespace DnD.Races;

public abstract class Race : ScriptableModificator
{

    public override string LuaScript => LuaMagicWords.Race_folder_name + this.GetType().Name;
    
    public abstract Races RaceType { get; }
    
    protected Race(Character character) : base(character)
    {
        RaceUtils.RegisterRace(this, RaceType);
    }
    
}