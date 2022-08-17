using DnD.LuaObjects;

namespace DnD;

public abstract class ScriptableModificator
{
    public abstract string LuaScript { get;  }

    public void Apply(Character targetCharacter)
    {
        var targetScripts = LuaScriptDispatcher.GetScripts(LuaScript);
        foreach (var script in targetScripts)
        {
            script.CheckRequirements();
            script.DoLogic(targetCharacter);   
        }
    }
}