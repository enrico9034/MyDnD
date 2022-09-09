using DnD.LuaObjects;

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
        RefreshKiAbilities();
    }

    private void RefreshKiAbilities()
    {
        IEnumerable<KiAbility> BuildSkills(LuaScript[] scripts)
        {    
            foreach (var script in scripts)
            {
                yield return KiAbility.Build(script);
            }
        }
        
        var luaScripts = LuaScriptDispatcher.GetScripts(path => path.Contains("Systems/Ki"));
        
        _discoveredKiAbilities = BuildSkills(luaScripts).ToArray();

    }

    public ISystemSpell<Ki>[] GetSpells()
    {
        return _discoveredKiAbilities.ToArray();
    }
}