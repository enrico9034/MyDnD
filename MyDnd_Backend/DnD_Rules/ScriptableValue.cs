using DnD.LuaObjects;

namespace DnD;

public abstract class ScriptableValue<TType>
{
    public TType Value { get; internal set; }
    
    public abstract string LuaScript { get; }

    private readonly Character _targetCharacter;

    public void Calculate()
    {
        var script = LuaScriptDispatcher.GetScripts(LuaScript).FirstOrDefault();
        
        if(script == null || !script.CheckRequirements())
            return;
        Value = script.DoLogic<TType>(_targetCharacter);
    }
    
    public ScriptableValue(Character targetCharacter) //TODO (DG): Refactor Name
    {
        _targetCharacter = targetCharacter;
        targetCharacter.StatsChangedEvent += (character, _) => Calculate();
    }
}
