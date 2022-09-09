namespace DnD.MagicSystems;

public interface ISystemSpell<TSystemType> where TSystemType : ISystemType
{
    string Name { get; set; }
}