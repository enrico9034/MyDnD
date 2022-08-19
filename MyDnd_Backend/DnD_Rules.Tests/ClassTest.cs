using DnD.Classes;

namespace DnD_Rules.Tests;

public class ClassTest
{
    [Test]
    public void Paladin()
    {
        var character = new Character();
        character.Stats.Dexterity.Value = 15;

        character.AC.Value.Should().Be(12, "15 => +2, 10 + 2 = 12");
        
        character.Classes.Add<Paladin>();
        character.AC.Value.Should().Be(13, "15 => +2, 10 + 2 = 12 + Paladin");
        
        character.Stats.Dexterity.Value = 16;
        
        character.AC.Value.Should().Be(14, "16 => +3, 10 + 3 = 13 + Paladin");


        
    }
}