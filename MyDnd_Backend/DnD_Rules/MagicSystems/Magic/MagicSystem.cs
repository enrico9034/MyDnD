namespace DnD.MagicSystems.Magic;

public class Magic : ISystemType
{
    public string SystemName => "Magic";
    public void EnablePowerSystem(Character targetCharacter)
    {
        
    }

    public System<TSystemType> GetSystem<TSystemType>() where TSystemType : ISystemType
    {
        throw new NotImplementedException();
    }
}

public class MagicSystem : System<Magic>
{
    public MagicSystem(ISystemContainer<Magic> container, ISystemConsumableStash<Magic> consumable, ISystemSpellProvider<Magic> spellProvider) : base(container, consumable, spellProvider)
    {
    }
}