namespace DnD.MagicSystems;

public interface ISystemContainer <TSystemType> where TSystemType : ISystemType
{
    ISystemSpell<TSystemType>[] GetLearnedSpells();
}