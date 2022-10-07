namespace DnD.Core.ScriptSuppliers;


public class ScriptRequestParam
{
    public IList<string> parameters { get; set; }
}

public interface IScriptSupplier : IDisposable
{
    void SetCharacterInstance(Character targetCharacter);

    IScript GetInitScript();

    IScript GetScript(ScriptRequestParam request);

    ScriptCollection GetScriptCollection(ScriptRequestParam request);
}