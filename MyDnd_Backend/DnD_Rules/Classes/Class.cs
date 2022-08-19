using DnD.LuaObjects;

namespace DnD.Classes;

public class Class : ScriptableModificator
{
    private int _level = 1;

    public int Level
    {
        get => _level;
        set
        {
            var delta = value - _level;            
            _level = value;
            this._targetCharacter.Stats.Level += delta;
        }
    }

    public override string LuaScript => LuaMagicWords.Classes_folder_name + this.GetType().Name;

    public Class(Character targetCharacter) : base(targetCharacter)
    {
    }
}
