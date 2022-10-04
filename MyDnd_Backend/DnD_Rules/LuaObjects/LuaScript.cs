using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Core.Lua;

namespace DnD.Core.LuaObjects;

public class LuaScript : IDisposable
{
    internal object _lock = new object(); 
    public string TargetFile { get; }

    Func<bool> CheckRequirementsInternal = () => true;

    Func<object> CalculateInternal = () => default;
    
    protected Neo.IronLua.Lua _luaState;

    public LuaScript(string targetFile)
    {
        TargetFile = targetFile;
    }

    public void Init(Character targetCharacter)
    {
        lock (_lock)
        {
                
            if (_luaState != null)
                return;
            
            _luaState = new Neo.IronLua.Lua();
            
            var env = _luaState.CreateEnvironment();
            env[LuaMagicWords.Character_luaState_keyword] = targetCharacter;
            env.DoChunk(File.ReadAllText(LuaMagicWords.LuaFolder + "Util.lua"), "util.lua");
            env.DoChunk(TargetFile, Array.Empty<KeyValuePair<string, object>>());

            CheckRequirementsInternal = () =>
            {
                try
                {
                    return (bool)((dynamic)env).CheckRequirements()[0];
                }
                catch (Exception e)
                {
                    return true;
                }
            };

            CalculateInternal = () =>
            {
                try
                {
                    return ((dynamic)env).Calculate()[0];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            };
        }
    }

    public dynamic DoLogic()
    {
        lock (_lock)
        {
            return CalculateInternal();
        }
    }

    public bool CheckRequirements()
    {
        lock (_lock)
        {
            return CheckRequirementsInternal();
        }
    }

    public void Dispose()
    {
        lock (_lock)
        {
            if (_luaState != null) 
                _luaState.Dispose();
        }
    }

    ~LuaScript()
    {
        Dispose();
    }
}
