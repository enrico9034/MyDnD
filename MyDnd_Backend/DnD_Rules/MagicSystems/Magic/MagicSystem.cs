namespace DnD.MagicSystems.Magic;

public class Magic : ISystemType
{
    public string SystemName => "Magic";
    public void EnablePowerSystem(Character targetCharacter)
    {
        
    }
}

public class MagicSystem : System<Magic>
{
    public MagicSystem(ISystemContainer<Magic> container, ISystemConsumableStash<Magic> consumable) : base(container, consumable)
    {
    }
}