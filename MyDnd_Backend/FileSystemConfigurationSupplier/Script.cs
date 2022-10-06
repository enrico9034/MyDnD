using DnD.Core.LuaObjects;
using DnD.Core.ScriptSuppliers;
using Neo.IronLua;

namespace FileSystemConfigurationSupplier;

public class Script : IScript
{
    internal readonly LuaScript _script;

    public Script(LuaScript script)
    {
        _script = script;
    }

    public void Dispose()
    {
        _script.Dispose();
    }

    public bool Equals(IScript? other)
    {
        var _other = other as Script;
        if (_other == null)
            return false;
        
        return _script.TargetFile.Equals(_other._script.TargetFile);
    }

    public bool AreRequirementMet()
    {
        return _script.CheckRequirements();
    }

    public dynamic DoScript()
    {
        return _script.DoLogic();
    }
}

public static class ScriptExtension
{
    public static Script ToScript(this LuaScript luaScript)
    {
        return new Script(luaScript);
    }
}