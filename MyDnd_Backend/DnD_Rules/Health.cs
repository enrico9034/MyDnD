namespace DnD;

public class Health : ScriptableValue<Int64>
{
    public Health(Character targetCharacter) : base(targetCharacter)
    {
    }

    public override string luaScript => "HP.lua";
}
