using DnD.LuaObjects;

namespace DnD.Races;

public abstract class Race : ScriptableModifier
{
    public abstract string RaceName { get; }

    public override string LuaScript => LuaMagicWords.Race_folder_name + "\\" + RaceName + ".lua";

    protected Race(Character targetCharacter) : base(targetCharacter)
    {
    }
}