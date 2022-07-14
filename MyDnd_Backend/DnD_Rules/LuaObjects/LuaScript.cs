using NLua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.LuaObjects;

public class LuaScript : IDisposable
{
    public string TargetFile { get; }

    Func<bool> CheckRequirementsInternal = () => false;

    Func<object> CalculateInternal = () => default;
    
    protected Lua _luaState;

    public LuaScript(string targetFile, bool init = true)
    {
        TargetFile = targetFile;
        
        if(init)
            Init(); 
    }

    public void Init()
    {
        if (_luaState != null)
            return;
        
        _luaState = new Lua();

        _luaState.LoadCLRPackage();
        
        _luaState.DoFile(TargetFile);
        var checkFunc_lua = _luaState[LuaMagicWords.CheckRequirements_fun] as LuaFunction;
        var calculateFunc_lua = _luaState[LuaMagicWords.Calculate_fun] as LuaFunction;

        if (checkFunc_lua == null || calculateFunc_lua == null)
            return;
        
        CheckRequirementsInternal = () => (bool)checkFunc_lua.Call().First();

        CalculateInternal = () => calculateFunc_lua.Call().FirstOrDefault();
    }

    public TReturn DoLogic<TReturn>(Character targetCharacter) 
    {
        _luaState[LuaMagicWords.Character_luaState_keyword] = targetCharacter;
        return (TReturn)CalculateInternal();
    }

    public void DoLogic(Character targetCharacter)
    {
        _luaState[LuaMagicWords.Character_luaState_keyword] = targetCharacter;
        CalculateInternal();
    }
    
    public bool CheckRequirements()
    {
        return CheckRequirementsInternal();
    }

    public void Dispose()
    {
        _luaState.Dispose();
    }

    ~LuaScript()
    {
        Dispose();
    }
}
