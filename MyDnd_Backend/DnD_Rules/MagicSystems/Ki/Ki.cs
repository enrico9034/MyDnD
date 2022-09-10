using DnD.CustomExceptions;

namespace DnD.MagicSystems.Ki;

public class Ki : ISystemType
{
    private KiSystem _system;
    
    public string SystemName => "Ki";
    
    public void EnablePowerSystem(Character targetCharacter)
    {
        _system = new KiSystem(new KiAbilityStash(), new KiPointsStash(), new KiAbilityProvider());
    }

    public System<TSystemType> GetSystem<TSystemType>() where TSystemType : ISystemType
    {
        if (typeof(TSystemType) != typeof(Ki))
            throw new PowerSystemTypeNotMatching<Ki, TSystemType>();

        return _system as System<TSystemType>;
    }
}