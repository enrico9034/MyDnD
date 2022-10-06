using DnD.Core;
using Neo.IronLua;

namespace DnD.LuaInterpreter;

public class LuaScriptInitialized : LuaScript
{
    internal Lua _luaState;

    internal Func<bool> _checkRequirement;

    internal Func<dynamic> _logic;

    internal LuaScriptInitialized(LuaContent targetLuaContent) : base(targetLuaContent)
    {
    }

    public override LuaScriptInitialized Init(Character targetCharacter, LuaContent utilLuaContent)
    {
        return this;
    }

    public override bool AreRequirementMet()
    {
        return _checkRequirement();
    }

    public override dynamic DoScript()
    {
        return _logic();
    }

    public override void Dispose()
    {
        _luaState.Dispose();
        base.Dispose();
    }
    
}