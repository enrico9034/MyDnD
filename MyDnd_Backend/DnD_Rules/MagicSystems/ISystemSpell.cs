namespace DnD.MagicSystems;

public interface ISystemSpell<TSystemType> where TSystemType : SystemDescriptor
{
    string Description { get; }
}