namespace DnD.Core.ScriptSuppliers;

public interface IScriptSupplier : IDisposable
{
    void SetCharacterInstance(Character targetCharacter);

    IScript GetInitScript();

    IScript GetScript(string scriptName);

    ScriptCollection GetScriptCollection(string collectionName);
}