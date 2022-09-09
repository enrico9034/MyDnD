using DnD.LuaObjects;

namespace DnD.MagicSystems.Ki;

public class KiAbility : ISystemSpell<Ki>
{
    public string Name { get; set; }

    protected LuaScript _innerScript;
    
    public KiAbility()
    {
    }

    public static KiAbility Build(LuaScript abilityDescriptor)
    {
        return new KiAbility()
        {
            _innerScript = abilityDescriptor,
        }.FillData();
    }

    public KiAbility FillData()
    {
        var data = _innerScript.DoLogic();
        Name = data["Name"];
        return this;
    }
}