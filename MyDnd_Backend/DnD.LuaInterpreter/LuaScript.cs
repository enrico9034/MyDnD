using System.ComponentModel;
using DnD.Core;
using DnD.Core.ScriptSuppliers;
using Neo.IronLua;

namespace DnD.LuaInterpreter;

public class LuaScript : IScript
{
    private readonly LuaContent _targetLuaContent;

    public LuaScript(LuaContent targetLuaContent)
    {
        _targetLuaContent = targetLuaContent;
    }

    public virtual LuaScriptInitialized Init(Character targetCharacter, LuaContent utilLuaContent)
    {
        var state = new Lua();
        var env = state.CreateEnvironment();
        env[Configuration.CHARACTER_KEYWORD] = targetCharacter;
        env.DoChunk(utilLuaContent.Content, "util.lua");
        env.DoChunk(_targetLuaContent.Content, "content.lua");
        return new LuaScriptInitialized(_targetLuaContent)
        {
            _luaState = state,
            _checkRequirement = () => ((dynamic)env).CheckRequirements()[0],
            _logic = () => ((dynamic)env).Calculate()[0]
        };
    }

    public virtual bool AreRequirementMet()
    {
        throw new NotImplementedException();
    }

    public virtual dynamic DoScript()
    {
        throw new NotImplementedException();
    }
        
    public virtual void Dispose()
    {
        return;
    }
    
    public bool Equals(IScript? other)
    {
        var _other = other as LuaScript;
        if (_other == null) return false;
        return _targetLuaContent.Equals(_other._targetLuaContent);
    }
}