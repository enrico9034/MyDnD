using NLua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Lua;

namespace DnD.LuaObjects;

public class LuaScript : IDisposable
{
    public string TargetFile { get; }

    Func<bool> CheckRequirementsInternal = () => true;

    Func<object> CalculateInternal = () => default;
    
    protected NLua.Lua _luaState;

    public LuaScript(string targetFile)
    {
        TargetFile = targetFile;
    }

    public void Init(Character targetCharacter)
    {
        if (_luaState != null)
            return;
        
        _luaState = new NLua.Lua();


        _luaState[LuaMagicWords.Character_luaState_keyword] = targetCharacter;
        _luaState.DoString(File.ReadAllText(LuaMagicWords.LuaFolder + "Util.lua"));
        _luaState.DoFile(TargetFile);
        

        
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

        return (TReturn)CalculateInternal();
    }

    public dynamic DoLogic()
    {
        return CalculateInternal();
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
