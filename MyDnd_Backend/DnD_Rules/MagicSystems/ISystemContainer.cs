namespace DnD.MagicSystems;

public interface ISystemContainer <TSystemType> where TSystemType : SystemDescriptor
{
    ISystemSpell<TSystemType>[] GetLearnedSpells();
}

public interface ISystemSpell<TSystemType> where TSystemType : SystemDescriptor
{
    
}