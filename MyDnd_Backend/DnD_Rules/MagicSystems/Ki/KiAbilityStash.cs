using System.Collections.Immutable;
using DnD.LuaObjects;

namespace DnD.MagicSystems.Ki;

public class KiAbilityStash : ISystemContainer<Ki>
{
    private IEnumerable<KiAbility> _stash;

    public KiAbilityStash()
    {
        _stash = new KiAbility[] { };
    }
    public ISystemSpell<Ki>[] GetLearnedSpells()
    {
        return _stash.ToArray();
    }
}

public class KiAbility : ISystemSpell<Ki>
{
    public string Name { get; set; }

    protected LuaScript _innerScript;
    
    public KiAbility()
    {
        
    }

    public static KiAbility Build(LuaScript abilityDescriptor)
    {
        return new ()
        {
            _innerScript = abilityDescriptor,
            Name = abilityDescriptor.TargetFile
        };
    }

}