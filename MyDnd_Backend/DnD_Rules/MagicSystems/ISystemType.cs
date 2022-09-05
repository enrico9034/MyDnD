namespace DnD.MagicSystems;

public interface ISystemType
{
    string SystemName { get; }

    void EnablePowerSystem(Character targetCharacter);
}