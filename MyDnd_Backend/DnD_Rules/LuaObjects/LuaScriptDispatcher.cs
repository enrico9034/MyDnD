
namespace DnD.LuaObjects;
    
public class LuaScriptDispatcher : IDisposable
{

    private Dictionary<string, ICollection<LuaScript>> _scripts = new ();

    public LuaScriptDispatcher()
    {
        var scripts = ScanForScripts();
        FillScriptCache(scripts);
    }

    private void FillScriptCache(IEnumerable<string> scripts)
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

    private IEnumerable<string> ScanForScripts()
    {
        foreach (var dir in DeepSearchDirectories(LuaMagicWords.LuaFolder))
        {
            foreach (var file in Directory.GetFiles(dir).Where(file => file.EndsWith(".lua")))
                yield return file.Replace('\\', '/');
        }


        foreach (var file in Directory.GetFiles(LuaMagicWords.LuaFolder)
                     .Where(file => file.EndsWith(".lua")))
            yield return file.Replace('\\', '/');
    }

    private IEnumerable<string> DeepSearchDirectories(string path)
    {
        if (!Directory.Exists(path))
            yield break;
        if (Directory.GetDirectories(path).Any())
            foreach (var subDir in Directory.GetDirectories(path))
            foreach (var subResult in DeepSearchDirectories(subDir))
                yield return subResult;
        else
            yield return path;
    }

    public LuaScript[] GetScripts(string script, Character targetCharacter)
    {
        script = LuaMagicWords.LuaFolder + script;
        foreach (var _script in _scripts[script])
        {
            _script.Init(targetCharacter);            
        }
        return _scripts[script].ToArray();
    }

    public LuaScript[] GetScripts(Func<string, bool> pathFilter, Character targetCharacter)
    {
        var founded = _scripts.Where(tuple => pathFilter(tuple.Key))
            .SelectMany((tuple) => tuple.Value).ToArray();

        foreach (var found in founded)
        {
            found.Init(targetCharacter);
        }
        
        return founded;
    }


    public void Dispose()
    {
        foreach (var script in _scripts.SelectMany(x => x.Value.Select(y => y)))
        {
            script.Dispose();
        }
    }
}
