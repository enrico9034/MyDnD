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
    public string Description => "";
}