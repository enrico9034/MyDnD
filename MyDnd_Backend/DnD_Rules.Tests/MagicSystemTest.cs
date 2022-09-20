using DnD.Classes;
using DnD.MagicSystems.Magic;

namespace DnD_Rules.Tests;

public class MagicSystemTest
{
    [Test]
    public void MagicActivation()
    {
        var character = new Character();
        character.Classes.Add<Mage>();

        character.PowerSystem.GetAvailableSystemSpells<Magic>().Should().NotBeNull();
    }
}