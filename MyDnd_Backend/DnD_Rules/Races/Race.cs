using System.Runtime.CompilerServices;
using DnD.LuaObjects;

namespace DnD.Races;

public abstract class Race : ScriptableModificator
{

    public override string LuaScript => LuaMagicWords.Race_folder_name + this.GetType().Name;
    
    protected Race(Character character) : base(character)
    {
        character.LevelChangedEvent += () => this.Apply();
    }

    ~Race()
    {
        _targetCharacter.LevelChangedEvent -= () => this.Apply();
    }
    
    
}