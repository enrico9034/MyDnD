using DnD.LuaObjects;

namespace DnD.Classes;

public class Class : ScriptableModificator
{
    public int Level { get; set; } = 1;
    public override string LuaScript => LuaMagicWords.Classes_folder_name + this.GetType().Name;

    public Class(Character targetCharacter) : base(targetCharacter)
    {
    }
}
