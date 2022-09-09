namespace DnD.MagicSystems;

public class CharacterSystemAdaptor
{
    private Character _character;
    private ISystemType _systemType;
    public CharacterSystemAdaptor(Character character)
    {
        _character = character;
    }

    public void ApplySystem(ISystemType systemType)
    {
        _systemType = systemType;
        _systemType.EnablePowerSystem(_character);
    }

    public System<TSystemType> GetAvailableSystemSpells<TSystemType>() where TSystemType : ISystemType
    {
        return _systemType.GetSystem<TSystemType>();
    }
}