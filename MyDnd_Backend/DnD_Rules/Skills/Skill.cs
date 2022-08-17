using DnD.LuaObjects;

namespace DnD.Skills;

public abstract class Skill : ScriptableValue<Int64>
{
    private bool _isProficient = false;
    public bool IsProficient
    {
        get => _isProficient;
        set
        {
            _isProficient = value;
            this.Calculate();
        }
    }

    public Skill(Character targetCharacter) : base(targetCharacter)
    {
    }

    public override string LuaScript => LuaMagicWords.Skills_folder_name + this.GetType().Name;
}