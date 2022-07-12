using NLua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD;

public static class LuaMagicWords
{
    public const string CheckRequirements_fun = "CheckRequirements";
}

public class LuaScript : IDisposable
{
    public string TargetFile { get; }

    Func<bool> CheckRequirementsInternal = () => false;

    protected Lua _luaState;

    public LuaScript(string targetFile)
    {
        TargetFile = targetFile;
        Init();
    }

    internal void Init()
    {
        _luaState = new Lua();

        _luaState.LoadCLRPackage();
        _luaState.DoFile(TargetFile);
        var checkFunc_lua = _luaState[LuaMagicWords.CheckRequirements_fun] as LuaFunction;

        if (checkFunc_lua != null)
            CheckRequirementsInternal = () => (bool)checkFunc_lua.Call().First();
    }

    public bool CheckRequirements()
    {
        return CheckRequirementsInternal();
    }

    public void Dispose()
    {
        _luaState.Dispose();
    }
}
