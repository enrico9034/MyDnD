using DnD.Core;
using DnD.Core.ScriptSuppliers;
using DnD.LuaInterpreter;


public class LuaScriptSupplier : IScriptSupplier
{
    private Character _character;
    private readonly ILuaContentDispatcher _dispatcher;


    public LuaScriptSupplier(ILuaContentDispatcher luaContentDispatcher)
    {
        _dispatcher = luaContentDispatcher;
    }

    public void SetCharacterInstance(Character targetCharacter)
    {
        _character = targetCharacter;
    }

    public IScript GetInitScript()
    {
        return new LuaScript(_dispatcher.GetLuaInitContent()).Init(_character, _dispatcher.GetLuaUtilContent());
    }

    public IScript GetScript(ScriptRequestParam request)
    {
        return new LuaScript(_dispatcher.GetLuaContent(request)[0]).Init(_character,
            _dispatcher.GetLuaUtilContent());
    }

    public ScriptCollection GetScriptCollection(ScriptRequestParam request)
    {
        var collection = _dispatcher.GetLuaContent(request);
        var util = _dispatcher.GetLuaUtilContent();
        return ScriptCollection.FromCollection(collection.Select(x => new LuaScript(x).Init(_character, util)));
    }



public void Dispose()
    {
    }
}