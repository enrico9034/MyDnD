namespace DnD.MagicSystems.Ki;

public class KiSystem : System<Ki>
{
    public KiSystem(ISystemContainer<Ki> container, ISystemConsumableStash<Ki> consumable, ISystemSpellProvider<Ki> spellProvider) : base(container, consumable, spellProvider)
    {
    }
}