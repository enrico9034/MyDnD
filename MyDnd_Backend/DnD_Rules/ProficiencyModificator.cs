namespace DnD;

public class ProficiencyModificator : ScriptableValue<Int64>
{
    public ProficiencyModificator(Character targetCharacter) : base(targetCharacter)
    {
    }

    public override string LuaScript => "ProficiencyModificator";
}