namespace DnD.MagicSystems;

public abstract class System<TSystemType> where TSystemType : ISystemType
{
    private readonly ISystemContainer<TSystemType> _container;
    private readonly ISystemConsumableStash<TSystemType> _consumableStash;
    
    public System(ISystemContainer<TSystemType> container, ISystemConsumableStash<TSystemType> consumable)
    {
        _container = container;
        _consumableStash = consumable;
    }

    public ISystemSpell<TSystemType>[] GetAvailableSpells()
    {
        return _container.GetLearnedSpells();
    }

    public ISystemConsumable<TSystemType>[] GetConsumableSlots()
    {
        return _consumableStash.GetStash(x => !x.IsConsumed());
    }

    public ISystemConsumable<TSystemType>[] GetAllConsumableSlots()
    {
        return _consumableStash.GetStash(x => true);
    }
    
}