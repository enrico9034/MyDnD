namespace DnD.MagicSystems;

public interface ISystemContainer <TSystemType> where TSystemType : SystemDescriptor
{
    ISystemSpell<TSystemType>[] GetLearnedSpells();
}