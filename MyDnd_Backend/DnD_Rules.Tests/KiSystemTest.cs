

using Neo.IronLua;

namespace DnD_Rules.Tests;

public class KiSystemTest
{

    [Test]
    public void KiSystemTest_1()
    {
        dynamic character = new Character(UtilBuilder.GetLuaSupplier());
        character.Classes("Monk");
        character.Stats.Level = 2;
        character.Classes("Monk");

        var str = LuaTable.ToLson(character.PowerSystem);
        var furryOfBlows = character.PowerSystem[1]["Skills"][1] as dynamic;
        (furryOfBlows.Name as string).Should().Match(x => x.Equals("Furry Of Blows"));
    }
    //
    // [Test]
    // public void KiErrorWrongType()
    // {
    //     Character character = new();
    //     character.Classes.Add<Monk>();
    //     character.Classes[0].Level = 2;
    //
    //     try
    //     {
    //         var furryOfBlows = character.PowerSystem.GetAvailableSystemSpells<Magic>().GetSystemSpells()[0];
    //         Assert.Fail();
    //     }
    //     catch (PowerSystemTypeNotMatching ep)
    //     {
    //         Assert.Pass();
    //     }
    //     Assert.Fail();
    // }
}