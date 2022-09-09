using DnD.Classes;
using DnD.MagicSystems.Ki;

namespace DnD_Rules.Tests;

public class KiSystemTest
{

    [Test]
    public void KiSystemTest_1()
    {
        Character character = new();
        character.Classes.Add<Monk>();
        character.Classes[0].Level = 2;

        var furryOfBlows = character.PowerSystem.GetAvailableSystemSpells<Ki>().GetSystemSpells()[0];
        furryOfBlows.Should().Match(x => (x as KiAbility).Name.Equals("Furry Of Blows"));
    }
}