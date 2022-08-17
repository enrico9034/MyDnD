
namespace DnD.LuaObjects;
    
public static class LuaScriptDispatcher
{

    private static Dictionary<string, ICollection<LuaScript>> _scripts = new ();

    static LuaScriptDispatcher()
    {
        var scripts = ScanForScripts();
        FillScriptCache(scripts);
    }

    private static void FillScriptCache(IEnumerable<string> scripts)
    {
        string SanitizeFileName(string file) => file.Substring(0, file.Length - 4).Split('_')[0];

        foreach(var script in scripts)
        {
            var scriptKey = SanitizeFileName(script);
            if (!_scripts.ContainsKey(scriptKey))
                _scripts[scriptKey] = new List<LuaScript>();
            _scripts[scriptKey].Add(new LuaScript(script)); //TODO (DG): Check if the string contains also the folder
        }
    }

    private static IEnumerable<string> ScanForScripts()
    {
        foreach (var dir in Directory.GetDirectories(LuaMagicWords.LuaFolder))
        {
            foreach (var file in Directory.GetFiles(dir).Where(file => file.EndsWith(".lua")))
                yield return file.Replace('\\', '/');
        }


        foreach (var file in Directory.GetFiles(LuaMagicWords.LuaFolder)
                     .Where(file => file.EndsWith(".lua")))
            yield return file.Replace('\\', '/');
    }

    public static LuaScript[] GetScripts(string script)
    {
        script = LuaMagicWords.LuaFolder + script;
        foreach (var _script in _scripts[script])
        {
            _script.Init();            
        }
        return _scripts[script].ToArray();
    }
}
