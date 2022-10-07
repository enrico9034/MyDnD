using DnD.Core.LuaObjects;
using DnD.Core.ScriptSuppliers;
using DnD.LuaInterpreter;

namespace FileSystemConfigurationSupplier;

public class LuaScriptDispatcherAdaptor : ILuaContentDispatcher
{
    private LuaScriptDispatcher _dispatcher;

    public LuaScriptDispatcherAdaptor()
    {
        _dispatcher = new LuaScriptDispatcher();
    }
    
    private LuaContent[] GetLuaContent(string contentName)
    {
        return _dispatcher.GetScripts(contentName);
    }

    public LuaContent[] GetLuaContent(ScriptRequestParam contentInput)
    {
        return GetLuaContent(string.Join('/', contentInput.parameters));
    }

    public LuaContent GetLuaInitContent()
    {
        return _dispatcher.GetScripts("Stats")[0];
    }

    public LuaContent GetLuaUtilContent()
    {
        return _dispatcher.GetScripts("Util")[0];
    }
}