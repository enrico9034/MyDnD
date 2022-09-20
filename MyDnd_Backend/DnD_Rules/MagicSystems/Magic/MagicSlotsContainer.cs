namespace DnD.MagicSystems.Magic;

public class MagicSlotsContainer : ISystemConsumableStash<Magic>
{
    public ISystemConsumable<Magic>[] GetStash(Func<ISystemConsumable<Magic>, bool> filter)
    {
        throw new NotImplementedException();
    }
}