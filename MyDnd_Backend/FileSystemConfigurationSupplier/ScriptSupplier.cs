using DnD.Core;
using DnD.Core.LuaObjects;
using DnD.Core.ScriptSuppliers;

namespace FileSystemConfigurationSupplier;

public class ScriptSupplier : IScriptSupplier
{
    internal Character _character;
    internal LuaScriptDispatcher _dispatcher;

    public ScriptSupplier()
    {
        _dispatcher = new LuaScriptDispatcher();
    }
    
    public void SetCharacterInstance(Character targetCharacter)
    {
        _character = targetCharacter;
    }

    public IScript GetInitScript()
    {
        return _dispatcher.GetScripts("Stats", _character)[0].ToScript();
    }

    public IScript GetScript(string scriptName)
    {
        return _dispatcher.GetScripts(scriptName, _character)[0].ToScript();
    }

    public ScriptCollection GetScriptCollection(string collectionName)
    {
        var collection = _dispatcher.GetScripts(collectionName, _character);
        return ScriptCollection.FromCollection(collection.Select(x => x.ToScript()));
    }
    
    public void Dispose()
    {
        _dispatcher.Dispose();
    }
}