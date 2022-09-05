namespace DnD.MagicSystems;

public interface ISystemSpellProvider<TSystemType> where TSystemType : ISystemType
{
    ISystemSpell<TSystemType>[] GetSpells();
}