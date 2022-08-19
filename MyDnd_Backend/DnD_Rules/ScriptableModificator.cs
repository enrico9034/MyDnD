using DnD.LuaObjects;

namespace DnD;

public abstract class ScriptableModificator
{
    public abstract string LuaScript { get;  }

    public void Apply()
    {
        var targetScripts = LuaScriptDispatcher.GetScripts(LuaScript);
        foreach (var script in targetScripts)
        {
            script.CheckRequirements();
            script.DoLogic(_targetCharacter);   
        }
    }

    private Character _targetCharacter;
    public ScriptableModificator(Character targetCharacter)
    {
        _targetCharacter = targetCharacter;
        _targetCharacter.StatsChangedEvent += (_, _) => Apply();
    }
}