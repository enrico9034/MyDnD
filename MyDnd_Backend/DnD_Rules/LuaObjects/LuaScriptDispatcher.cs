
namespace DnD.LuaObjects;
    
public static class LuaScriptDispatcher
{

    private static Dictionary<string, LuaScript> _scripts = new ();

    static LuaScriptDispatcher()
    {
        var scripts = ScanForScripts();
        FillScriptCache(scripts);
    }

    private static void FillScriptCache(IEnumerable<string> scripts)
    {
        string RemoveFileExtension(string file) => file.Substring(0, file.Length - 4);

        foreach(var script in scripts)
        {
            _scripts[RemoveFileExtension(script)] = new LuaScript(script); //TODO (DG): Check if the string contains also the folder
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

    public static LuaScript GetScript(string script)
    {
        script = LuaMagicWords.LuaFolder + script;
        _scripts[script].Init();
        return _scripts[script];
    }
}
