using DnD.Core.CustomExceptions;

namespace DnD.Core.ScriptSuppliers;

public class ScriptCollection : IDisposable
{
    internal List<IScript> _scriptCollection = new List<IScript>();

    internal ScriptCollection() {}

    public static ScriptCollection FromCollection(IEnumerable<IScript> scripts)
    {
        return new()
        {
            _scriptCollection = scripts.ToList()
        };
    }

    public void AddScript(IScript script, bool raiseExceptionIfAlreadyAdded = false)
    {
        if (_scriptCollection.Any(script => script.Equals(script)))
            if (raiseExceptionIfAlreadyAdded) throw new ScriptAlreadyPresentException(script); 
            else return;
        
        _scriptCollection.Add(script);
    }

    public IEnumerable<IScript> Scripts() => _scriptCollection;

    public void Dispose()
    {
        foreach (var script in _scriptCollection)
        {
            if(script != null)
                script.Dispose();
        }        
    }

    ~ScriptCollection()
    {
        Dispose();
    }
}