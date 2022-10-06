namespace DnD.Core.ScriptSuppliers;

public interface IScript : IDisposable, IEquatable<IScript>
{
    bool AreRequirementMet();

    dynamic DoScript();
}