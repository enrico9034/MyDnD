using DnD.CustomExceptions;

namespace DnD.MagicSystems.Magic;

public class Magic : ISystemType
{
    private MagicSystem _system;
    public string SystemName => "Magic";
    public void EnablePowerSystem(Character targetCharacter)
    {
        _system = new MagicSystem(new MagicAbilityStash(), new MagicSlotsContainer(), new MagicAbilityProvider());
    }

    public System<TSystemType> GetSystem<TSystemType>() where TSystemType : ISystemType
    {
        if (typeof(TSystemType) != typeof(Magic))
            throw new PowerSystemTypeNotMatching<Magic, TSystemType>();

        return _system as System<TSystemType>;
    }
}