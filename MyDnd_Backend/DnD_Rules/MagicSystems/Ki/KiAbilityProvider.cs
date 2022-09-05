namespace DnD.MagicSystems.Ki;

public class KiAbilityProvider : ISystemSpellProvider<Ki>
{
    /// <summary>
    /// Discovered means discovered on the hardisk (lua files) 
    /// </summary>
    /// 
    private IEnumerable<KiAbility> _discoveredKiAbilities;

    public KiAbilityProvider()
    {
        _discoveredKiAbilities = new List<KiAbility>();
    }
    
    public ISystemSpell<Ki>[] GetSpells()
    {
        return _discoveredKiAbilities.ToArray();
    }
}