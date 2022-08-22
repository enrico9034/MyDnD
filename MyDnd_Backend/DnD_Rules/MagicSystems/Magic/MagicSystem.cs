namespace DnD.MagicSystems.Magic;

public class Magic : SystemDescriptor
{
    public override string SystemName { get; }
}

public class MagicSystem : System<Magic>
{
    public MagicSystem(ISystemContainer<Magic> container, ISystemConsumableStash<Magic> consumable) : base(container, consumable)
    {
    }
}