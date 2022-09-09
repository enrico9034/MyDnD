using NLua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Lua;
using DnD.MagicSystems;

namespace DnD.LuaObjects;

public class LuaScript : IDisposable
{
    public string TargetFile { get; }

    Func<bool> CheckRequirementsInternal = () => true;

    Func<object> CalculateInternal = () => default;
    
    protected NLua.Lua _luaState;

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
        
        _luaState = new NLua.Lua();

        _luaState.LoadCLRPackage();
        
        _luaState.DoFile(TargetFile);
        foreach ((var systemName, var systemType) in StaticSystemTypeCollector.SystemTypes)
            _luaState[systemName] = systemType;
        
        var checkFunc_lua = _luaState[LuaMagicWords.CheckRequirements_fun] as LuaFunction;
        var calculateFunc_lua = _luaState[LuaMagicWords.Calculate_fun] as LuaFunction;

        if (calculateFunc_lua == null)
            return;
        
        if (checkFunc_lua != null)
            CheckRequirementsInternal = () => (bool)checkFunc_lua.Call().FirstOrDefault();

        CalculateInternal = () =>
        {
            try
            {
                return calculateFunc_lua.Call().FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        };
    }

    public TReturn DoLogic<TReturn>(Character targetCharacter) 
    {
        _luaState[LuaMagicWords.Character_luaState_keyword] = targetCharacter;
        _luaState[LuaMagicWords.Lua_helper_class_keyword] = new LuaUtil(targetCharacter);
        return (TReturn)CalculateInternal();
    }

    public dynamic DoLogic()
    {
        return CalculateInternal();
    }

    public void DoLogic(Character targetCharacter)
    {
        _luaState[LuaMagicWords.Character_luaState_keyword] = targetCharacter;
        _luaState[LuaMagicWords.Lua_helper_class_keyword] = new LuaUtil(targetCharacter);
        CalculateInternal();
    }
    
    public bool CheckRequirements(Character targetCharacter)
    {
        _luaState[LuaMagicWords.Lua_helper_class_keyword] = new LuaUtil(targetCharacter);
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
