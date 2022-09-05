using DnD.Classes;

namespace DnD_Rules.Tests;

public class KiSystemTest
{

    [Test]
    public void KiSystemTest_1()
    {
        Character character = new();
        character.Classes.Add<Monk>();
        character.Classes[0].Level = 2;
    }
}