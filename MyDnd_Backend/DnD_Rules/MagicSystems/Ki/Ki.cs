namespace DnD.MagicSystems.Ki;

public class Ki : ISystemType
{
    private KiSystem _system;
    
    public string SystemName => "Ki";
    
    public void EnablePowerSystem(Character targetCharacter)
    {
        _system = new KiSystem(new KiAbilityStash(), new KiPointsStash());
    }
    
}