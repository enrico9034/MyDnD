namespace DnD.MagicSystems.Magic;

public class MagicSystem : System<Magic>
{
    public MagicSystem(ISystemContainer<Magic> container, ISystemConsumableStash<Magic> consumable, ISystemSpellProvider<Magic> spellProvider) : base(container, consumable, spellProvider)
    {
    }
}