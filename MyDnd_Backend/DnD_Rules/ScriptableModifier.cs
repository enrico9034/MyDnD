using DnD.LuaObjects;

namespace DnD;

public abstract class ScriptableModifier
{
    public abstract string LuaScript { get;  }

    public void Apply(Character targetCharacter)
    {
        var targetScript = LuaScriptDispatcher.GetScript(LuaScript);
        targetScript.CheckRequirements();
        targetScript.DoLogic(targetCharacter);
    }
}