namespace DnD.MagicSystems.Ki;

public class Ki : SystemDescriptor
{
    public override string SystemName { get; }
}

public class KiSystem : System<Ki>
{
    public KiSystem(ISystemContainer<Ki> container, ISystemConsumableStash<Ki> consumable) : base(container, consumable)
    {
    }
}