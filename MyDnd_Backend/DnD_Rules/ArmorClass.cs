namespace DnD;

public class ArmorClass : ScriptableValue<Int64>
{
    public ArmorClass(Character targetCharacter) : base(targetCharacter)
    {
    }

    public override string luaScript => "AC.lua";
}
