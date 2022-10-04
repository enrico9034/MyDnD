
using Neo.IronLua;

namespace DnD_Rules.Tests;

public class ClassTest
{
    [Test]
    public void Paladin()
    {
        dynamic character = new Character();
        character.Stats.Dexterity = 15;
    
        (character.AC as double?).Should().Be(12, "15 => +2, 10 + 2 = 12");
        
        character.Classes("Paladin");
        (character.AC as double?).Should().Be(13, "15 => +2, 10 + 2 = 12 + Paladin");
        
        character.Stats.Dexterity = 16;
        
        (character.AC as double?).Should().Be(14, "16 => +3, 10 + 3 = 13 + Paladin");

        character.Stats.Level = 2;
        character.Classes("Paladin");
        var str = LuaTable.ToLson(character.Class);
            
        (character.AC as double?).Should().Be(15, "16 => +3, 10 + 3 = 13 + Paladin + Paladin lv2");

    }
    
    
}