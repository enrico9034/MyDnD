namespace DnD.MagicSystems;

public interface ISystemConsumableStash<TSystemType> where TSystemType : SystemDescriptor
{
    ISystemConsumable<TSystemType>[] GetStash(Func<ISystemConsumable<TSystemType>, bool> filter);
}