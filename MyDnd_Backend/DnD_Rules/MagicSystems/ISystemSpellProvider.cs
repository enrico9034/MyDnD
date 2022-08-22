namespace DnD.MagicSystems;

public interface ISystemSpellProvider<TSystemType> where TSystemType : SystemDescriptor
{
    ISystemSpell<TSystemType>[] GetSpells();
}