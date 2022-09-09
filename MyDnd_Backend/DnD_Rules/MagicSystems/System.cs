namespace DnD.MagicSystems;

public abstract class System<TSystemType> where TSystemType : ISystemType
{
    private readonly ISystemContainer<TSystemType> _container;
    private readonly ISystemConsumableStash<TSystemType> _consumableStash;
    private readonly ISystemSpellProvider<TSystemType> _spellProvider;

    public System(ISystemContainer<TSystemType> container, ISystemConsumableStash<TSystemType> consumable, ISystemSpellProvider<TSystemType> spellProvider)
    {
        _container = container;
        _consumableStash = consumable;
        _spellProvider = spellProvider;
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

    public ISystemSpell<TSystemType>[] GetSystemSpells()
    {
        return _spellProvider.GetSpells();
    }
    

}