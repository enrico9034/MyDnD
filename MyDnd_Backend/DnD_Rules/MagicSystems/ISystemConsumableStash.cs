namespace DnD.MagicSystems;

public interface ISystemConsumableStash<TSystemType> where TSystemType : ISystemType
{
    ISystemConsumable<TSystemType>[] GetStash(Func<ISystemConsumable<TSystemType>, bool> filter);
}